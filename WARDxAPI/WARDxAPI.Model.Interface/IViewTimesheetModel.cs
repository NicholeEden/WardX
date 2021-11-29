using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface.StaffScheduling;

namespace WARDxAPI.Model.Interface
{
    public interface IViewTimesheetModel
    {
        //Defines the view to View a Timesheet
        IViewTimesheet ViewTimesheet { get; set; }
        IAlertModel alertModel { get; set; }
    }
}