using EFCore.Interface;

namespace WARDxAPI.Model.Shared
{
    public class NurseDetail : INurse, IStaffMember, INurseType, ISpecialization
    {
        public int SpecializationID { get; set; }
        public string Description { get; set; }
        public int NurseTypeID { get; set; }
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
        public int NurseID { get; set; }
        public bool isWardManager { get; set; }
        public bool isHeadNurse { get; set; }
    }
}
