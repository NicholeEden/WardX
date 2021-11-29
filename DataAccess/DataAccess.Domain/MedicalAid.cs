using DataAccess.Domain.Interface;
using EFCore.Interface;
using System.Data.SqlClient;

namespace DataAccess.Domain
{
    public class MedicalAid : IMedicalAid_DataAccess
    {
        public SqlParameter[] GetInsertParameters(IMedicalAid medicalAid)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(IMedicalAid.MedicalAidSchemeID), medicalAid.MedicalAidSchemeID),
                new SqlParameter(nameof(IMedicalAid.MedicalAidPlanID), medicalAid.MedicalAidPlanID),
                new SqlParameter(nameof(IMedicalAid.MemberNumber), medicalAid.MemberNumber),
                new SqlParameter(nameof(IMedicalAid.PrincipalFirstName), medicalAid.PrincipalFirstName),
                new SqlParameter(nameof(IMedicalAid.PrincipalLastName), medicalAid.PrincipalLastName),
                new SqlParameter(nameof(IMedicalAid.DependantCode), medicalAid.DependantCode),
                new SqlParameter(nameof(IMedicalAid.PatientID), medicalAid.PatientID)
            };
        }

        public SqlParameter[] GetPatientIDParameter(int id)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(IMedicalAid.PatientID), id)
            };
        }

        public SqlParameter[] GetUpdateParameters(IMedicalAid medicalAid)
        {
            throw new System.NotImplementedException();
        }

        public string sp_Insert()
        {
            return _StoredProcedureProvider.sp_InsertMedicalAid.ToString();
        }

        public string sp_SelectByPatient()
        {
            return _StoredProcedureProvider.sp_SelectMedicalAid.ToString();
        }

        public string sp_Update()
        {
            return _StoredProcedureProvider.sp_UpdateMedicalAid.ToString();
        }
    }
}
