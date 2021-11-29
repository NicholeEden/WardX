using System.Data.SqlClient;

namespace DataAccess.Domain.Interface
{
    public interface IRole_DataAccess
    {
        string sp_SelectRoleByID();

        string sp_SelectRoleByRoleName();

        string sp_SelectRolesByUserID();

        /// <summary>
        /// Recieves input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] GetSelectByRoleIDParameters(int roleID);

        /// <summary>
        /// Recieves input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] GetSelectByUserIDParameters(int userID);

        /// <summary>
        /// Recieves input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] GetSelectByRoleNameParameters(string roleName);
    }
}
