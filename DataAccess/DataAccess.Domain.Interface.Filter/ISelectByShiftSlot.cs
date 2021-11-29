namespace DataAccess.Domain.Interface.Filter
{
    public interface ISelectByShiftSlot
    {
        /// <summary>
        /// This method returns the stored procedure for selecting data from the table based on a Shift Slot ID
        /// </summary>
        /// <returns></returns>
        string sp_SelectByShiftSlot();

    }
}
