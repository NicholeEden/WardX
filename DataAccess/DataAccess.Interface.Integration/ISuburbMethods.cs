using System.Data;

namespace DataAccess.Interface.Integration
{
    public interface ISuburbMethods
    {
        /// <summary>
        /// Returns the full Suburb table with all values
        /// </summary>
        /// <returns></returns>
        DataTable GetAll_Suburb();
    }
}
