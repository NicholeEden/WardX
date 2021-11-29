using EFCore.Interface;
using System;

namespace BusinessLogic.Model
{
    public class Patient : IPatient
    {
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string IDNumber { get; set; }
        public DateTime DOB { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int SuburbID { get; set; }
    }
}
