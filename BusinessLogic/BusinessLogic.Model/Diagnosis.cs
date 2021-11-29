using EFCore.Interface;
using System;

namespace BusinessLogic.Model
{
    public class Diagnosis : IDiagnosis
    {
        public int DiagnosisID { get; set; }
        public int MedicalConditionID { get; set; }
        public int DiagnosedBy { get; set; }
        public string DiagnosisDetals { get; set; }
        public DateTime DiagnosisDate { get; set; }
    }
}
