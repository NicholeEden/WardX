using EFCore.Interface;
using System;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class Medication : IMedication
    {
        public int MedicationID { get; set; }

        [Required, MaxLength(1024)]
        public string MedicationName { get; set; }

        [Required]
        public int MedicationScheduleID { get; set; }
        public MedicationSchedule MedicationSchedule { get; set; }

        [Required, MaxLength(1024)]
        public string MedicationStrength { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        [Required]
        public int FormulationID { get; set; }
        public Formulation Formulation { get; set; }

        //string IMedication.MedicationStrength { get;set ; }
    }
}
