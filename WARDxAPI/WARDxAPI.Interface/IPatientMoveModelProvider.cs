using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface;

namespace WARDxAPI.Interface
{
    /// <summary>
    /// Defines the models required by the Patient Movement Controller and Views
    /// </summary>
    public interface IPatientMoveModelProvider
    {
        /// <summary>
        /// Provides a model for the view 'PatientMove/CheckOut'
        /// </summary>
        ICheckOutModel checkOutModel { get; }

        // <summary>
        /// Provides a model for the view 'PatientMove/CheckIn'
        /// </summary>
        ICheckInModel checkInModel { get; }

        // <summary>
        /// Provides a model for the view 'PatientMove/Movements'
        /// </summary>
        IMovementsModel movementsModel { get; }

        /// <summary>
        /// Provides a model for the view 'PatientMove/FollowUp'
        /// </summary>
        IFollowUpModel followUpModel { get; }

        INotificationsModel notificationsModel { get; }

    }
}
