using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Model
{
    public class StaffMember : IStaffMember
    {
        public int StaffID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeID { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }
        public int SuburbID { get; set; }
        public string WorkNumber { get; set; }

        public string MobileNumber { get; set; }
        public bool isActive { get; set; }
        public int UserID { get; set; }
        public StaffType StaffType { get; set; }
        public Gender Gender { get; set; }
    }
}
