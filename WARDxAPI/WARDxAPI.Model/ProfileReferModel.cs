using System.Collections.Generic;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Profile;

namespace WARDxAPI.Model
{
    public class ProfileReferModel : IProfileReferModel
    {
        public ProfileReferModel(
            IPatientDiagnosis patientDiagnosis,
            IPatientReferral patientReferral,
            ISubmitReferral submitReferral,
            IAlertModel alert)
        {
            PatientDiagnosis = patientDiagnosis;
            PatientReferral = patientReferral;
            SubmitReferral = submitReferral;
            Alert = alert;
        }
        public IPatientDiagnosis PatientDiagnosis { get; set; }
        public IPatientReferral PatientReferral { get; set; }
        public IAlertModel Alert { get; set; }
        public List<IStatusBoxModel> StatusBoxes { get; set; }
        public ISubmitReferral SubmitReferral { get; set; }
    }
}
