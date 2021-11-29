using System.Data.SqlClient;

namespace DataAccess.Domain.Interface
{
    public interface IUser_DataAccess
    {
        string sp_SelectUsersByRoleName();

        string sp_SelectUserByUserID();

        string sp_SelectUserByUserName();

        /// <summary>
        /// Recieves input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] GetSelectByUserIDParameters(int userID);

        /// <summary>
        /// Recieves input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] GetSelectByUserNameParameters(string userName);
    }
}
