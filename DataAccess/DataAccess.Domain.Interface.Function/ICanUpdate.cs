namespace DataAccess.Domain.Interface.Function
{
    public interface ICanUpdate
    {
        /// <summary>
        /// This method returns the stored procedure for updating data to the table
        /// </summary>
        /// <returns></returns>
        string sp_Update();
    }
}
