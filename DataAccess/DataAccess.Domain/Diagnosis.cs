using DataAccess.Domain.Interface;
using EFCore.Interface;
using System.Data.SqlClient;

namespace DataAccess.Domain
{
    public class Diagnosis : IDiagnosis_DataAccess
    {
        public SqlParameter[] GetInsertParameters(IDiagnosis diagnosis)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(IDiagnosis.DiagnosisID), diagnosis.DiagnosisID),
                new SqlParameter(nameof(IDiagnosis.MedicalConditionID), diagnosis.MedicalConditionID),
                new SqlParameter(nameof(IDiagnosis.DiagnosedBy), diagnosis.DiagnosedBy),
                new SqlParameter(nameof(IDiagnosis.DiagnosisDetals), diagnosis.DiagnosisDetals),
                new SqlParameter(nameof(IDiagnosis.DiagnosisDate), diagnosis.DiagnosisDate)
            };
        }

        public SqlParameter[] GetIDParameter(int id)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(IDiagnosis.DiagnosisID), id)
            };
        }

        public string sp_Insert()
        {
            return _StoredProcedureProvider.sp_InsertDiagnosis.ToString();
        }

        public string sp_SelectBySelf()
        {
            return _StoredProcedureProvider.sp_SelectDiagnosis.ToString();
        }
    }
}
