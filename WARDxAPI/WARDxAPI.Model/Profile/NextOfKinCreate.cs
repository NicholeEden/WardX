using EFCore.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Profile;
using WARDxAPI.Model.Shared;

namespace WARDxAPI.Model.Profile
{
    public class NextOfKinCreate : INextOfKinCreate
    {
        public Dictionary<string, string> SuburbList { get; set; }
        public IStatusBoxModel Status { get; set; } = new StatusBoxModel
        {
            SectionName = "Next of Kin Information"
        };
        public int NextOfKinID { get; set; }
        public int PatientID { get; set; }

        [Required,
            MaxLength(1024),
            Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required,
            MaxLength(1024),
            Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required,
            MaxLength(128),
            Display(Name = "Relationship")]
        public string Relationship { get; set; }

        [Required,
            MaxLength(1024),
            DataType(DataType.EmailAddress),
            Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required,
            MinLength(10),
            MaxLength(10),
            DataType(DataType.PhoneNumber),
            Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [Required,
            MaxLength(1024),
            Display(Name = "Address")]
        public string AddressLine1 { get; set; }

        [MaxLength(1024),
            Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Required,
            Range(101, int.MaxValue),
            Display(Name = "Suburb")]
        public int SuburbID { get; set; }
    }
}
