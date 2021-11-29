using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Profile;
using WARDxAPI.Model.Shared;

namespace WARDxAPI.Model.Profile
{
    public class PatientReferral : IPatientReferral
    {
        public List<ISelectOption> PatientList { get; set; }
        public List<ISelectOption> SpecialistList { get; set; }
        public List<ISelectOption> GPDoctorList { get; set; }
        public int ReferralID { get; set; }

        [Required,
            Range(101, int.MaxValue),
            Display(Name = "Patient to Refer")]
        public int PatientID { get; set; }
        public int DiagnosisID { get; set; }

        [Required,
            Range(101, int.MaxValue),
            Display(Name = "Ward Specialist")]
        public int SpecialistID { get; set; }

        [Required,
            Range(101, int.MaxValue),
            Display(Name = "General Practitioner")]
        public int ReferringDoctorID { get; set; }

        [MaxLength(1024),
            Display(Name = "Referral Details (optional)")]
        public string Reason { get; set; }

        public DateTime AdmissionDate
        {
            get
            {
                // returns the value in 'DOBinput'
                return Convert.ToDateTime(DateInput);
            }
            set
            {
                AdmissionDate = value;
            }
        }

        [Required,
            RegularExpression(pattern: @"^(0[1-9]|[12][0-9]|3[01])[ /.](0[1-9]|1[012])[ /.](19|20)\d\d$",
            ErrorMessage = "Please enter a valid date"),
            Display(Name = "Date for Admission")]
        public string DateInput { get; set; }
        public bool isAdmitted { get; set; }
        public IStatusBoxModel Status { get; set; } = new StatusBoxModel
        {
            SectionName = "Referral Information"
        };
    }
}
