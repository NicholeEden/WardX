using EFCore.Interface;
using System;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class DoctorInspection : IDoctorInspection
    {
        [Key]
        public int DoctorInspectionID { get; set; }// surrogate key to remove delete constraints

        public Doctor Doctor { get; set; }

        public Patient Patient { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [MaxLength(1024)]
        [Required]
        public string Comments { get; set; }

        [Required]
        public int DoctorID { get; set; }

        [Required]
        public int PatientID { get; set; }
    }
}
