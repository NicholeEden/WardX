using EFCore.Interface;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class MedicalAid : IMedicalAid
    {
        [Required]
        public MedicalAidSchemes MedicalAidSchemeID { get; set; }
        public MedicalAidScheme MedicalAidScheme { get; set; }

        [Required]
        public MedicalAidPlans MedicalAidPlanID { get; set; }
        public MedicalAidPlan MedicalAidPlan { get; set; }

        [Required, MaxLength(128)]
        public string MemberNumber { get; set; }

        [Required, MaxLength(1024)]
        public string PrincipalFirstName { get; set; }

        [Required, MaxLength(1024)]
        public string PrincipalLastName { get; set; }

        [Required, MaxLength(128)]
        public string DependantCode { get; set; }

        [Required]
        public int PatientID { get; set; }
        public Patient Patient { get; set; }
    }
}
