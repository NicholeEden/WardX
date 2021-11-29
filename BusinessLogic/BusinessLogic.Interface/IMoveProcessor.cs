using BusinessLogic.Model;
using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interface
{/// <summary>
 ///   Defines the methods for processing 'Patient Movement' information
 /// </summary>
    public interface IMoveProcessor
    {

        /// <summary>
        /// Returns all PatientMovement entries from the database
        /// </summary>
        /// <returns></returns>
        List<PatientMovement> GetPatientMovements();
        
        /// <summary>
        /// Creates a new patientmovement checkout entry by adding an entry to the respective table
        /// </summary>
        /// <param name="patientMovement"></param>
        /// <returns></returns>
        ProcessResult AddCheckOut(IPatientMovement patientMovement);

        /// <summary>
        /// Updates a patientmovement checkout entry by updating a entry in the respective table
        /// </summary>
        /// <param name="patientMovement"></param>
        /// <returns></returns>
        void UpdateCheckOut(IPatientMovement patientMovement);

        /// <summary>
        ///  Returns the all the matching database entries as a list of 'IPatientMovement' objects
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        List<PatientMovement> GetDateRangeReport(IPatient patient, DateTime startDate, DateTime endDate);

        /// <summary>
        ///  Returns the all the matching database entries as a list of 'IPatientMovement' objects
        /// </summary>
        /// <param name="reason"></param>
        /// <returns></returns>
        List<PatientMovement> GetPatientMovementByReason(int reason);

        /// <summary>
        /// Return all patientmovement objects as list passed by isCheckedOut parameter
        /// </summary>
        /// <param name="isCheckedOut"></param>
        /// <returns></returns>
        List<PatientMovement> GetCheckOutStatusList(bool isCheckedOut);

        PatientMovement GetPatientMovementFile(int patientMoveID);

        /// <summary>
        /// Returns a list of late patients
        /// </summary>
        /// <param name="latetime"></param>
        /// <param name="isCheckedOut"></param>
        /// <returns></returns>
        List<PatientMovement> GetNotifications(DateTime latetime, bool isCheckedOut);


        
    }
}
