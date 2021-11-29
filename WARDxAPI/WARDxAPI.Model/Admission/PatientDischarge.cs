using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Admission;

namespace WARDxAPI.Model.Admission
{
    public class PatientDischarge : IPatientDischarge
    {


        public int AdmissionFileID { get; set; }

        [MaxLength(128),
            Display(Name = "Patient Name")]
        public string PatientName { get; set; }

        public int PatientID { get; set; }
        public DateTime AdmissionDate { get; set; }
        public int AssignedSpecialistID { get; set; }
        public DateTime? DischargeDate { get; set; }

        public int BedID { get; set; }

        public int? PrescriptionID { get; set; }
        public string Notes { get; set; }
    }
}
