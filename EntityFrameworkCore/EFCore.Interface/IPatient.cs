using System;

namespace EFCore.Interface
{
    /// <summary>
    /// Defines the database fields present in the Patient table
    /// </summary>
    public interface IPatient
    {
        int PatientID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        Gender Gender { get; set; }
        string IDNumber { get; set; }
        DateTime DOB { get; set; }
        string EmailAddress { get; set; }
        string MobileNumber { get; set; }
        string AddressLine1 { get; set; }
        string AddressLine2 { get; set; }
        int SuburbID { get; set; }
    }
}
