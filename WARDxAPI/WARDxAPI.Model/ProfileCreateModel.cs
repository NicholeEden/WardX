using System.Collections.Generic;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Profile;

namespace WARDxAPI.Model
{
    public class ProfileCreateModel : IProfileCreateModel
    {
        public ProfileCreateModel(
            IPatientCreate patientCreate,
            INextOfKinCreate nextOfKinCreate,
            IMedicalAidCreate medicalAidCreate,
            IConfirmCreate confirmCreate,
            IAlertModel alert)
        {
            PatientCreate = patientCreate;
            NextOfKinCreate = nextOfKinCreate;
            MedicalAidCreate = medicalAidCreate;
            ConfirmCreate = confirmCreate;
            Alert = alert;
        }
        public IPatientCreate PatientCreate { get; set; }
        public IAlertModel Alert { get; set; }
        public List<IStatusBoxModel> StatusBoxes { get; set; }
        public INextOfKinCreate NextOfKinCreate { get; set; }
        public IMedicalAidCreate MedicalAidCreate { get; set; }
        public IConfirmCreate ConfirmCreate { get; set; }
    }
}