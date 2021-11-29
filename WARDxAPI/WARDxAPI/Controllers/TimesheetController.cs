using BusinessLogic.Model;
using EFCore.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WARDx.Data;
using WARDx.DataAcess;
using WARDxAPI.Model.Shared;
using WARDxAPI.Model.Timesheet;

namespace WARDxAPI.Controllers
{
    public class TimesheetController : Controller
    {
        private readonly IDataAccess _dataAccess;
        private readonly IDataProcessor _dataProcessor;
        public TimesheetController()
        {
            _dataAccess = DataAccessConfig.ResolveDataAccess();
            _dataProcessor = DataProcessorConfig.ResolveDataProcessor();
        }
        // GET: TimesheetController
        public ActionResult Index()
        {
            // instantiate new model
            var model = new TimesheetModel();
            // get all nurses from database
            var nurses = _dataAccess.GetData<NurseDetail>(storedProcedure: "sp_SelectAllNurse");
            // convert data to dictionary
            var nurseList = _dataProcessor.GetDictionary<NurseDetail>(
                value: nurses,
                keyParameter: nameof(INurse.NurseID),
                displayParameters: new string[]
                {
                    nameof(IStaffMember.FirstName),
                    nameof(IStaffMember.LastName)
                },
                separator: " ");
            // load nurse options
            model.NurseOptions = nurseList;
            // get all months from database
            var months = _dataAccess.GetData<Month>(storedProcedure: "sp_GetMonths");
            // convert data to dictionary
            var monthList = _dataProcessor.GetDictionary<Month>(
                value: months,
                keyParameter: nameof(IMonth.MonthID),
                displayParameter: nameof(IMonth.MonthName));
            // load month options
            model.MonthOptions = monthList;
            // return the view with model data
            return View(model);
        }

        // GET: TimesheetController/Viewsheet
        [HttpPost]
        public ActionResult Viewsheet(TimesheetModel model)
        {
            // instantiate new model for 'MonthID'
            var data = new Month { MonthID = model.MonthID };
            // get month from database
            var month = _dataAccess.GetDataFilterd<Month>(
                storedProcedure: "sp_SelectMonth",
                parameterNames: new string[] {
                    nameof(IMonth.MonthID)
                },
                value: data);
            // get start date using month details
            model.StartDate = Convert.ToDateTime($"{ month.StartDate }/{ month.MonthName }/{ DateTime.Now.Year }");
            // get end date using month details
            model.EndDate = Convert.ToDateTime($"{ month.EndDate }/{ month.MonthName }/{ DateTime.Now.Year }");
            // get timesheet from database
            var timesheet = _dataAccess.GetData<TimesheetModel>(
                storedProcedure: "sp_GetClockingByNurseID",
                parameterNames: new string[] {
                    nameof(INurse.NurseID),
                    nameof(IMonth.StartDate),
                    nameof(IMonth.EndDate)
                },
                value: model);
            if (timesheet is null)
            {
                model.TableContents = new List<TableContent>();
            }
            else
            {
                // get table contents
                var content = _dataProcessor.GetTableContent<TimesheetModel>(
                    value: timesheet,
                    keyParameter: null,
                    value1Parameter: null,
                    value2Parameter: null,
                    value3Parameter: null);
                // load table contents
                model.TableContents = content; 
            }
            // return the view with model data
            return View(model);
        }
    }
}
