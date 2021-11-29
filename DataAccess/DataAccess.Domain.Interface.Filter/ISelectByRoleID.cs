namespace DataAccess.Domain.Interface.Filter
{
    public interface ISelectByRoleID
    {
        /// <summary>
        /// This method returns the stored procedure for selecting data from the table based on a Role ID
        /// </summary>
        /// <returns></returns>
        string sp_SelectRoleByRoleID();
    }
}
