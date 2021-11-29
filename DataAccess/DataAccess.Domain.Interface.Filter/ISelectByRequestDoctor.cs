namespace DataAccess.Domain.Interface.Filter
{
    public interface ISelectByRequestDoctor
    {
        /// <summary>
        /// This method returns the stored procedure for selecting data from the table based on a Doctor ID
        /// </summary>
        string sp_SelectByRequestDoctor();
    }
}
