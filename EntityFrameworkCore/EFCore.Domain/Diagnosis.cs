using EFCore.Interface;
using System;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class Diagnosis : IDiagnosis
    {
        [Key]
        public int DiagnosisID { get; set; }

        [Required]
        public int MedicalConditionID { get; set; }
        public MedicalCondition MedicalCondition { get; set; }

        [Required]
        public int DiagnosedBy { get; set; }

        [Required, MaxLength(1024)]
        public string DiagnosisDetals { get; set; }

        [Required]
        public DateTime DiagnosisDate { get; set; }
    }
}
