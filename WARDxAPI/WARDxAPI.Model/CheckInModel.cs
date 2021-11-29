using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Shared;

namespace WARDxAPI.Model
{
    /// <summary>
    /// This is the model for the checkout process
    /// </summary>
   public class CheckInModel : ICheckInModel
    {
       
        public CheckInModel(IMoveCheckIn _checkIn, IAlertModel _alertModel)
        {
            moveCheckIn = _checkIn;
            alertModel = _alertModel;
        
        }

        public IMoveCheckIn moveCheckIn { get; set; }
        public IAlertModel alertModel { get; set; }
       
    }
}
