using DataAccess.Domain.Interface;
using EFCore.Interface;
using System.Data.SqlClient;

namespace DataAccess.Domain
{
    public class AdmissionFile : IAdmissionFile_DataAccess
    {

        public SqlParameter[] GetInsertParameters(IAdmissionFile admission)
        {
            return new SqlParameter[]
            {

                new SqlParameter($"@{nameof(admission.AdmissionDate)}", admission.AdmissionDate),
                new SqlParameter($"@{nameof(admission.AssignedSpecialistID)}", admission.AssignedSpecialistID),
                new SqlParameter($"@{nameof(admission.BedID)}", admission.BedID),
                new SqlParameter($"@{nameof(admission.PatientID)}", admission.PatientID),
                new SqlParameter($"@{nameof(admission.Notes)}", admission.Notes),

            };
        }

        public SqlParameter[] GetSelectAdmissionFile(int Id)
        {
            return new SqlParameter[] 
            {
                new SqlParameter($"@{nameof(IAdmissionFile.AdmissionFileID)}", Id)
            };
        }

        public SqlParameter[] GetSelectByPatientParameters(int id)
        {
            return new SqlParameter[]
            {
                new SqlParameter($"@{nameof(IAdmissionFile.PatientID)}", id)
            };
        }

        public SqlParameter[] GetUpdateDischargeParameters(IAdmissionFile admission)
        {
            return new SqlParameter[]
            {
                new SqlParameter($"@{nameof(IAdmissionFile.AdmissionFileID)}", admission.AdmissionFileID),
                new SqlParameter($"@{nameof(IAdmissionFile.DischargeDate)}", admission.DischargeDate)
            };
        }

        public SqlParameter[] GetUpdateParameters(IAdmissionFile admission)
        {
            return new SqlParameter[]
            {
                new SqlParameter($"@{nameof(admission.AdmissionFileID)}", admission.AdmissionFileID),
                new SqlParameter($"@{nameof(admission.BedID)}", admission.BedID),
                new SqlParameter($"@{nameof(admission.Notes)}", admission.Notes)

            };
        }

        public string sp_Insert()
        {
            return _StoredProcedureProvider.sp_InsertAdmissionFile.ToString();
        }

        public string sp_Select()
        {
            return _StoredProcedureProvider.sp_SelectAdmissionFile.ToString();
        }

        public string sp_SelectByAdmissionFileID()
        {
            return _StoredProcedureProvider.sp_SelectAdmissionFileByID.ToString();
        }

        public string sp_SelectByPatient()
        {
            return _StoredProcedureProvider.sp_SelectAdmissionFileByPatientID.ToString();
        }

       

        public string sp_Update()
        {
            return _StoredProcedureProvider.sp_UpdateAdmissionFileByPatient.ToString();
        }

        public string sp_UpdateByDischarge()
        {
            return _StoredProcedureProvider.sp_AdmissionFileDischarge.ToString();
        }
    }
}
