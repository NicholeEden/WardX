using DataAccess.Domain.Interface;
using EFCore.Interface;
using System.Data.SqlClient;

namespace DataAccess.Domain
{
    public class Role : IRole_DataAccess
    {
        public SqlParameter[] GetSelectByRoleIDParameters(int roleID)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(IRole.RoleID), roleID)
            };
        }

        public SqlParameter[] GetSelectByRoleNameParameters(string roleName)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(IRole.RoleName), roleName)
            };
        }

        public SqlParameter[] GetSelectByUserIDParameters(int userID)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(IUser.UserID), userID)
            };
        }

        public string sp_SelectRoleByID()
        {
            return _StoredProcedureProvider.sp_SelectRoleByID.ToString();
        }

        public string sp_SelectRoleByRoleName()
        {
            return _StoredProcedureProvider.sp_SelectRoleByRoleName.ToString();
        }

        public string sp_SelectRolesByUserID()
        {
            return _StoredProcedureProvider.sp_SelectRolesByUserID.ToString();
        }
    }
}
