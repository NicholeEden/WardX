using EFCore.Interface;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class DoctorSchedule : IDoctorSchedule
    {
        [Key]
        public int ScheduleID { get; set; }

        public Doctor Doctor { get; set; }

        public Month Month { get; set; }

        [Required]
        public int ShiftSlotID { get; set; }

        public ShiftSlot ShiftSlot { get; set; }

        [Required]
        public bool isAvailable { get; set; }

        [Required]
        public int DoctorID { get; set; }

        [Required]
        public int MonthID { get; set; }
    }
}
