using System.Collections.Generic;

namespace BusinessLogic.Interface
{
    /// <summary>
    /// Provides a Dictionary object from a DataTable
    /// </summary>
    public interface IDropdownProcessor
    {
        /// <summary>
        /// Returns a list where SuburbID is the key and SuburbName is the value
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> GetSuburbs();

        /// <summary>
        /// Returns a list where MedicalAidSchemeID is the key and Name is the value
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> GetMedicalAidSchemes();

        /// <summary>
        /// Returns a list where MedicalAidPlanID is the key and Name is the value
        /// </summary>
        Dictionary<string, string> GetMedicalAidPlans();

        /// <summary>
        /// Returns a list where DoctorID is the key and Name is the value
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> GetGPDoctorList();

        /// <summary>
        /// Returns a list where DoctorID is the key and Name is the value
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> GetSpecialistDoctorList();

        /// <summary>
        /// Returns a list where MedicalConditionID is the key and Name is the value
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> GetMedicalConditionList();

        /// <summary>
        /// Returns a list where AdmissionFileID is the key and Name is the value
        /// </summary>
        /// <returns></returns>

        Dictionary<string, string> GetAdmissionFileList();

        /// <summary>
        /// Returns a list where BedID is the key and Name is the value
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> GetBeds();

        /// <summary>
        /// Returns a list where PrescriptionID is the key and Name is the value
        /// </summary>
        /// <returns></returns>

        Dictionary<string, string> GetPrescriptionList();

        /// <summary>
        /// Returns a list where PatientID is the key and Name is the value
        /// </summary>
        /// <returns></returns>

        Dictionary<string, string> GetPatientList();

        Dictionary<string, string> GetNurseList();


       
    }
}
