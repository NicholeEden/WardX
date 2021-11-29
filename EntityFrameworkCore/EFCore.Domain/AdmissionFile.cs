using EFCore.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Domain
{
    public class AdmissionFile : IAdmissionFile
    {
        [Key]
        public int AdmissionFileID { get; set; }

        [Required, ForeignKey(nameof(Domain.Patient))]
        public int PatientID { get; set; }

        [Required]
        public DateTime AdmissionDate { get; set; }

        [Required, ForeignKey(nameof(Domain.Doctor))]
        public int AssignedSpecialistID { get; set; }

        
        public DateTime? DischargeDate { get; set; }

        [Required, ForeignKey(nameof(Domain.Bed))]
        public int BedID { get; set; }

        [ForeignKey(nameof(Domain.Prescription))]
        public int? PrescriptionID { get; set; }

        [MaxLength(1024)]
        public string Notes { get; set; }

        #region Entity Framework
        public Bed Bed { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public Prescription Prescription { get; set; }
        #endregion
    }
}
