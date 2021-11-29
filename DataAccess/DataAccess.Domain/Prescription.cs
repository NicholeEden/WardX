using DataAccess.Domain.Interface;
using EFCore.Interface;
using System.Data.SqlClient;

namespace DataAccess.Domain
{
    public class Prescription : IPrescription_DataAccess
    {
        public SqlParameter[] Parameters { get; }

        public SqlParameter[] GetInsertParameters(IPrescription prescription)
        {
            return new SqlParameter[]
            {
                new SqlParameter($"@{nameof(IPrescription.PrescriptionID)}", prescription.PrescriptionID),
                new SqlParameter($"@{nameof(IPrescription.MedicationID)}", prescription.MedicationID),
                new SqlParameter($"@{nameof(IPrescription.Dosage)}", prescription.Dosage),
                new SqlParameter($"@{nameof(IPrescription.DoctorID)}", prescription.DoctorID),
                new SqlParameter($"@{nameof(IPrescription.Instruction)}", prescription.Instruction),
                new SqlParameter($"@{nameof(IPrescription.DateIssued)}", prescription.DateIssued),
            };
        }

        public SqlParameter[] GetSelectByAdmissionFileParameters(int id)
        {
            return new SqlParameter[]
            {
                new SqlParameter($"@{nameof(IPrescription.PrescriptionID)}", id)
            };
        }

        public SqlParameter[] GetSelectByPatientParameters(int id)
        {
            return new SqlParameter[]
            {
                new SqlParameter($"@{nameof(IPrescription.PrescriptionID)}", id)
            };
        }

        public SqlParameter[] GetUpdateParameters(IPrescription prescription)
        {
            return new SqlParameter[]
            {
                new SqlParameter($"@{nameof(IPrescription.PrescriptionID)}", prescription.PrescriptionID),
                new SqlParameter($"@{nameof(IPrescription.MedicationID)}", prescription.MedicationID),
                new SqlParameter($"@{nameof(IPrescription.Dosage)}", prescription.Dosage),
                new SqlParameter($"@{nameof(IPrescription.DoctorID)}", prescription.DoctorID),
                new SqlParameter($"@{nameof(IPrescription.Instruction)}", prescription.Instruction),
                new SqlParameter($"@{nameof(IPrescription.DateIssued)}", prescription.DateIssued),
            };
        }

        public string sp_Insert()
        {
            return _StoredProcedureProvider.sp_InsertPrescription.ToString();
        }

        public string sp_Select()
        {
            return _StoredProcedureProvider.sp_SelectPrescription.ToString();
        }

        public string sp_SelectByPatient()
        {
            return _StoredProcedureProvider.sp_SelectPrescriptionByPatientID.ToString();
        }

        public string sp_Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
