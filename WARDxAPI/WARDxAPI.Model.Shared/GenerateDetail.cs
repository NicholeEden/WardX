using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace WARDxAPI.Model.Shared
{
    public class GenerateDetail : IMonth, INurse
    {
        public int MonthID { get; set; }
        public string MonthName { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public int ClockingID { get; set; }
        public int NurseID { get; set; }
        public DateTime ClockInTime { get; set; }
        public DateTime ClockOutTime { get; set; }
        public bool isClockedIn { get; set; }
        public bool isWardManager { get; set; }
        public bool isHeadNurse { get; set; }
        public int SpecializationID { get; set; }
        public int NurseTypeID { get; set; }
    }
}
