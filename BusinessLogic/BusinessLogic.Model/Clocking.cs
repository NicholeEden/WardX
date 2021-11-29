using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Model
{
    public class Clocking : IClocking
    {
        public int ClockingID { get; set; }
        public int NurseID { get; set; }

        public DateTime ClockInTime { get; set; }

        public DateTime ClockOutTime { get; set; }
        public bool isClockedIn { get; set; }


    }
}
