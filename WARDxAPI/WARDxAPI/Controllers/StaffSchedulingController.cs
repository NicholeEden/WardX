using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Interface;
using BusinessLogic.Model;
using EFCore.Interface;
using Microsoft.AspNetCore.Mvc;
using WARDxAPI.Interface;
using WARDxAPI.Model;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Shared;
using WARDxAPI.Model.Interface.StaffScheduling;
using WARDx.DataAcess;
using WARDx.Data;
using WARDxAPI.Model.StaffScheduling;

namespace WARDxAPI.Controllers
{
    public class StaffSchedulingController : Controller, IStaffSchedulingController
    {
        private readonly ISchedulingModelProvider _modelProvider;
        private readonly ISchedulingProcessor _schedulingProcessor;
        private readonly IDropdownProcessor _dropdownProcessor;
        private readonly IStaffProcessor _staffProcessor;
        private readonly IBusinessLogic _logic;
        private IAlertModel _alert;

        private readonly IDataAccess _dataAccess;
        private readonly IDataProcessor _dataProcessor;

        public StaffSchedulingController(
            IBusinessLogic logic,
            IDropdownProcessor dropdownProcessor,
            ISchedulingProcessor schedulingProcessor,
            IStaffProcessor staffProcessor

            )
        {
            _logic = logic;
            _modelProvider = APIConfig.ResolveSchedulingModel();
            _schedulingProcessor = schedulingProcessor;
            _dropdownProcessor = dropdownProcessor;
            _staffProcessor = staffProcessor;
            _alert = APIConfig.ResolveAlertModel();

            _dataAccess = DataAccessConfig.ResolveDataAccess();
            _dataProcessor = DataProcessorConfig.ResolveDataProcessor();

        }

        #region Create Schedule
        [HttpGet]
        public IActionResult CreateSchedule()
        {
            ViewBag.Title = "Create Schedule";

            #region Nurse Options
            // load nurse options
            var nurses = _dataAccess.GetData<NurseDetail>(storedProcedure: "sp_SelectAllNurse");

            var list = _dataProcessor.GetDictionary<NurseDetail>(
                value: nurses,
                keyParameter: nameof(INurse.NurseID),
                displayParameters: new string[]{
                    nameof(IStaffMember.FirstName),
                    nameof(IStaffMember.LastName)
                },
                separator: " ");
            _modelProvider.CreateScheduleModel.CreateSchedule.NurseIDList = list;
            #endregion

            #region Month Options

            // load month options
            var months = _dataAccess.GetData<Month>(storedProcedure: "sp_GetMonths");

            var monthList = _dataProcessor.GetDictionary<Month>(
                value: months,
                keyParameter: nameof(IMonth.MonthID),
                displayParameter: nameof(IMonth.MonthName));

            _modelProvider.CreateScheduleModel.CreateSchedule.MonthOptions = monthList;

            #endregion

            #region ShiftSlot Options

            var shifts = _dataAccess.GetData<ShiftSlot>(storedProcedure: "sp_GetShiftSlot");

            var shiftList = _dataProcessor.GetDictionary<ShiftSlot>(
                value: shifts,
                keyParameter: nameof(IShiftSlot.ShiftSlotID),
                displayParameter: nameof(IShiftSlot.Description));

            _modelProvider.CreateScheduleModel.CreateSchedule.ShiftSlotOptions = shiftList;

            #endregion


            
            return View(_modelProvider.CreateScheduleModel);

        }

