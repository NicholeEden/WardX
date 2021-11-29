using EFCore.Interface;
using System.Data;

namespace DataAccess.Interface.Integration
{
    public interface IPatientMethods
    {
        /// <summary>
        /// Returns the Patient values
        /// </summary>
        /// <returns></returns>
        DataTable GetAll_Patient();

        /// <summary>
        /// Returns the Patient values that have no active referrals
        /// </summary>
        /// <returns></returns>
        DataTable Get_PatientNoReferral();

        /// <summary>
        /// Returns the Patient referral history
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        DataTable Get_PatientReferralTimeline(int patientID);

        /// <summary>
        /// Returns the Patient treatment history
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        DataTable Get_PatientTreatmentTimeline(int patientID);

        /// <summary>
        /// Returns the Patient values based on the Patient ID
        /// </summary>
        /// <returns></returns>
        DataTable Get_Patient(int patientID);

        /// <summary>
        /// Returns the Patient values based on the Patient name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        DataTable Get_Patient(string name);

        /// <summary>
        /// Inserts a new Patient entry
        /// </summary>
        /// <returns></returns>
        int Add_Patient(IPatient patient);

        /// <summary>
        /// Updates a Patient entry
        /// </summary>
        /// <returns></returns>
        int Update_Patient(IPatient patient);
    }
}
