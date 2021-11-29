using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.StaffScheduling;

namespace WARDxAPI.Model.StaffScheduling
{
    public class CreateSchedule : ICreateSchedule
    {
        public Dictionary<string, string> NurseIDList { get; set; }
        public Dictionary<string, string> MonthOptions { get; set; }
        public int MonthID { get; set; }
        public string DateRange { get; set; }
        public IList<ICardTableContent> CardTableContents { get; set; }
        public Dictionary<string, string> ShiftSlotOptions { get; set; }
        public int ShiftSlotID { get; set; }

        public Dictionary<string, string> NurseOptions { get; set; }
        public int NurseID { get; set; }

        public bool isMorningShift { get; set; }
        public int ScheduleID { get; set; }
        public bool isAvailable { get; set; }
        public string MonthName { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }

}
