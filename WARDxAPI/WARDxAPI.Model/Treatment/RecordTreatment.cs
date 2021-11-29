using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WARDx.Data;
using WARDxAPI.Model.Interface.Treatment;

namespace WARDxAPI.Model.Treatment
{
    public class RecordTreatment : IRecordTreatment
    {
        [Required,
            Range(101, int.MaxValue, ErrorMessage = "Invalid nurse selected")]
        public int NurseID { get; set; }

        [Required,
            Range(101, int.MaxValue, ErrorMessage = "Invalid patient selected"),
            Display(Name = "Patient Name")]
        public int PatientID { get; set; }

        [Required,
            Range(101, int.MaxValue, ErrorMessage = "Invalid treatment type selected")]
        public int TreatmentTypeID { get; set; }

        public string ObservationNotes { get; set; }
        public List<SelectOption> TreatmentTypeList { get; set; }
        public List<SelectOption> NurseList { get; set; }
        public Dictionary<string, string> PatientList { get; set; }
        public int TreatmentID { get; set; }
    }
}
