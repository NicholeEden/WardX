using EFCore.Interface;
using System;
using System.Collections.Generic;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.StaffScheduling;

namespace WARDxAPI.Model.StaffScheduling
{
    public class GenerateTimesheet : IGenerateTimesheet
    {
        public Dictionary<string, string> NurseOptions { get; set; }
        public IList<ICardTableContent> CardTableContents { get; set; }
        public string DateRange { get; set; }
        public int ClockingID { get; set; }
        public int NurseID { get; set; }
        public DateTime ClockInTime { get; set; }
        public DateTime ClockOutTime { get; set; }
        public bool isClockedIn { get; set; }
        public Dictionary<string, string> MonthOptions { get; set; }
        public int MonthID { get; set; }
        public string MonthName { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
    }
}
