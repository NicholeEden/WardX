using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WARDxAPI.Model.Shared
{
    public class PatientTreatmentModel
    {
        public Dictionary<string, string> NurseOptions { get; set; }
        [Required,
            Range(101, int.MaxValue),
            Display(Name = "Treated by:")]
        public int NurseID { get; set; }
        public Dictionary<string, string> PatientOptions { get; set; }
        [Required,
            Range(101, int.MaxValue),
            Display(Name = "Treatment for:")]
        public int PatientID { get; set; }
        public Dictionary<string, string> TreatmentTypeOptions { get; set; }
        [Required,
            Range(101, int.MaxValue),
            Display(Name = "Treatment Type:")]
        public int TreatmentTypeID { get; set; }

        [MaxLength(1024),
            Display(Name = "Observation Notes (Optional)")]
        public string ObservationNotes { get; set; }
    }
}
