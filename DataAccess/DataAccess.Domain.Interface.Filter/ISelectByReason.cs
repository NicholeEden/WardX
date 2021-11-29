namespace DataAccess.Domain.Interface.Filter
{
    public interface ISelectByReason
    {
        /// <summary>
        /// This method returns the stored procedure for selecting data from the table based on the check out Reason
        /// </summary>
        /// <returns></returns>
        string sp_SelectByReason();
    }
}
