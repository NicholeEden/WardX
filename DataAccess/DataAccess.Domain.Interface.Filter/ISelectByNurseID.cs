namespace DataAccess.Domain.Interface.Filter
{
    public interface ISelectByNurseID
    {
        /// <summary>
        /// This method returns the stored procedure for selecting data from the table based on a Nurse Type ID
        /// </summary>
        /// <returns></returns>
        string sp_SelectByNurseID();

    }
}
