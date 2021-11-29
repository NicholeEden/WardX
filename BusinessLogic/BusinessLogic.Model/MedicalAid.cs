using EFCore.Interface;

namespace BusinessLogic.Model
{
    public class MedicalAid : IMedicalAid
    {
        public MedicalAidSchemes MedicalAidSchemeID { get; set; }
        public MedicalAidPlans MedicalAidPlanID { get; set; }
        public string MemberNumber { get; set; }
        public string PrincipalFirstName { get; set; }
        public string PrincipalLastName { get; set; }
        public string DependantCode { get; set; }
        public int PatientID { get; set; }
    }
}
