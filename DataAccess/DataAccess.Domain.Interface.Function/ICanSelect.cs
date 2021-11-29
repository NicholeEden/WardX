namespace DataAccess.Domain.Interface.Function
{
    public interface ICanSelect
    {
        /// <summary>
        /// This method returns the stored procedure for selecting data from the table
        /// </summary>
        /// <returns></returns>
        string sp_Select();
    }
}
