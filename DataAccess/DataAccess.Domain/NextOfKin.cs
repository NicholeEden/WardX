using DataAccess.Domain.Interface;
using EFCore.Interface;
using System.Data.SqlClient;

namespace DataAccess.Domain
{
    public class NextOfKin : INextOfKin_DataAccess
    {
        public SqlParameter[] GetInsertParameters(INextOfKin nextOfKin)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(INextOfKin.PatientID), nextOfKin.PatientID),
                new SqlParameter(nameof(INextOfKin.FirstName), nextOfKin.FirstName),
                new SqlParameter(nameof(INextOfKin.LastName), nextOfKin.LastName),
                new SqlParameter(nameof(INextOfKin.Relationship), nextOfKin.Relationship),
                new SqlParameter(nameof(INextOfKin.EmailAddress), nextOfKin.EmailAddress),
                new SqlParameter(nameof(INextOfKin.MobileNumber), nextOfKin.MobileNumber),
                new SqlParameter(nameof(INextOfKin.AddressLine1), nextOfKin.AddressLine1),
                new SqlParameter(nameof(INextOfKin.AddressLine2), nextOfKin.AddressLine2),
                new SqlParameter(nameof(INextOfKin.SuburbID), nextOfKin.SuburbID),
                new SqlParameter(nameof(INextOfKin.Gender), nextOfKin.Gender)
            };
        }

        public SqlParameter[] GetPatientIDParameter(int id)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(INextOfKin.PatientID), id)
            };
        }

        public SqlParameter[] GetUpdateParameters(INextOfKin nextOfKin)
        {
            throw new System.NotImplementedException();
        }

        public string sp_Insert()
        {
            return _StoredProcedureProvider.sp_InsertNextOfKin.ToString();
        }

        public string sp_SelectByPatient()
        {
            return _StoredProcedureProvider.sp_SelectNextOfKin.ToString();
        }

        public string sp_Update()
        {
            return _StoredProcedureProvider.sp_UpdateNextOfKin.ToString();
        }
    }
}
