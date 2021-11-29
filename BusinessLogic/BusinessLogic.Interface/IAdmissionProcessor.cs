using BusinessLogic.Model;
using EFCore.Interface;
using System.Collections.Generic;

namespace BusinessLogic.Interface
{
    /// <summary>
    /// This interface defines all the methods required in the admission process
    /// </summary>
    public interface IAdmissionProcessor
    {
        /// <summary>
        /// Returns all referral entries from the database
        /// </summary>
        /// <returns></returns>
        List<Referral> GetReferrals(bool isAdmitted);

        /// <summary>
        /// Returns all AdmissionFile entries from the database
        /// </summary>
        /// <returns></returns>
        List<AdmissionFile> GetAdmissionFiles();

        /// <summary>
        /// Returns an AdmissionFile entire for a specific patient from the database
        /// </summary>
        /// <returns></returns>
        AdmissionFile GetAdmissionFile(int patientID);

        /// <summary>
        ///  Returns an AdmissionFile entire for a specific patient from the database
        /// </summary>
        /// <param name="admissionFileID"></param>
        /// <returns></returns>
        AdmissionFile GetAdmissionFileByadmissionID(int admissionFileID);

        /// <summary>
        /// Creates a new admissionFile by add an entry to the respective table
        /// </summary>
        /// <param name="admissionFile"></param>
        /// <returns></returns>
        ProcessResult CreateAdmission(IAdmissionFile admissionFile, int bedID, bool isAvailable, int referralID, bool isAdmitted);

        /// <summary>
        /// Updates a new admissionFile by updating an entry to the respective table
        /// </summary>
        /// <param name="admissionFile"></param>
        /// <returns></returns>
        ProcessResult UpdateAdmission(IAdmissionFile admissionFile, int bedID, bool isAvailable);

        ProcessResult UpdateAdmissionWithDischarge(IAdmissionFile admissionFile, int bedID, bool isAvailable);

        /// <summary>
        /// Returns all bed entries from the database
        /// </summary>
        /// <returns></returns>
        List<Bed> GetAllBeds();

        /// <summary>
        /// Returns all available bed entries from the database
        /// </summary>
        /// <returns></returns>
        List<Bed> GetAllAvailableBeds(bool isAvailable);

        /// <summary>
        /// Returns all prescription entries from the database
        /// </summary>
        /// <returns></returns>
        List<Prescription> GetPrescriptions();

        Prescription GetPrescription(int patient);

    }
}
