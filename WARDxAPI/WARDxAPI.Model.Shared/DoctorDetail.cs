using System;
using System.Collections.Generic;
using System.Text;
using EFCore.Interface;

namespace WARDxAPI.Model.Shared
{
    public class DoctorDetail : IDoctor, IStaffMember
    {
        public int DoctorID { get; set ; }
        public Specializations SpecializationID { get ; set ; }
        public DoctorTypes DoctorTypeID { get ; set ; }
        public string PracticeNumber { get ; set ; }
        public int StaffID { get ; set ; }
        public string FirstName { get ; set ; }
        public string LastName { get ; set ; }
        public Gender Gender { get ; set; }
        public string EmployeeID { get ; set; }
        public string EmailAddress { get; set ; }
        public string AddressLine1 { get ; set ; }
        public string AddressLine2 { get ; set ; }
        public int SuburbID { get ; set ; }
        public string WorkNumber { get; set ; }
        public string MobileNumber { get ; set ; }
        public bool isActive { get ; set ; }
        public StaffType StaffType { get ; set ; }
        public int UserID { get ; set ; }
    }
}
