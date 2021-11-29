using EFCore.Interface;
using System;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class Referral : IReferral
    {
        [Key]
        public int ReferralID { get; set; }

        [Required]
        public int PatientID { get; set; }

        [Required]
        public int DiagnosisID { get; set; }

        [Required]
        public int SpecialistID { get; set; }

        [Required]
        public int ReferringDoctorID { get; set; }

        [Required, MaxLength(1024)]
        public string Reason { get; set; }

        [Required]
        public DateTime AdmissionDate { get; set; }

        #region Entity framework
        public Doctor Doctor { get; set; }
        public Diagnosis Diagnosis { get; set; }
        public Patient Patient { get; set; }
        public bool isAdmitted { get; set; }
        #endregion
    }
}
