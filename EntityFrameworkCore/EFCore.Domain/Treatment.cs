using EFCore.Interface;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class Treatment : ITreatment
    {
        [Key]
        public int TreatmentID { get; set; }

        [Required]
        public int NurseID { get; set; }

        [Required]
        public int PatientID { get; set; }

        [Required]
        public int TreatmentTypeID { get; set; }

        [Required, MaxLength(1024)]
        public string ObservationNotes { get; set; }
    }
}
