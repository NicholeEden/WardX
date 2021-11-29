using EFCore.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Domain
{
    public class Prescription : IPrescription
    {
        [Key]
        public int PrescriptionID { get; set; }

        [Required]
        public int MedicationID { get; set; }

        [Required, ForeignKey(nameof(Domain.Doctor))]
        public int DoctorID { get; set; }

        [Required]
        public double Dosage { get; set; }

        [Required]
        public DateTime DateIssued { get; set; }

        [Required, MaxLength(1024)]
        public string Instruction { get; set; }

        #region Entity Framework
        public Doctor Doctor { get; set; }
        #endregion
    }
}
