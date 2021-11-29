using System;

namespace EFCore.Interface
{
    /// <summary>
    /// Defines the database fields present in the Referral table
    /// </summary>
    public interface IReferral
    {
        int ReferralID { get; set; }
        int PatientID { get; set; }
        int DiagnosisID { get; set; }

        /// <summary>
        /// Defines the DoctorID for ward specialists
        /// </summary>
        int SpecialistID { get; set; }

        /// <summary>
        /// Defines the DoctorID for the General Practitioner
        /// </summary>
        int ReferringDoctorID { get; set; }
        string Reason { get; set; }

        /// <summary>
        /// Defines the latest date for admission
        /// </summary>
        DateTime AdmissionDate { get; set; }

        /// <summary>
        /// Defines whether the referral has been processed
        /// </summary>
        bool isAdmitted { get; set; }
    }
}
