using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface.Admission;

namespace WARDxAPI.Model.Interface
{
    /// <summary>
    /// This defines the models for creating and admissionFile
    /// </summary>
    public interface ICreateAdmissionModel
    {
        IViewReferralModel ViewReferralModel { get; set; }
        IPatientAdmit PatientAdmit { get; set; }

        IPatientAdmitDiagnosis PatientAdmitDiagnosis { get; set; }

        IPatientDischarge PatientDischarge { get; set; }

        IAlertModel AlertModel { get; set; }

    }
}
