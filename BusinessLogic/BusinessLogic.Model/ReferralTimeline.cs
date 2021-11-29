using EFCore.Interface;
using System;

namespace BusinessLogic.Model
{
    public class ReferralTimeline :
        IReferral,
        IDiagnosis
    {
        public int ReferralID { get; set; }
        public int PatientID { get; set; }
        public int DiagnosisID { get; set; }
        public int SpecialistID { get; set; }
        public int ReferringDoctorID { get; set; }
        public string Reason { get; set; }
        public DateTime AdmissionDate { get; set; }
        public bool isAdmitted { get; set; }
        public int MedicalConditionID { get; set; }
        public int DiagnosedBy { get; set; }
        public string DiagnosisDetals { get; set; }
        public DateTime DiagnosisDate { get; set; }
    }
}