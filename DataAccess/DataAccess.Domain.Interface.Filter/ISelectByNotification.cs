namespace DataAccess.Domain.Interface.Filter
{
    public interface ISelectByByNotification
    {
        /// <summary>
        /// This method returns the stored procedure for selecting a notification based on latetime and is checked out
        /// </summary>
        /// <returns></returns>
        string sp_SelectByNotification();
    }
}
