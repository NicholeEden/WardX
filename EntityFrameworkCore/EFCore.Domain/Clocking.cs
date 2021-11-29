using System;
using EFCore.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Domain
{
    public class Clocking: IClocking
    {
        [Key]
        public int ClockingID { get; set; }

        [Required,ForeignKey(nameof(Nurse))]
        public int NurseID { get; set; }

        [Required]
        public DateTime ClockInTime { get; set; }

        public DateTime ClockOutTime { get; set; }

        [Required]
        public bool isClockedIn { get; set; }
    }
}
