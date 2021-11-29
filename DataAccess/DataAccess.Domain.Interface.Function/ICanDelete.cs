namespace DataAccess.Domain.Interface.Function
{
    public interface ICanDelete
    {
        /// <summary>
        /// This method returns the stored procedure for deleting data from the table
        /// </summary>
        /// <returns></returns>
        string sp_Delete();

    }
}
