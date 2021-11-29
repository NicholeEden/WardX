using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WARDx.Data;
using WARDxAPI.Model.Interface.Treatment;

namespace WARDxAPI.Model.Treatment
{
    public class RecordPrescription : IRecordPrescription
    {
        public int PrescriptionID { get; set; }
        [Required,
            Range(101, int.MaxValue, ErrorMessage = "Invalid medication name selected")]
        public int MedicaltionID { get; set; }
        public List<SelectOption> MedicineNameList { get; set; }

        [Required,
            Range(101, int.MaxValue, ErrorMessage = "Invalid Doctor selected")]
        public int DoctorID { get; set; }
        public List<SelectOption> DoctorList { get; set; }

        public int AdmissionFileID { get; set; }

        [Required]
        public double Dosage { get; set; }
        [Required]
        public string DateIssued { get; set; }
        [Required]
        public string Instructions { get; set; }
    }
}
