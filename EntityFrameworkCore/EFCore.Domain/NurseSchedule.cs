using EFCore.Interface;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class NurseSchedule : INurseSchedule
    {
        [Key]
        public int ScheduleID { get; set; }

        [Required]
        public bool isAvailable { get; set; }// data type is true or false

        public Nurse Nurse { get; set; }

        public Month Month { get; set; }

        [Required]
        public int ShiftSlotID { get; set; }

        public ShiftSlot ShiftSlot { get; set; }

        [Required]
        public int NurseID { get; set; }

        [Required]
        public int MonthID { get; set; }
    }
}
