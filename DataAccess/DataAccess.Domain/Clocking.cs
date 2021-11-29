using DataAccess.Domain.Interface;
using EFCore.Interface;
using System.Data.SqlClient;

namespace DataAccess.Domain
{
    public class Clocking : IClocking_DataAccess
    {
        public SqlParameter[] Parameters => throw new System.NotImplementedException();

        public SqlParameter[] GetInsertParameters (IClocking clocking)
        {
            throw new System.NotImplementedException();
        }

        public SqlParameter[] GetSelectParameters (IClocking clocking)
        {
            throw new System.NotImplementedException();
        }

        public SqlParameter[] GetUpdateParameters(IClocking clocking)
        {
            throw new System.NotImplementedException();
        }

        public SqlParameter[] GetNurseID(int NurseID)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(IClocking.NurseID), value: NurseID)
            };
        }


        public string sp_Insert()
        {
            throw new System.NotImplementedException();
        }

        public string sp_Select()
        {
            throw new System.NotImplementedException();
        }

        public string sp_Update()
        {
            throw new System.NotImplementedException();
        }

        public SqlParameter[] SqlParameters(IClocking clocking)
        {
            throw new System.NotImplementedException();
        }

        public SqlParameter[] GetNurseIDParameter(int NurseID)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(IClocking.NurseID), NurseID)
            };
        }

        public string sp_Get_Clocking()
        {
            return _StoredProcedureProvider.sp_GetClockingByNurseID.ToString();
        }
    }
}
