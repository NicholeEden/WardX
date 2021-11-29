using DataAccess.Domain.Interface;
using EFCore.Interface;
using System;
using System.Data.SqlClient;

namespace DataAccess.Domain
{
    public class PatientMovement : IPatientMovement_DataAccess
    {
        public SqlParameter[] GetInsertParameters(IPatientMovement patientMovement)
        {
            SqlParameter[] parameters;

            parameters = new SqlParameter[]
            {
                //new SqlParameter(nameof(IPatientMovement.CheckOutTime)  , patientMovement.CheckOutTime),
               //new SqlParameter(nameof(IPatientMovement.CheckInTime)  , patientMovement.CheckInTime),
                new SqlParameter(nameof(IPatientMovement.isCheckedOut), patientMovement.isCheckedOut),
                //new SqlParameter(nameof(IPatientMovement.MoveDate), patientMovement.MoveDate),
                new SqlParameter(nameof(IPatientMovement.AdmissionFileID), patientMovement.AdmissionFileID),
                new SqlParameter(nameof(IPatientMovement.Reason), patientMovement.Reason)


            };

            return parameters;
        }

        public SqlParameter[] GetUpdateParameters(IPatientMovement patientMovement)
        {
            SqlParameter[] parameters;

            parameters = new SqlParameter[]
            {
                 new SqlParameter( nameof(IPatientMovement.PatientMovementID) , patientMovement.PatientMovementID),
                  new SqlParameter(nameof(IPatientMovement.AdmissionFileID), patientMovement.AdmissionFileID),
                   new SqlParameter(nameof(IPatientMovement.isCheckedOut), patientMovement.isCheckedOut)
            };

            return parameters;
        }



        public SqlParameter[] GetSelectByDateRangeParameters(IPatient patient, DateTime startDate, DateTime endDate)
        {
            SqlParameter[] parameters;

            parameters = new SqlParameter[]
            {
                 new SqlParameter(nameof(IPatient.PatientID), patient.PatientID),
                 new SqlParameter(nameof(startDate) , startDate),
                 new SqlParameter(nameof(endDate)  , endDate)

            };

            return parameters;
        }

        //TODO: WILL BE IMPLEMENTED LATER
        public SqlParameter[] GetSelectByPatientIDParameter(int id)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(IPatient.PatientID),id)
            };
        }

        public SqlParameter[] GetSelectByReasonParameter(int reason)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(IPatientMovement.Reason), reason)
            };
        }


        public SqlParameter[] GetSelectByStatusParameter(bool isCheckOut)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(IPatientMovement.isCheckedOut), isCheckOut)
            };
        }

        public SqlParameter[] GetSelectByMoveIDParameter(int moveid)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(IPatientMovement.PatientMovementID), moveid)
            };
        }

        public SqlParameter[] GetSelectByNotificationParameters( DateTime latetime, bool isCheckedOut)
        {
            SqlParameter[] parameters;

            parameters = new SqlParameter[]
            {
                 new SqlParameter(nameof(latetime) , latetime),
                 new SqlParameter(nameof(IPatientMovement.PatientMovementID),isCheckedOut)
              

            };

            return parameters;
        }


        public string sp_Insert()
        {
            return _StoredProcedureProvider.sp_InsertPatientMovement.ToString();
        }

        public string sp_Select()
        {
            return _StoredProcedureProvider.sp_SelectPatientMovement.ToString();
        }



        public string sp_SelectByReason()
        {
            return _StoredProcedureProvider.sp_SelectPatientMovementByReason.ToString();
        }

        public string sp_SelectByStatus()
        {
            return _StoredProcedureProvider.sp_SelectPatientMovementByStatus.ToString();
        }

        public string sp_Update()
        {
            return _StoredProcedureProvider.sp_UpdatePatientMovement.ToString();
        }

        public string sp_SelectByDateRange()
        {
            return _StoredProcedureProvider.sp_SelectPatientMoveByDateRange.ToString();
        }
        public string sp_SelectByNotification()
        {
            return _StoredProcedureProvider.sp_SelectPatientMovementByNotification.ToString();
        }
        public string sp_SelectBySelf()
        {
            return _StoredProcedureProvider.sp_SelectPatientMovementByID.ToString();
        }

      
        public string sp_SelectByPatient()
        {
            throw new NotImplementedException();
        }

       
    }
}
