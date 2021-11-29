using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface.StaffScheduling;

namespace WARDxAPI.Model.Interface
{
    public interface IGenerateTimesheetModel
    {
        //Defines the view to Generate a timesheet
        IGenerateTimesheet GenerateTimesheet { get; set; }

        IAlertModel alertModel { get; set; }
    }
}