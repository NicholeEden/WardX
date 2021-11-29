namespace DataAccess.Domain.Interface.Filter
{
    public interface ISelectByUserName
    {
        /// <summary>
        /// This method returns the stored procedure for selecting data from the table based on a User Name
        /// </summary>
        /// <returns></returns>
        string sp_SelectUserByUserName();
    }
}
