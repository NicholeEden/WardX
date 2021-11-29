using System.Data;

namespace DataAccess.Interface.Integration
{
    public interface IUserMethods
    {
        /// <summary>
        /// Returns the user info based on the user ID
        /// </summary>
        /// <returns></returns>
        DataTable Auth_FindUserByID(int userID);

        /// <summary>
        /// Returns the user info based on the user Name
        /// </summary>
        /// <returns></returns>
        DataTable Auth_FindUserByName(string userName);

        /// <summary>
        /// Returns the user info based on the role Name
        /// </summary>
        /// <returns></returns>
        DataTable Auth_FindUserByRoleName(string roleName);

        /// <summary>
        /// Returns the role info based on the role ID
        /// </summary>
        /// <returns></returns>
        DataTable Auth_FindRoleByID(int roleID);

        /// <summary>
        /// Returns the role info based on the role Name
        /// </summary>
        /// <returns></returns>
        DataTable Auth_FindRoleByName(string roleName);

        /// <summary>
        /// Returns the role info based on the user ID
        /// </summary>
        /// <returns></returns>
        DataTable Auth_FindRoleByUserID(int userID);
    }
}
