using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Admission;

namespace WARDxAPI.Model.Admission
{
    public class PatientAdmissionFileUpdate : IPatientAdmissionFileUpdate
    {
        public int AdmissionFileID { get; set; }
        public int PatientID { get; set; }
        public DateTime AdmissionDate { get; set; }
        public int AssignedSpecialistID { get; set; }
        public DateTime? DischargeDate { get; set; }

        [Required,
            Range(101, int.MaxValue),
            Display(Name = "Bed")]
        public int BedID { get; set; }
        public int? PrescriptionID { get; set; }

        [MaxLength(1024),
            Display(Name = "Notes")]
        public string Notes { get; set; }


        [MaxLength(128),
            Display(Name = "Patient Name")]
        public string PatientName { get; set; }

        [MaxLength(128),
            Display(Name = "Specialist Name")]
        public string SpecialistName { get; set; }
        public List<ISelectOption> BedList { get; set; }

    }
}
