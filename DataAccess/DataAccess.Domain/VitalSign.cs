using DataAccess.Domain.Interface;
using EFCore.Interface;
using System.Data.SqlClient;

namespace DataAccess.Domain
{
    public class VitalSign : IVitalSign_DataAccess
    {
        public SqlParameter[] Parameters { get; }

        public SqlParameter[] GetInsertParameters(IVitalSign vitalSign)
        {
            return new SqlParameter[]
           {
                new SqlParameter($"@{nameof(IVitalSign.BloodGroupID)}", vitalSign.BloodGroupID),
                new SqlParameter($"@{nameof(IVitalSign.Hypoglycemia)}", vitalSign.Hypoglycemia),
                new SqlParameter($"@{nameof(IVitalSign.BodyTemperature)}", vitalSign.BodyTemperature),
                new SqlParameter($"@{nameof(IVitalSign.PulseRate)}", vitalSign.PulseRate),
                new SqlParameter($"@{nameof(IVitalSign.BloodPressure)}", vitalSign.BloodPressure),
                new SqlParameter($"@{nameof(IVitalSign.Weight)}", vitalSign.Weight),
                new SqlParameter($"@{nameof(IVitalSign.BMI)}", vitalSign.BMI)
           };
        }

        public SqlParameter[] GetSelectByAdmissionFileParameters(int id)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@AdmissionFileID", id)
            };
        }

        public string sp_Insert()
        {
            //return _StoredProcedureProvider.spInsertVitalSign.ToString();
            throw new System.NotImplementedException();
        }

        public string sp_Select()
        {
            //return _StoredProcedureProvider.sp_SelectVitalSign.ToString();

            throw new System.NotImplementedException();
        }

        public string sp_SelectByAdmissionFileID()
        {
            throw new System.NotImplementedException();
        }

        public string sp_Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
