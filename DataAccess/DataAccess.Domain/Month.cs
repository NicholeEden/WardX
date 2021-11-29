using DataAccess.Domain.Interface;
using DataAccess.Domain.Interface.Function;
using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Domain
{
    public class Month : IMonth_DataAccess
    {
        //public IEnumerable<char> sp;

        //public string sp_GetMonth();
        public SqlParameter[] GetSelectParameters(IMonth month)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(IMonth.MonthID), month)
            };
        }

        public string sp_Get_Month()
        {
            return _StoredProcedureProvider.sp_GetMonth.ToString();

        }

        public object sp_GetMonth()
        {
            return _StoredProcedureProvider.sp_GetMonth.ToString();
        }

        public object GetParameter(object name)
        {
            return _StoredProcedureProvider.sp_GetMonth.ToString();
        }

        public string sp_Select()
        {
            return _StoredProcedureProvider.sp_GetMonth.ToString();
        }


        string ICanSelect.sp_Select()
        {
            return _StoredProcedureProvider.sp_GetMonth.ToString();
        }

        string IMonth_DataAccess.sp_GetMonth()
        {
            return _StoredProcedureProvider.sp_GetMonth.ToString();
        }

        public SqlParameter[] GetMonthID(int monthID)
        {
            return new SqlParameter[]
           {
                new SqlParameter($"@{nameof(IMonth.MonthID)}", monthID)
           };
        }
    }
}
