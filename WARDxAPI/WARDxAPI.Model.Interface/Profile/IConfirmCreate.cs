using EFCore.Interface;

namespace WARDxAPI.Model.Interface.Profile
{
    /// <summary>
    /// Defines the properties for the Profile/Create - Confirm view
    /// </summary>
    public interface IConfirmCreate
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
        /// Defines the Next of Kin full name
        /// </summary>
        string KinName { get; set; }

        /// <summary>
        /// Defines the Next of Kin gender
        /// </summary>
        Gender KinGender { get; set; }

        /// <summary>
        /// Defines the relationship shared with the patient
        /// </summary>
        string Relationship { get; set; }

        /// <summary>
        /// Defines the medical aid scheme name
        /// </summary>
        string MedicalAidScheme { get; set; }

        /// <summary>
        /// Defines the medical aid plan name
        /// </summary>
        string MedicalAidPlan { get; set; }

        /// <summary>
        /// Defines the confirmation status
        /// </summary>
        bool isValid { get; set; }
    }
}
