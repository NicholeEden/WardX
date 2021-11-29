using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace WARDxAPI.Model.Shared
{
    public class Timesheet : IClocking, IStaffMember, IMonth, INurseSchedule
    {
        public int StaffID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string EmployeeID { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int SuburbID { get; set; }
        public string WorkNumber { get; set; }
        public string MobileNumber { get; set; }
        public bool isActive { get; set; }
        public StaffType StaffType { get; set; }
        public int UserID { get; set; }
        public int ClockingID { get; set; }
        public int NurseID { get; set; }
        public DateTime ClockInTime { get; set; }
        public DateTime ClockOutTime { get; set; }
        public bool isClockedIn { get; set; }
        public int MonthID { get; set; }
        public string MonthName { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public int ScheduleID { get; set; }
        public bool isAvailable { get; set; }
        public int ShiftSlotID { get; set; }
    }
}
