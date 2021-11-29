using DataAccess.Domain.Interface;
using EFCore.Interface;
using System;
using System.Data.SqlClient;

namespace DataAccess.Domain
{
    public class Nurse : INurse_DataAccess
    {
        public SqlParameter[] Parameters { get; }


        public SqlParameter[] GetInsertParameters(INurse nurse)
        {
            return new SqlParameter[]
             {
                new SqlParameter(nameof(INurse.NurseID), nurse)
             };
        }

        public SqlParameter[] GetNurseID(int nurseID)
        {
            return new SqlParameter[]
           {
                new SqlParameter($"@{nameof(INurse.NurseID)}", nurseID)
           };
        }

        public SqlParameter[] GetSelectParameters(INurse nurse)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(INurse.NurseID), nurse)
            };
        }

        public SqlParameter[] GetUpdateParameters(INurse nurse)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(INurse.NurseID), nurse)
            };
        }

        public string sp_Get_Nurse()
        {
            return _StoredProcedureProvider.sp_GetNurseScheduleByNurse.ToString();
        }

        public string sp_Insert()
        {
            return _StoredProcedureProvider.sp_GetNurseScheduleByNurse.ToString();
        }

        public string sp_Select()
        {
            return _StoredProcedureProvider.sp_GetNurseScheduleByNurse.ToString();
        }

        public string sp_Update()
        {
            return _StoredProcedureProvider.sp_GetNurseScheduleByNurse.ToString();
        }

        public SqlParameter[] SqlParameters(INurse nurse)
        {
            return new SqlParameter[]
           {
                new SqlParameter(nameof(INurse.NurseID), nurse)
           };
        }
    }
}
