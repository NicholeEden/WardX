using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface.PatientMove;

namespace WARDxAPI.Model.Interface
{
    /// <summary>
    /// This defines the parameters needed by the PatientMove/FollowUp
    /// </summary>
    public interface IFollowUpModel
    {
     /// <summary>
     /// These properties represent the elements in the FollowUp Email Process
     /// Defines parameters needed to check in a patient.
     /// IMoveFollow is the form for FollowUp
     /// </summary>

        IMoveFollow moveFollow { get; set; }

        IAlertModel alertModel { get; set; }
    }
}
