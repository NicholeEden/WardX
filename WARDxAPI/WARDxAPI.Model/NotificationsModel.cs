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
   public class NotificationsModel : INotificationsModel
    {
       
        public NotificationsModel(IMoveNotification moveNotif)
        {
            moveNotification = moveNotif;

        }

     
        
        public IMoveNotification moveNotification { get ; set ; }
    }
}
