namespace EFCore.Interface
{
    /// <summary>
    /// Defines the database fields present in the Next of Kin table
    /// </summary>
    public interface INextOfKin
    {
        int NextOfKinID { get; set; }
        int PatientID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        Gender Gender { get; set; }
        string Relationship { get; set; }
        string EmailAddress { get; set; }
        string MobileNumber { get; set; }
        string AddressLine1 { get; set; }
        string AddressLine2 { get; set; }
        int SuburbID { get; set; }
    }
}
