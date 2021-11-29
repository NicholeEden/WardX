using EFCore.Interface;
using System;

namespace WARDxAPI.Model.Shared
{
    public class ScheduleDetail : IMonth, INurseSchedule, IStaffMember, IShiftSlot
    {
        public int ShiftSlotID { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MonthID { get; set; }
        public string MonthName { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public int ScheduleID { get; set; }
        public bool isAvailable { get; set; }
        public int NurseID { get; set; }
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
    }
}
