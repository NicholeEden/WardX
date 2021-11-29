namespace DataAccess.Domain.Interface.Filter
{
    public interface ISelectByRoleName
    {
        /// <summary>
        /// This method returns the stored procedure for selecting data from the table based on a Role Name
        /// </summary>
        /// <returns></returns>
        string sp_SelectUsersByRoleName();
    }
}
