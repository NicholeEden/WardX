using DataAccess.Domain.Interface;
using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess.Domain
{
    public class Treatment : ITreatment_DataAccess
    {
        public SqlParameter[] Parameters { get; }

        public SqlParameter[] GetInsertParameters(ITreatment treatment)
        {
            return new SqlParameter[]
            {
                new SqlParameter($"@{nameof(ITreatment.PatientID)}", treatment.PatientID),
                new SqlParameter($"@{nameof(ITreatment.NurseID)}", treatment.NurseID),
                new SqlParameter($"@{nameof(ITreatment.TreatmentTypeID)}", treatment.TreatmentTypeID),
                new SqlParameter($"@{nameof(ITreatment.ObservationNotes)}", treatment.ObservationNotes)
            };
        }

        public SqlParameter[] GetSelectByPatientParameters(int id)
        {
            throw new NotImplementedException();
        }

        public string sp_Insert()
        {
            return _StoredProcedureProvider.sp_InsertTreatment.ToString();
        }

        public string sp_Select()
        {
            return _StoredProcedureProvider.sp_SelectTreatment.ToString();
        }

        public string sp_SelectByPatient()
        {
            throw new NotImplementedException();
        }
    }
}
