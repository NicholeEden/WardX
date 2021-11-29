using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class Patient : IPatient
    {
        [Key]
        public int PatientID { get; set; }

        [Required, MaxLength(128)]
        public string FirstName { get; set; }

        [Required, MaxLength(128)]
        public string LastName { get; set; }

        [Required, MaxLength(13)]
        public string IDNumber { get; set; }

        [Required]
        public DateTime DOB { get; set; }

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

        [Required]
        public Gender Gender { get; set; }

        #region EntityFramework
        public Suburb Suburb { get; set; }
        public EmergencyContact EmergencyContact { get; set; }
        public NextOfKin NextOfKin { get; set; }
        public List<AdmissionFile> AdmissionFiles { get; set; }
        public List<MedicalHistory> MedicalHistory { get; set; }
        public MedicalAid MedicalAid { get; set; }
        public List<DoctorInspection> DoctorInspection { get; set; }
        public List<NurseInspection> NurseInspection { get; set; }
        #endregion

    }
}
