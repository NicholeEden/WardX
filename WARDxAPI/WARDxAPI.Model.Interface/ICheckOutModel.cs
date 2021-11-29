using System;
using System.Collections.Generic;
using System.Text;

namespace WARDxAPI.Model.Interface
{
    /// <summary>
    /// This defines the parameters needed by the PatientMove/CheckOut
    /// </summary>
    public interface ICheckOutModel
    {
        /// <summary>
        /// These properties represent the elements in the CheckOut View
        /// Defines parameters needed to check out a patient.
        /// IMoveCheckOut is the form for Check Out
        /// </summary>
       
        IMoveCheckOut moveCheckOut { get; set; }

        IAlertModel alertModel { get; set; }


    }
}
