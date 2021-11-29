using BusinessLogic.Model;
using EFCore.Interface;
using System.Collections.Generic;
using WARDxAPI.Interface;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.StaffScheduling;
using WARDxAPI.Model.Shared;


namespace WARDxAPI.Model
{
    public class SchedulingModelProvider : ISchedulingModelProvider
    {
        public SchedulingModelProvider(
              ICreateScheduleModel createModel,
              IViewScheduleModel viewModel,
              IGenerateTimesheetModel generateModel,
              IViewTimesheetModel viewTimesheetModel,
              IAlertModel alertModel)
        {
            CreateScheduleModel = createModel;
            ViewScheduleModel = viewModel;
            GenerateTimesheetModel = generateModel;
            ViewTimesheetModel = viewTimesheetModel;
            AlertModel = alertModel;
            
        }
        public ICreateScheduleModel CreateScheduleModel { get; }
        public IViewScheduleModel ViewScheduleModel { get; }

        public IAlertModel AlertModel { get; set; }

        public IGenerateTimesheetModel GenerateTimesheetModel { get; }
        public IViewTimesheetModel ViewTimesheetModel { get; }


        //#region CreateSchedule
        //public void SetupCreateScheduleModel(
        //    INurse nurse, 
        //    IStaffMember staffMember,
        //    IMonth month,
        //    IShiftSlot shiftSlot,
        //    ICreateSchedule model)
        //{
        //    model.NurseID = nurse.NurseID;
        //    model.NurseName = staffMember.FirstName + " " + staffMember.LastName;
        //    model.MonthStart = month.StartDate;
        //    model.MonthEnd = month.EndDate;
        //    model.ScheduleID = shiftSlot.ShiftSlotID;
        //    model.ShiftSlotID = shiftSlot.ShiftSlotID;
        //}
        //#endregion


        //#region ViewSchedule
        //public void SetupViewScheduleModel(
        //    INurse nurse,
        //    IStaffMember staffMember,
        //    IMonth month,
        //    IShiftSlot shiftSlot,
        //    IViewSchedule model)
        //{
        //    model.NurseID = nurse.NurseID;
        //    model.NurseName = staffMember.FirstName + " " + staffMember.LastName;
        //    model.MonthName = month.MonthName;
        //    model.ShiftStart = shiftSlot.StartTime;
        //    model.ShiftEnd = shiftSlot.EndTime;
        //}
        //#endregion


        //#region GenerateTimesheet
        //public void SetupGenerateTimesheetModel(
        //    IClocking clocking,
        //    IMonth month,
        //    INurse nurse,
        //    IGenerateTimesheet model)
        //{
        //    model.NurseID = nurse.NurseID;
        //    model.ClockingID = clocking.ClockingID;
        //    model.MonthID = month.MonthID;
        //    model.MonthStart = month.StartDate;
        //    model.MonthEnd = month.EndDate;

        //}
        //#endregion


        //#region ViewTimesheet
        //public void SetupViewTimesheetModel(
        //    IClocking clocking, 
        //    IMonth month, 
        //    IViewTimesheet model)
        //{
        //    model.MonthName = month.MonthName;
        //    model.ClockInTime = clocking.ClockInTime;
        //    model.ClockOutTime = clocking.ClockOutTime;
        //}
        //#endregion
    }
}