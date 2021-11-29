using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface.StaffScheduling;

namespace WARDxAPI.Model.Interface
{
    public interface IViewScheduleModel 
    {
        //Defines the view to View a Schedule
        IScheduleTable ScheduleTable { get; set; }
        IAlertModel alertModel { get; set; }
    }
}