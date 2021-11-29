using DataAccess.Domain.Interface;
using EFCore.Interface;
using System.Data.SqlClient;

namespace DataAccess.Domain
{
    public class Patient : IPatient_DataAccess
    {
        #region Parameters
        public SqlParameter[] GetInsertParameters(IPatient patient)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(IPatient.PatientID), patient.PatientID),
                new SqlParameter(nameof(IPatient.FirstName), patient.FirstName),
                new SqlParameter(nameof(IPatient.LastName), patient.LastName),
                new SqlParameter(nameof(IPatient.Gender), patient.Gender),
                new SqlParameter(nameof(IPatient.IDNumber), patient.IDNumber),
                new SqlParameter(nameof(IPatient.DOB), patient.DOB),
                new SqlParameter(nameof(IPatient.EmailAddress), patient.EmailAddress),
                new SqlParameter(nameof(IPatient.MobileNumber), patient.MobileNumber),
                new SqlParameter(nameof(IPatient.AddressLine1), patient.AddressLine1),
                new SqlParameter(nameof(IPatient.AddressLine2), patient.AddressLine2),
                new SqlParameter(nameof(IPatient.SuburbID), patient.SuburbID)
            };
        }

        public SqlParameter[] GetIDParameter(int id)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(IPatient.PatientID), id)
            };
        }

        public SqlParameter[] GetNameParameter(string name)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(IPatient.FirstName), name)
            };
        }

        public SqlParameter[] GetUpdateParameters(IPatient patient)
        {
            throw new System.NotImplementedException();
        } 
        #endregion

        public string sp_Insert()
        {
            return _StoredProcedureProvider.sp_InsertPatient.ToString();
        }

        public string sp_Select()
        {
            return _StoredProcedureProvider.sp_SelectPatient.ToString();
        }

        public string sp_SelectByPatient()
        {
            return _StoredProcedureProvider.sp_SelectPatientByID.ToString();
        }

        public string sp_Update()
        {
            return _StoredProcedureProvider.sp_UpdatePatient.ToString();
        }

        public string sp_SelectByName()
        {
            return _StoredProcedureProvider.sp_SelectPatientByName.ToString();
        }

        public string sp_GetPatientNoReferral()
        {
            return _StoredProcedureProvider.sp_SelectPatientNoReferral.ToString();
        }

        public string sp_GetPatientReferralTimeline()
        {
            return _StoredProcedureProvider.sp_SelectReferralTimeline.ToString();
        }

        public string sp_GetPatientTreatmentTimeline()
        {
            return _StoredProcedureProvider.sp_SelectTreatmentTimeline.ToString();
        }
    }
}
