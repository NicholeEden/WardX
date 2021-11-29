using EFCore.Interface;
using System;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class ShiftSlot : IShiftSlot
    {
        [Key]
        public int ShiftSlotID { get; set; }

        [MaxLength(1024)]
        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }
    }
}
