namespace DataAccess.Domain.Interface.Filter
{
    public interface ISelectByDoctorType
    {
        /// <summary>
        /// This method returns the stored procedure for selecting data from the table based on a Doctor Type ID
        /// </summary>
        /// <returns></returns>
        string sp_SelectByDoctorType();

    }
}
