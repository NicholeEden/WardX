namespace DataAccess.Domain.Interface.Filter
{
    public interface ISelectByPatient
    {
        /// <summary>
        /// This method returns the stored procedure for selecting data from the table based on a Patient ID
        /// </summary>
        /// <returns></returns>
        string sp_SelectByPatient();
    }
}
