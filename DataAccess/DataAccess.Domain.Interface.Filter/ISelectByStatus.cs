namespace DataAccess.Domain.Interface.Filter
{
    public interface ISelectByStatus
    {
        /// <summary>
        /// This method returns the stored procedure for selecting data from the table based on the Stauts
        /// </summary>
        /// <returns></returns>
        string sp_SelectByStatus();
    }
}
