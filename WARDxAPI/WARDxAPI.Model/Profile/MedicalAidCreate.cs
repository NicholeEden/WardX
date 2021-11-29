using EFCore.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Profile;
using WARDxAPI.Model.Shared;

namespace WARDxAPI.Model.Profile
{
    public class MedicalAidCreate : IMedicalAidCreate
    {
        public Dictionary<string, string> SchemeList { get; set; }
        public Dictionary<string, string> PlanList { get; set; }
        public IStatusBoxModel Status { get; set; } = new StatusBoxModel
        {
            SectionName = "Medical Aid Information"
        };

        [Required,
            Display(Name = "Medical Aid Scheme")]
        public MedicalAidSchemes MedicalAidSchemeID { get; set; }

        [Required,
            Display(Name = "Medical Aid Plan")]
        public MedicalAidPlans MedicalAidPlanID { get; set; }

        [Required,
            MaxLength(128),
            Display(Name = "Member Number")]
        public string MemberNumber { get; set; }

        [Required,
            MaxLength(1024),
            Display(Name = "Principal First Name")]
        public string PrincipalFirstName { get; set; }

        [Required,
            MaxLength(1024),
            Display(Name = "Principal Last Name")]
        public string PrincipalLastName { get; set; }

        [Required,
            MaxLength(128),
            Display(Name = "Dependant Code")]
        public string DependantCode { get; set; }

        public int PatientID { get; set; }
    }
}