        [HttpPost] //checking availability
        public IActionResult CreateSchedule(CreateSchedule model)
        {
            ViewBag.Title = "Create Schedule";

            if (ModelState.IsValid)
            {
                // get information from model
                               

                // check result
                try
                {
                    // get information from model
                    var schedule = _dataAccess.ExecuteData<CreateSchedule>(
                        storedProcedure: "sp_InsertNurseSchedule",
                        parameterNames: new string[] {
                        nameof(INurseSchedule.isAvailable),
                        nameof(INurse.NurseID),
                        nameof(IMonth.MonthID),
                        nameof(IShiftSlot.ShiftSlotID)
                        },
                        value: model);

                    // add success alert message
                    _alert.Type = AlertModelType.Success;
                    _alert.Header = "SUCCESSFUL!";
                    _alert.Content = "You have successfully created a Nurse Schedule";
                    _modelProvider.CreateScheduleModel.alertModel = _alert;

                    return RedirectToAction(nameof(ViewSchedule));

                }
                catch (Exception ex)
                {
                    // add fail alert message
                    _alert.Type = AlertModelType.Danger;
                    _alert.Header = "UNSUCCESSFUL";
                    _alert.Content = "Please try again";
                    _modelProvider.CreateScheduleModel.alertModel = _alert;
                }
            }

            #region Nurse Options
            // load nurse options
            var nurses = _dataAccess.GetData<NurseDetail>(storedProcedure: "sp_SelectAllNurse");

            var list = _dataProcessor.GetDictionary<NurseDetail>(
                value: nurses,
                keyParameter: nameof(INurse.NurseID),
                displayParameters: new string[]{
                    nameof(IStaffMember.FirstName),
                    nameof(IStaffMember.LastName)
                },
                separator: " ");
            _modelProvider.CreateScheduleModel.CreateSchedule.NurseIDList = list;
            #endregion

            #region Month Options

            // load month options
            var months = _dataAccess.GetData<Month>(storedProcedure: "sp_GetMonths");

            var monthList = _dataProcessor.GetDictionary<Month>(
                value: months,
                keyParameter: nameof(IMonth.MonthID),
                displayParameter: nameof(IMonth.MonthName));

            _modelProvider.CreateScheduleModel.CreateSchedule.MonthOptions = monthList;

            #endregion

            #region ShiftSlot Options
            //load shift slot options
            var shifts = _dataAccess.GetData<ShiftSlot>(storedProcedure: "sp_GetShiftSlot");

            var shiftList = _dataProcessor.GetDictionary<ShiftSlot>(
                value: shifts,
                keyParameter: nameof(IShiftSlot.ShiftSlotID),
                displayParameter: nameof(IShiftSlot.Description));

            _modelProvider.CreateScheduleModel.CreateSchedule.ShiftSlotOptions = shiftList;

            #endregion


            return View(_modelProvider.CreateScheduleModel);

        }        
        #endregion


        #region View Schedule      
        [HttpGet]
        public IActionResult ViewSchedule()
        {
            ViewBag.Title = "View Schedule";
            // get current month
            int currentMonth = 100 + DateTime.Now.Month;

            // resolve monthID
            var model = new NurseScheduleDetail
            {
                MonthID = currentMonth
            };

            // get database tables
            var schedules = _dataAccess.GetData<NurseScheduleDetail>(
                storedProcedure: "sp_GetNurseSchedule");

            var content = _dataProcessor.GetTableContent<NurseScheduleDetail>(
                value: schedules,
                keyParameter: null,
                value1Parameter: nameof(IStaffMember.StaffID),
                value2Parameter: nameof(IStaffMember.FirstName),
                value3Parameter: nameof(IStaffMember.LastName),
                value4Parameter: nameof(IShiftSlot.Description),
                value5Parameter: nameof(IMonth.MonthName));

            _modelProvider.ViewScheduleModel.ScheduleTable.CardTableContents = content;

            return View(_modelProvider.ViewScheduleModel);
        }

        [HttpPost]
        public IActionResult ViewSchedule(ViewScheduleModel model)
        {
            ViewBag.Title = "View Schedule";

            // load table data
            INurseSchedule nurseSchedule = (INurseSchedule)model;

            var schedules = _dataAccess.GetData<NurseScheduleDetail>(
                storedProcedure: "sp_GetNurseScheduleByID",
                parameterNames: new string[]{
                    nameof(INurseSchedule.ScheduleID)
                },
                value: (NurseScheduleDetail)nurseSchedule);

            var content = _dataProcessor.GetTableContent<NurseScheduleDetail>(
                value: schedules,
                keyParameter: nameof(IStaffMember.StaffID),
                value1Parameter: nameof(ScheduleDetail.FirstName),
                value2Parameter: nameof(ScheduleDetail.LastName),
                value3Parameter: nameof(ScheduleDetail.MonthName),
                value4Parameter: nameof(ScheduleDetail.StartTime),
                value5Parameter: nameof(ScheduleDetail.EndDate));
            _modelProvider.ViewScheduleModel.ScheduleTable.CardTableContents = content;

            return View(_modelProvider.ViewScheduleModel);
        }
        #endregion


