using EFCore.Interface;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class MedicalAidPlan : IMedicalAidPlan
    {
        [Key]
        public int MedicalAidPlanID { get; set; }

        [Required, MaxLength(1024)]
        public string Name { get; set; }
    }
}
