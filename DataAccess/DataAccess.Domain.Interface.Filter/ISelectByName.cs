namespace DataAccess.Domain.Interface.Filter
{
    public interface ISelectByName
    {
        /// <summary>
        /// This method returns the stored procedure for selecting data from the table based on a Name
        /// </summary>
        /// <returns></returns>
        string sp_SelectByName();

    }
}
