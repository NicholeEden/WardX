namespace DataAccess.Domain.Interface.Filter
{
    public interface ISelectByDateRange
    {
        /// <summary>
        /// This method returns the stored procedure for selecting data from the table based on a date range
        /// </summary>
        /// <returns></returns>
        string sp_SelectByDateRange();
    }
}
