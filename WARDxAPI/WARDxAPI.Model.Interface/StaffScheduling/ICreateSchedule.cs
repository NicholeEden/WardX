using EFCore.Interface;
using System;
using System.Collections.Generic;

namespace WARDxAPI.Model.Interface
{
    public interface ICreateSchedule : INurseSchedule, IMonth, IShiftSlot
    {
        Dictionary<string, string> NurseIDList { get; set; }
        bool isMorningShift { get; set; }
        Dictionary<string, string> MonthOptions { get; set; }
        Dictionary<string, string> ShiftSlotOptions { get; set; }
        Dictionary<string, string> NurseOptions { get; set; }
        IList<ICardTableContent> CardTableContents { get; set; }
    }
}
