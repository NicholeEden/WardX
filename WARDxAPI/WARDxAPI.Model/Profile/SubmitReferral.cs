using EFCore.Interface;
using WARDxAPI.Model.Interface.Profile;

namespace WARDxAPI.Model.Profile
{
    public class SubmitReferral : ISubmitReferral
    {
        public string PatientName { get; set; }
        public Gender PatientGender { get; set; }
        public string GPName { get; set; }
        public string GPPracticeNumber { get; set; }
        public string SpecialistName { get; set; }
        public string SpecialistPracticeNumber { get; set; }
        public bool isValid { get; set; }
    }
}
