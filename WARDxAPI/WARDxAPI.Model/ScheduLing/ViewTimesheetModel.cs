using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WARDx.Data;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.StaffScheduling;
using WARDxAPI.Model.StaffScheduling;

namespace WARDxAPI.Model.StaffScheduling
{
    public class ViewTimesheetModel : IViewTimesheetModel, IClocking, IStaffMember
    {
        [Required,
            Range(101, int.MaxValue),
            Display(Name = "Nurse")]
        public int NurseID { get; set; }
        public Dictionary<string, string> NurseOptions { get; set; }
        [Required,
            Range(101, int.MaxValue),
            Display(Name = "Month")]
        public int MonthID { get; set; }
        public Dictionary<string, string> MonthOptions { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<TableContent> TableContents { get; set; }

        #region Database Properties
        public IViewTimesheet ViewTimesheet { get; set; }
        public IAlertModel alertModel { get; set; }

        public int ClockingID { get; set; }
        public DateTime ClockInTime { get; set; }
        public DateTime ClockOutTime { get; set; }
        public bool isClockedIn { get; set; }
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
        
        #endregion


    }
}
