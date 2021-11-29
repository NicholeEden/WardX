using EFCore.Interface;
using System;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class PatientMovement : IPatientMovement
    {
        [Key]
        public int PatientMovementID { get; set; }

        [Required]
        public int AdmissionFileID { get; set; }

        public AdmissionFile AdmissionFile { get; set; }

        [Required]
        public DateTime MoveDate { get; set; }

        public DateTime? CheckInTime { get; set; }

        [Required]
        public DateTime CheckOutTime { get; set; }

        [Required]
        public bool isCheckedOut { get; set; }

        [Required]
        
        public Reason Reason { get; set; }
    }
}
