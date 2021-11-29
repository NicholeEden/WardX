using System;

namespace EFCore.Interface
{
    public interface IShiftSlot
    {
        int ShiftSlotID { get; set; }
        string Description { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
    }
}
