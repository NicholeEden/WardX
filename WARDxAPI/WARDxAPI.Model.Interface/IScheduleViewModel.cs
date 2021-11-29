using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface.StaffScheduling;

namespace WARDxAPI.Model.Interface
{
    public interface IScheduleViewModel
    {
        //Defines the view to view a Nurse's Schedule
        IScheduleTable ViewSchedule { get; set; }

        //Defines the view to view a Nurse's Timesheet
        IViewTimesheet ViewTimesheet { get; set; }
    }
}
