using EFCore.Interface;

namespace WARDxAPI.Model.Interface.Profile
{
    /// <summary>
    /// Defines the summary of the referral before submission
    /// </summary>
    public interface ISubmitReferral
    {
        /// <summary>
        /// Defines the full name of the patient
        /// </summary>
        string PatientName { get; set; }

        /// <summary>
        /// Defines the gender of the patient
        /// </summary>
        Gender PatientGender { get; set; }

        /// <summary>
        /// Defines the full name of the General Practitioner
        /// </summary>
        string GPName { get; set; }

        /// <summary>
        /// Defines the practice number of the General Practitioner
        /// </summary>
        string GPPracticeNumber { get; set; }

        /// <summary>
        /// Defines the full name of the ward Specialist
        /// </summary>
        string SpecialistName { get; set; }

        /// <summary>
        /// Defines the practice number of the ward Specialist
        /// </summary>
        string SpecialistPracticeNumber { get; set; }

        /// <summary>
        /// Defines the confirmation status
        /// </summary>
        bool isValid { get; set; }
    }
}
