using EFCore.Interface;
using System;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class ProcedureHistory : IProcedureHistory
    {
        [Key]
        public int ProcedureID { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public DateTime Time { get; set; }

        public Patient Patient { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Notes { get; set; }

        [Required]
        public DateTime AppointmentTime { get; set; }

        [Required]
        [MaxLength(1024)]
        public string ProcedureDescription { get; set; }

        [Required]
        public int PatientID { get; set; }
    }
}
