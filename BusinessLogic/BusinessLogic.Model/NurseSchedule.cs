using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Model
{
    public class NurseSchedule : INurseSchedule
    {
        public int ScheduleID { get; set; }
        public bool isAvailable { get; set; }
        public int NurseID { get; set; }
        public int MonthID { get; set; }
        public int ShiftSlotID { get; set; }

    }
}
