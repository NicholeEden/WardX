using DataAccess.Domain.Interface;
using DataAccess.Domain.Interface.Function;
using EFCore.Interface;
using System;
using System.Data.SqlClient;

namespace DataAccess.Domain
{
    public class StaffMember : IStaffMember_DataAccess

    {
        public string sp_Select()
        {
            return _StoredProcedureProvider.sp_GetNurseScheduleByNurse.ToString();
        }
    }
}

