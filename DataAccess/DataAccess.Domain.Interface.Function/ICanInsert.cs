namespace DataAccess.Domain.Interface.Function
{
    public interface ICanInsert
    {
        /// <summary>
        /// This method returns the stored procedure for inserting data to the table
        /// </summary>
        /// <returns></returns>
        string sp_Insert();
    }
}
