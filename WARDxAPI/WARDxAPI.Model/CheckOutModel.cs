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
   public class CheckOutModel : ICheckOutModel
    {
       
        public CheckOutModel(IMoveCheckOut checkOut, IAlertModel AlertModel)
        {
            moveCheckOut = checkOut;
            alertModel = AlertModel;
        
        }
        public IMoveCheckOut moveCheckOut { get; set; }
       
        public IAlertModel alertModel { get; set; }

   
    }
}
