using BusinessLogic.Model;
using EFCore.Interface;

namespace WARDxAPI.Model.Interface.Profile
{
    /// <summary>
    /// This interface defines the profile of the patient
    /// </summary>
    public interface IPatientInfo
    {
        IPatient Patient { get; set; }
        INextOfKin NextOfKin { get; set; }
        IMedicalAid MedicalAid { get; set; }
        IMedicalAidPlan MedicalAidPlan { get; set; }
        IMedicalAidScheme MedicalAidScheme { get; set; }
        IDiagnosis Diagnosis { get; set; }
        IMedicalCondition MedicalCondition { get; set; }
        Doctor GPDoctor { get; set; }
        Doctor Specialist { get; set; }
        ISuburb PatientSuburb { get; set; }
        ISuburb KinSuburb { get; set; }
        /// <summary>
        /// The email address
        /// </summary>
        string EmailAddress { get; set; }
        /// <summary>
        /// The email header content
        /// </summary>
        string EmailHeader { get; set; }
        /// <summary>
        /// The email body content
        /// </summary>
        string EmailBody { get; set; }
        /// <summary>
        /// The Patient ID to reload the page
        /// </summary>
        int ReturnID { get; set; }
    }
}