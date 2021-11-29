using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Profile;
using WARDxAPI.Model.Shared;

namespace WARDxAPI.Model.Profile
{
    public class PatientCreate : IPatientCreate
    {
        public Dictionary<string, string> SuburbList { get; set; }
        public int PatientID { get; set; }

        [Required,
            MaxLength(128),
            Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required,
            MaxLength(128),
            Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required,
            MinLength(13, ErrorMessage = "ID Number must be 13 characters"),
            MaxLength(13, ErrorMessage = "ID Number must be 13 characters"),
            Display(Name = "ID Number")]
        public string IDNumber { get; set; }

        public DateTime DOB
        {
            get
            {
                // returns the value in 'DOBinput'
                return Convert.ToDateTime(DOBinput);
            }
            set
            {
                DOB = value;
            }
        }

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
            Display(Name = "Address Line 2 (optional)")]
        public string AddressLine2 { get; set; }

        [Required,
            Range(101,int.MaxValue),
            Display(Name = "Suburb")]
        public int SuburbID { get; set; }

        [Required,
            RegularExpression(pattern: @"^(0[1-9]|[12][0-9]|3[01])[ /.](0[1-9]|1[012])[ /.](19|20)\d\d$",
            ErrorMessage = "Please enter a valid date"),
            Display(Name = "Date of Birth")]
        public string DOBinput { get; set; }

        public IStatusBoxModel Status { get; set; } = new StatusBoxModel 
        { 
            SectionName = "Personal Information" 
        };
    }
}
