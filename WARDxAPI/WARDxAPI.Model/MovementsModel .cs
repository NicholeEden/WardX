using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Shared;

namespace WARDxAPI.Model
{
    /// <summary>
    /// This is the model for the patient movememnt report process
    /// </summary>
   public class MovementsModel : IMovementsModel
    {
       
        public MovementsModel(IMoveReport report, IAlertModel _alertModel)
        {
            movementReports = report;
            alertModel = _alertModel;
        
        }

        public IMoveReport movementReports { get ; set; }
        public IAlertModel alertModel { get; set; }
       
    }
}
