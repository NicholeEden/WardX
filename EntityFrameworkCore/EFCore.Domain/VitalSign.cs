using EFCore.Interface;
using System;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class VitalSign : IVitalSign
    {
        [Key]
        public int VitalSignID { get; set; }

        [Required]
        public int BloodGroupID { get; set; }
        public BloodGroup BloodGroup { get; set; }

        [Required]
        public DateTime DateRecorded { get; set; }

        [Required]
        [MaxLength(50)]
        public string Hypoglycemia { get; set; }

        [Required]
        [MaxLength(50)]
        public string BodyTemperature { get; set; }

        [Required]
        [MaxLength(50)]
        public string PulseRate { get; set; }

        [Required]
        [MaxLength(50)]
        public string BloodPressure { get; set; }

        [Required]
        [MaxLength(50)]
        public string Weight { get; set; }

        [Required]
        [MaxLength(50)]
        public string BMI { get; set; }
    }
}
