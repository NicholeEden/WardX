namespace EFCore.Interface
{
    public interface IEmergencyContact
    {
        int EmergencyContactID { get; set; }
        int PatientID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Relationship { get; set; }
        string EmailAddress { get; set; }
        string MobileNumber { get; set; }
        string AddressLine1 { get; set; }
        string AddressLine2 { get; set; }
        int SuburbID { get; set; }
    }
}