        #region Generate Timesheet
        [HttpGet]
        public IActionResult GenerateTimesheet()
        {
            ViewBag.Title = "Generate Timesheet";

            // load nurse options
            var nurses = _dataAccess.GetData<NurseDetail>(storedProcedure: "sp_SelectAllNurse");

            var list = _dataProcessor.GetDictionary<NurseDetail>(
                value: nurses,
                keyParameter: nameof(INurse.NurseID),
                displayParameters: new string[]{
                    nameof(IStaffMember.FirstName),
                    nameof(IStaffMember.LastName)
                },
                separator: " ");
            _modelProvider.GenerateTimesheetModel.GenerateTimesheet.NurseOptions = list;

            var months = _dataAccess.GetData<Month>(storedProcedure: "sp_GetMonth");

            var monthList = _dataProcessor.GetDictionary<Month>(
                value: months,
                keyParameter: nameof(IMonth.MonthID),
                displayParameter: nameof(IMonth.MonthName));

            _modelProvider.GenerateTimesheetModel.GenerateTimesheet.MonthOptions = monthList;

            return View(_modelProvider.GenerateTimesheetModel);
        }

        [HttpPost]
        public IActionResult GenerateTimesheet(GenerateTimesheetModel model)
        {
            ViewBag.Title = "Generate Timesheet";

            if (ModelState.IsValid)
            {
                var item = model.GenerateTimesheet.ClockingID;

                var result = _dataAccess.ExecuteData<Clocking>(
                    storedProcedure: "sp_GetClocking",
                    parameterNames: null,
                    value: null);

                // check result
                if (result > 0)
                {
                    // add success alert message
                    _alert.Type = AlertModelType.Success;
                    _alert.Header = "SUCCESSFUL!";
                    _alert.Content = "You have successfully created a Timesheet";
                    _modelProvider.GenerateTimesheetModel.alertModel = _alert;
                }
                else
                {
                    // add fail alert message
                    _alert.Type = AlertModelType.Danger;
                    _alert.Header = "UNSUCCESSFUL";
                    _alert.Content = "Please try again";
                    _modelProvider.GenerateTimesheetModel.alertModel = _alert;
                }



            }
            else
            {
                // load nurse options
                var gene = _dataAccess.GetData<GenerateDetail>(storedProcedure: "sp_SelectAllNurse");

                var list = _dataProcessor.GetDictionary<GenerateDetail>(
                    value: gene,
                    keyParameter: nameof(INurse.NurseID),
                    displayParameters: new string[]{
                    nameof(IMonth.StartDate),
                    nameof(IMonth.EndDate)
                    },
                    separator: " ");
                _modelProvider.GenerateTimesheetModel.GenerateTimesheet.NurseOptions = list;

                // load table data
                IClocking clocking = (IClocking)model;

                var timesheets = _dataAccess.GetData<GenerateDetails>(
                    storedProcedure: "sp_GetClockingByNurseID",
                    parameterNames: new string[]{
                    nameof(IMonth.MonthID),
                    nameof(INurse.NurseID)
                    },
                    value: (GenerateDetails)clocking);
                var content = _dataProcessor.GetTableContent<GenerateDetails>(
                    value: timesheets,
                    keyParameter: nameof(IClocking.ClockingID),
                    value1Parameter: nameof(GenerateDetails.MonthName),
                    value2Parameter: nameof(GenerateDetails.ClockInTime),
                    value3Parameter: nameof(GenerateDetails.ClockOutTime));

                _modelProvider.GenerateTimesheetModel.GenerateTimesheet.CardTableContents = (IList<ICardTableContent>)content;
            }
            return View(_modelProvider.GenerateTimesheetModel);
        }      
        #endregion


        #region View Timesheet    
        [HttpGet]
        public IActionResult ViewTimesheet()
        {
            ViewBag.Title = "View Timesheet";

            // instantiate new model
            var model = new ViewTimesheetModel();

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
            return View(_modelProvider.ViewTimesheetModel);
        }

        [HttpPost]
        public IActionResult ViewTimesheet(ViewTimesheetModel model)
        {
            ViewBag.Title = "View Timesheet";


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
            var timesheet = _dataAccess.GetData<ViewTimesheetModel>(
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
                var content = _dataProcessor.GetTableContent<ViewTimesheetModel>(
                    value: timesheet,
                    keyParameter: null,
                    value1Parameter: nameof(ViewTimesheetModel.MonthID),
                    value2Parameter: nameof(ViewTimesheetModel.ClockInTime),
                    value3Parameter: nameof(ViewTimesheetModel.ClockOutTime));

                // load table contents
                model.TableContents = content;
            }

            // return the view with model data
            return View(_modelProvider.ViewTimesheetModel);
        }
        #endregion










        #region Fake Timehseeet
        //fake one
        public IActionResult ViewTimesheeet()
        {
            ViewBag.Title = "View Timesheet(1)";
            return View();
        }
        #endregion

    }

}

