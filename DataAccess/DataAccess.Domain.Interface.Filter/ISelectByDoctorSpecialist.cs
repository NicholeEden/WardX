namespace DataAccess.Domain.Interface.Filter
{
    public interface ISelectByDoctorSpecialist
    {
        /// <summary>
        /// This method returns the stored procedure for selecting data from the table based on a Doctor Type
        /// </summary>
        /// <returns></returns>
        string sp_SelectByDoctorSpecialist();
    }
}
