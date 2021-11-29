using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Interface
{
    public interface IClocking
    {
        int ClockingID { get; set; }
        int NurseID { get; set; }
        DateTime ClockInTime { get; set; }
        DateTime ClockOutTime { get; set; }
        bool  isClockedIn { get; set; }

    }
}
