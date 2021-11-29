using BusinessLogic.Model;
using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interface
{
    /// <summary>
    ///   Defines the methods for processing 'Patient Treatment' information
    /// </summary>
    public interface ITreatmentProcessor
    { 
        /// <summary>
        /// Creates a new precription entry  to the Prescription table
        /// </summary>
        /// <param name="prescription"></param>
        /// <returns></returns>
        ProcessResult AddPrescription(IPrescription prescription);

        /// <summary>
        /// Creates a new Treatment entry  to the Treatment table
        /// </summary>
        /// <param name="treatment"></param>
        /// <returns></returns>
        ProcessResult AddTreatment(ITreatment treatment);

        /// <summary>
        /// Creates a new vital sign entry  to the VitalSign table
        /// </summary>
        /// <param name="vitalSign"></param>
        /// <returns></returns>
        ProcessResult AddVitalSign(IVitalSign vitalSign);

        /// <summary>
        /// Returns all Prescription entries from the database
        /// </summary>
        /// <returns></returns>
        List<Prescription> GetPrescriptions();
             /// <summary>
             /// Returns a list where MedicationID is the key and MedicationName is the value
             /// </summary>
             /// <returns></returns>

        List<Medication>GetMedicationList();

        /// <summary>
        /// Returns a list where BloodGroupID is the key and Description is the value
        /// </summary>
        /// <returns></returns>

        List<BloodGroup> GetBloodGroupList();

        /// <summary>
        /// Returns a list where TreatmentTypeID is the key and Description is the value
        /// </summary>
        /// <returns></returns>

        List<TreatmentType> GetTreatmentTypeList();
        /// <summary>
        /// Returns a list where TreatmentTypeID is the key and Description is the value
        /// </summary>
        /// <returns></returns>
        List<VitalSign> GetVitals(int admissionFileNo);

    }
}
