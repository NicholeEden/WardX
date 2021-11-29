namespace DataAccess.Domain.Interface.Filter
{
    public interface ISelectBySpecialization
    {
        /// <summary>
        /// This method returns the stored procedure for selecting data from the table based on a Specialization ID
        /// </summary>
        /// <returns></returns>
        string sp_SelectBySpecialization();

    }
}
