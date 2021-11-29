using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace WARDxAPI.Model.Shared
{
    public class PrescriptionDetail : IPrescription, IMedication, IAdmissionFile
    {
        public int PrescriptionID { get ; set ; }
        public int MedicationID { get ; set ; }
        public int DoctorID { get ; set ; }
        public double Dosage { get ; set ; }
        public DateTime DateIssued { get ; set ; }
        public string Instruction { get ; set ; }
        public string MedicationName { get ; set ; }
        public int MedicationScheduleID { get ; set ; }
        public string MedicationStrength { get ; set ; }
        public DateTime ExpiryDate { get ; set ; }
        public int FormulationID { get; set ; }
        public int AdmissionFileID { get ; set ; }
        public int PatientID { get ; set ; }
        public DateTime AdmissionDate { get ; set ; }
        public int AssignedSpecialistID { get ; set ; }
        public DateTime? DischargeDate { get ; set ; }
        public int BedID { get ; set ; }
        public string Notes { get ; set ; }
        int? IAdmissionFile.PrescriptionID { get ; set ; }
    }
}
