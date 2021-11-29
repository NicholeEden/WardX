using System;

namespace EFCore.Interface
{
    /// <summary>
    /// Defines the database fields present in the Diagnosis table
    /// </summary>
    public interface IDiagnosis
    {
        int DiagnosisID { get; set; }
        int MedicalConditionID { get; set; }

        /// <summary>
        /// Defines the DoctorID for the General Practitioner
        /// </summary>
        int DiagnosedBy { get; set; }
        string DiagnosisDetals { get; set; }
        DateTime DiagnosisDate { get; set; }
    }
}
