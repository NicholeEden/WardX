using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface.StaffScheduling;


namespace WARDxAPI.Model.Interface
{
    public interface ICreateScheduleModel
    {
        //Defines the view to Create a model
        ICreateSchedule CreateSchedule { get; set; }
        
        IAlertModel alertModel { get; set; }

        
    }
}