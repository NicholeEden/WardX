using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Profile;

namespace WARDxAPI.Model
{
    public class ProfileDetailsModel : IProfileDetailsModel
    {
        public ProfileDetailsModel(
            IAlertModel alert,
            IPatientInfo patientInfo)
        {
            Alert = alert;
            PatientInfo = patientInfo;
        }

        public IAlertModel Alert { get; set; }
        public IPatientInfo PatientInfo { get; set; }
    }
}
