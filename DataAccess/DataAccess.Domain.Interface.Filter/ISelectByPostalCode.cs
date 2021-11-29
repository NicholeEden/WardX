namespace DataAccess.Domain.Interface.Filter
{
    public interface ISelectByPostalCode
    {
        /// <summary>
        /// This method returns the stored procedure for selecting data from the table based on a Postal Code
        /// </summary>
        /// <returns></returns>
        string sp_SelectByPostalCode();

    }
}
