namespace DataAccess.Domain.Interface.Filter
{
    public interface ISelectBySelf
    {
        /// <summary>
        /// This method returns the stored procedure for selecting data from the table based on a PK ID
        /// </summary>
        /// <returns></returns>
        string sp_SelectBySelf();


    }
}
