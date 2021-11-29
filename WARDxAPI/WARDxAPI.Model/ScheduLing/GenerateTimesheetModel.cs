using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.StaffScheduling;
using WARDxAPI.Model.Shared;

namespace WARDxAPI.Model
{
    public class GenerateTimesheetModel : IGenerateTimesheetModel
    {
        public GenerateTimesheetModel(
            IGenerateTimesheet generateTimesheet,
            IAlertModel AlertModel)
        {
            GenerateTimesheet = generateTimesheet;
            alertModel = AlertModel;
        }
        public IGenerateTimesheet GenerateTimesheet { get; set; }
        public IAlertModel alertModel { get; set; }
    }

}
