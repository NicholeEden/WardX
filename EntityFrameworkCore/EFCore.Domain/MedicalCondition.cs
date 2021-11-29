using EFCore.Interface;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class MedicalCondition : IMedicalCondition
    {
        [Key]
        public int MedicalConditionID { get; set; }

        [Required, MaxLength(1024)]
        public string Name { get; set; }

        [Required, MaxLength(1024)]
        public string Symptom { get; set; }
    }
}
