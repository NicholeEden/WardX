using EFCore.Interface;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class EmergencyContact : IEmergencyContact
    {
        [Key]
        public int EmergencyContactID { get; set; }

        [Required]
        public int PatientID { get; set; }
        public Patient Patient { get; set; }

        [Required, MaxLength(1024)]
        public string FirstName { get; set; }

        [Required, MaxLength(1024)]
        public string LastName { get; set; }

        [Required, MaxLength(128)]
        public string Relationship { get; set; }

        [Required, MaxLength(1024)]
        public string EmailAddress { get; set; }

        [Required, MaxLength(10)]
        public string MobileNumber { get; set; }

        [Required, MaxLength(1024)]
        public string AddressLine1 { get; set; }

        [MaxLength(1024)]
        public string AddressLine2 { get; set; }

        [Required]
        public int SuburbID { get; set; }
        public Suburb Suburb { get; set; }
    }
}
