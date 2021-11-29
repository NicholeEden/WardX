namespace EFCore.Interface
{
    /// <summary>
    /// Defines the database fields present in the Staff Member table
    /// </summary>
    public interface IStaffMember
    {
        int StaffID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        Gender Gender { get; set; }
        string EmployeeID { get; set; }
        string EmailAddress { get; set; }
        string AddressLine1 { get; set; }
        string AddressLine2 { get; set; }
        int SuburbID { get; set; }
        string WorkNumber { get; set; }
        string MobileNumber { get; set; }
        bool isActive { get; set; }
        StaffType StaffType { get; set; }
        int UserID { get; set; }
    }
}
