using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Admission;
using WARDxAPI.Model.Shared;

namespace WARDxAPI.Model
{
    public class CreateAdmissionModel : ICreateAdmissionModel
    {
        public CreateAdmissionModel(IViewReferralModel viewReferralModel, IPatientAdmit patientAdmit,IAlertModel alertModel, IPatientAdmitDiagnosis patientAdmitDiagnosis, IPatientDischarge patientDischarge)
        {
            ViewReferralModel = viewReferralModel;
            PatientAdmit = patientAdmit;
            AlertModel = alertModel;
            PatientAdmitDiagnosis = patientAdmitDiagnosis;
            PatientDischarge = patientDischarge;
        }
       
        public IViewReferralModel ViewReferralModel { get; set; }
        public IPatientAdmit PatientAdmit { get; set; }
        public IAlertModel AlertModel { get; set; }
        public IPatientAdmitDiagnosis PatientAdmitDiagnosis { get; set; }

        public IPatientDischarge PatientDischarge { get; set; }
    }
}
