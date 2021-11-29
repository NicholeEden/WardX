using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess.Interface.Integration
{
   public interface IPatientMovementMethods
    {

        /// <summary>
        /// Adds a an entry to the PatientMovement Table
        /// </summary>
        /// <param name="patientMovement"></param>
        /// <returns></returns>
        int Add_PatientCheckOut(IPatientMovement patientMovement);

        /// <summary>
        /// Updates an entry in the PatientMovement Table
        /// </summary>
        /// <param name="patientMove"></param>
        /// <returns></returns>
        int Update_PatientCheckOut(IPatientMovement patientMove);

        /// <summary>
        /// Updates the checkIn time field for an entry in the PatientMovement Table
        /// </summary>
        /// <param name="patientMove"></param>
        /// <returns></returns>
        //int Update_PatientCheckInTime(IPatientMovement patientMove);


        /// <summary>
        /// Displays PatientMovement entries
        /// </summary>
        /// <returns></returns>
        DataTable GetAll_PatientMovement();

        /// <summary>
        ///  Returns PatientMovement details based on the Patient ID
        /// </summary>
        /// <param name="PatientID"></param>
        DataTable GetPatientMovementByPatientID(int PatientID);

        /// <summary>
        /// Returns PatientMovement details based on the checkout status
        /// </summary>
        /// <param name="isCheckedOut"></param>
        /// <returns></returns>

        DataTable GetPatientMovementByCheckOutStatus(bool isCheckedOut);


        /// <summary>
        /// Returns PatientMovement details for a patient based on an specified DateRange
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        DataTable GetPatientMovementByDateRange(IPatient patient, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Returns PatientMovement details based on checkout reason
        /// </summary>
        /// <param name="reason"></param>
        /// <returns></returns>
        DataTable GetPatientMovementByReason(int reason);

        /// <summary>
        /// Returns PatientMovement details based on move id
        /// </summary>
        /// <param name="moveID"></param>
        /// <returns></returns>
        DataTable GetPatientMovementByID(int moveID);

        DataTable GetNotifications(DateTime latetime, bool isCheckedOut);


    }
}
