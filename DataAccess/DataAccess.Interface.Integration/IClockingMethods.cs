using System.Data;

namespace DataAccess.Interface.Integration
{
    public interface IClockingMethods
    {
        /// <summary>
        /// Returns the Clocking and StaffMember tables
        /// </summary>
        /// <param name="nurseID"></param>
        /// <returns></returns>
        DataTable Get_ClockingByNurse(int nurseID);
    }
}
