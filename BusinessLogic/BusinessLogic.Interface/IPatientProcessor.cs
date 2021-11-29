using BusinessLogic.Model;
using EFCore.Interface;
using System.Collections.Generic;

namespace BusinessLogic.Interface
{
    /// <summary>
    /// Defines the methods for processing 'Patient' information
    /// </summary>
    public interface IPatientProcessor
    {
        /// <summary>
        /// Returns the specified database entry as an 'IPatient' object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Patient GetPatient(int id);

        /// <summary>
        /// Returns the all the matching database entries as a list of 'IPatient' objects
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        List<Patient> GetPatients(string keyword);

        /// <summary>
        /// Returns the all the database entries as a list of 'IPatient' objects
        /// </summary>
        /// <returns></returns>
        List<Patient> GetPatients();

        /// <summary>
        /// Returns the all the database entries as a list of 'IPatient' objects
        /// </summary>
        /// <returns></returns>
        List<Patient> GetPatientsNoReferral();

        /// <summary>
        /// Returns the database entry as an 'INextOfKin' that matches the Patient ID
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        NextOfKin GetNextOfKin(int patientID);

        /// <summary>
        /// Returns the database entry as an 'IMedicalAid' that matches the Patient ID
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        MedicalAid GetMedicalAid(int patientID);

        /// <summary>
        /// Returns the database entry as an 'IMedicalAidPlan' that matches the Medical Aid Plan ID
        /// </summary>
        /// <param name="medicalAidPlanID"></param>
        /// <returns></returns>
        MedicalAidPlan GetAidPlan(int medicalAidPlanID);

        /// <summary>
        /// Returns the database entry as an 'IMedicalAidScheme' that matches the Medical Aid Scheme ID
        /// </summary>
        /// <param name="medicalAidSchemeID"></param>
        /// <returns></returns>
        MedicalAidScheme GetAidScheme(int medicalAidSchemeID);

        /// <summary>
        /// Returns the specified database entry as an 'ISuburb' object
        /// </summary>
        /// <param name="suburbID"></param>
        /// <returns></returns>
        Suburb GetSuburb(int suburbID);

        /// <summary>
        /// Creates a new patient profile by add an entry to each of the respective tables
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="kin"></param>
        /// <param name="medicalAid"></param>
        /// <returns></returns>
        ProcessResult CreateProfile(IPatient patient, INextOfKin kin, IMedicalAid medicalAid);

        /// <summary>
        /// Returns the specified database entry as an 'IMedicalCondition' object
        /// </summary>
        /// <param name="medicalConditionID"></param>
        /// <returns></returns>
        MedicalCondition GetMedicalCondition(int medicalConditionID);

        /// <summary>
        /// Returns the all the database entries as a list of 'IMedicalCondition' objects
        /// </summary>
        /// <returns></returns>
        List<MedicalCondition> GetMedicalConditions();

        /// <summary>
        /// Creates a new referral by adding an entry to each of the respective tables
        /// </summary>
        /// <param name="diagnosis"></param>
        /// <param name="referral"></param>
        /// <returns></returns>
        ProcessResult CreateReferral(IDiagnosis diagnosis, IReferral referral);

        /// <summary>
        /// Returns the specified database entry as an 'IDiagnosis' object
        /// </summary>
        /// <param name="diagnosisID"></param>
        /// <returns></returns>
        Diagnosis GetDiagnosis(int diagnosisID);

        /// <summary>
        /// Returns the specified database entry as an 'IReferral' object
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        Referral GetReferral(int patientID);

        /// <summary>
        /// Returns the all the database entries as a list of 'IReferral' objects
        /// </summary>
        /// <returns></returns>
        List<Referral> GetPendingReferral();

        /// <summary>
        /// Returns the list of all referrals and details
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        List<ReferralTimeline> GetReferralTimelines(int patientID);

        /// <summary>
        /// Returns the list of all treatment details
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        List<TreatmentTimeline> GetTreatmentTimelines(int patientID);
    }
}
