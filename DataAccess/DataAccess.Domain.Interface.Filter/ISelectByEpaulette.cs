namespace DataAccess.Domain.Interface.Filter
{
    public interface ISelectByEpaulette
    {
        /// <summary>
        /// This method returns the stored procedure for selecting data from the table based on a Epaulette ID
        /// </summary>
        /// <returns></returns>
        string sp_SelectByEpaulette();

    }
}
