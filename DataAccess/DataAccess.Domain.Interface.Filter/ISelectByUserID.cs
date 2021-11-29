namespace DataAccess.Domain.Interface.Filter
{
    public interface ISelectByUserID
    {
        /// <summary>
        /// This method returns the stored procedure for selecting data from the table based on a User ID
        /// </summary>
        /// <returns></returns>
        string sp_SelectUserByUserID();
    }
}
