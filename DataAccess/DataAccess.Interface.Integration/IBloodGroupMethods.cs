using System.Data;

namespace DataAccess.Interface.Integration
{
    public interface IBloodGroupMethods
    {
        /// <summary>
        /// Returns Blood Group table with all the entries
        /// </summary>
        /// <returns></returns>
        DataTable Get_AllBloodGroup();
    }
}
