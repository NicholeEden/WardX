using EFCore.Interface;
using System;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class PatientVital : IPatientVital
    {
        [Key]
        public int VitalSignID { get; set; }

        [Required]
        public int AdmisssionFileID { get; set; }

        public AdmissionFile AdmissionFile { get; set; }

        [Required]
        public DateTime DateRecorded { get; set; }
    }
}
