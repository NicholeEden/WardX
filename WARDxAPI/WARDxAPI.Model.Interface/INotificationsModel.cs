
using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface.PatientMove;

namespace WARDxAPI.Model.Interface
{
    /// <summary>
    /// This defines the parameters needed by the PatientMove/Notifications
    /// </summary>
    public interface INotificationsModel
    {
        /// <summary>
        /// These properties represent the elements in theNotificationsModel
        /// Defines parameters needed to check in a patient.
        /// IMoveFollow is the form for FollowUp
        /// </summary>

        IMoveNotification moveNotification { get; set; }

       
    }
}
