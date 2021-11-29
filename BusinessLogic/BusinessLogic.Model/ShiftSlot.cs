using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Model
{
    public class ShiftSlot : IShiftSlot
    {
        public int ShiftSlotID { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
