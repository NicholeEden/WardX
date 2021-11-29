using EFCore.Interface;
using System;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class NurseInspection : INurseInspection
    {
        [Key]
        public int NurseInspectionID { get; set; }

        public Nurse Nurse { get; set; }

        public Patient Patient { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [MaxLength(1024)]
        [Required]
        public string Comments { get; set; }

        [Required]
        public int NurseID { get; set; }

        [Required]
        public int PatientID { get; set; }
    }
}
