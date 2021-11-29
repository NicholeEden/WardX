using BusinessLogic.Model;
using EFCore.Interface;
using System.Collections.Generic;
using WARDxAPI.Model;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.StaffScheduling;

namespace WARDxAPI.Interface
{
    public interface ISchedulingModelProvider
    {
        //Defines the CREATING process for Staff Scheduling 
        ICreateScheduleModel CreateScheduleModel { get; }
        IGenerateTimesheetModel GenerateTimesheetModel { get; }

        //Defines the VIEWING process for Staff Scheduling
        IViewScheduleModel ViewScheduleModel { get; }
        IViewTimesheetModel ViewTimesheetModel { get; }


    }
}
