using DataAccess.Domain.Interface;
using EFCore.Interface;
using System.Data.SqlClient;

namespace DataAccess.Domain
{
    public class Referral : IReferral_DataAccess
    {
        public SqlParameter[] GetInsertParameters(IReferral referral)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(IReferral.PatientID), referral.PatientID),
                new SqlParameter(nameof(IReferral.DiagnosisID), referral.DiagnosisID),
                new SqlParameter(nameof(IReferral.SpecialistID), referral.SpecialistID),
                new SqlParameter(nameof(IReferral.ReferringDoctorID), referral.ReferringDoctorID),
                new SqlParameter(nameof(IReferral.Reason), referral.Reason),
                new SqlParameter(nameof(IReferral.AdmissionDate), referral.AdmissionDate)
            };
        }

        public SqlParameter[] GetPatientIDParameter(int id)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(IReferral.PatientID), id)
            };
        }

        public SqlParameter[] GetReferralByisAdmittedParameter(bool isAdmitted)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(IReferral.isAdmitted), isAdmitted)
            };
                
        }

        public SqlParameter[] GetUpdateParameters(IReferral referral)
        {
            throw new System.NotImplementedException();
        }

        public SqlParameter[] GetUpdateReferralStatus(int Id, bool isAdmitted)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(IReferral.ReferralID), Id),
                new SqlParameter(nameof(IReferral.isAdmitted), isAdmitted)
            };
        }

        public string sp_Insert()
        {
            return _StoredProcedureProvider.sp_InsertReferral.ToString();
        }

        public string sp_Select()
        {
            return _StoredProcedureProvider.sp_SelectReferral.ToString();
        }

        public string sp_SelectByPatient()
        {
            return _StoredProcedureProvider.sp_SelectReferralByPatientID.ToString();
        }

        public string sp_SelectPending()
        {
            return _StoredProcedureProvider.sp_SelectPendingReferral.ToString();
        }

        public string sp_Update()
        {
            throw new System.NotImplementedException();
        }

        public string sp_UpdateStatus()
        {
            return _StoredProcedureProvider.sp_UpdateReferralStatus.ToString();
        }
    }
}
