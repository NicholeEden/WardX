using EFCore.Interface;
using WARDxAPI.Model.Interface.Profile;

namespace WARDxAPI.Model.Profile
{
    public class ConfirmCreate : IConfirmCreate
    {
        public string PatientName { get; set; }
        public Gender PatientGender { get; set; }
        public string KinName { get; set; }
        public Gender KinGender { get; set; }
        public string Relationship { get; set; }
        public string MedicalAidScheme { get; set; }
        public string MedicalAidPlan { get; set; }
        public bool isValid { get; set; }
    }
}
