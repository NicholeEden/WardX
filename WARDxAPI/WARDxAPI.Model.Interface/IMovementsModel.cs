using System;
using System.Collections.Generic;
using System.Text;

namespace WARDxAPI.Model.Interface
{
    /// <summary>
    /// This defines the parameters needed by the PatientMove/Movements
    /// </summary>
    public interface IMovementsModel
    {
        /// <summary>
        /// These properties represent the elements in the CheckIn
        /// Defines parameters needed to check in a patient.
        /// IMoveCheckIn is the form for Check In
        /// </summary>
       
        IMoveReport movementReports { get; set; }

        IAlertModel alertModel { get; set; }


    }
}
