using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Model
{
    public class AdmissionFile : IAdmissionFile
    {
        public int AdmissionFileID { get; set; }
        public int PatientID { get; set; }
        public DateTime AdmissionDate { get; set; }
        public int AssignedSpecialistID { get; set; }
        public DateTime? DischargeDate { get; set; }
        public int BedID { get; set; }
        public int? PrescriptionID { get; set; }
        public string Notes { get; set; }
    }
}
