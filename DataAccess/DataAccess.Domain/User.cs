using DataAccess.Domain.Interface;
using EFCore.Interface;
using System.Data.SqlClient;

namespace DataAccess.Domain
{
    public class User : IUser_DataAccess
    {
        public SqlParameter[] GetSelectByUserIDParameters(int userID)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(IUser.UserID), userID)
            };
        }

        public SqlParameter[] GetSelectByUserNameParameters(string userName)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(IUser.UserName), userName)
            };
        }

        public string sp_SelectUsersByRoleName()
        {
            return _StoredProcedureProvider.sp_SelectUsersInRoleName.ToString();
        }

        public string sp_SelectUserByUserID()
        {
            return _StoredProcedureProvider.sp_SelectUserByID.ToString();
        }

        public string sp_SelectUserByUserName()
        {
            return _StoredProcedureProvider.sp_SelectUserByUserName.ToString();
        }
    }
}
