namespace DataAccess.Domain.Interface.Filter
{
    public interface ISelectByBloodGroup
    {
        /// <summary>
        /// This method returns the stored procedure for selecting data from the table based on a BloodGroup ID
        /// </summary>
        /// <returns></returns>
        string sp_SelectByBloodGroup();
    }
}
