namespace DataAccess.Domain.Interface.Filter
{
    public interface ISelectByDoctor
    {
        /// <summary>
        /// This method returns the stored procedure for selecting data from the table based on a Doctor ID
        /// </summary>
        /// <returns></returns>
        string sp_SelectByDoctor();

    }
}
