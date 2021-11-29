using EFCore.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class Doctor : IDoctor
    {
        [Key]
        public int DoctorID { get; set; }

        [Required]
        public Specializations SpecializationID { get; set; }

        [Required]
        public DoctorTypes DoctorTypeID { get; set; }

        [Required, MaxLength(128)]
        public string PracticeNumber { get; set; }

        #region Entity Framework
        public StaffMember IsStaffMember { get; set; }
        public Specialization Specialization { get; set; }
        public DoctorType DoctorType { get; set; }
        public List<Prescription> Prescriptions { get; set; }
        public List<DoctorInspection> DoctorInspection { get; set; }
        public List<AdmissionFile> AdmissionFiles { get; set; }
        public List<Referral> Referrals { get; set; }
        #endregion
    }
}
