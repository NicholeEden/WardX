using EFCore.Interface;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class MedicalHistory : IMedicalHistory
    {
        [Key]
        public int PatientID { get; set; }

        [Required, MaxLength(1024)]
        public string Diagnosis { get; set; }

        [Required, MaxLength(1024)]
        public string ExistingCondition { get; set; }

        [Required]
        public double BMI { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required, MaxLength(50)]
        public string Allergies { get; set; }
       
        [Required]
        public int BloodGroupID { get; set; }
        public BloodGroup BloodGroup { get; set; }

        public Patient Patient { get; set; }

    }
}
