using System.Data;

namespace DataAccess.Interface.Integration
{
    public interface INurseScheduleMethods
    {
        DataTable Get_NurseSchedule(int ShiftSlotID);

        /// <summary>
        /// Returns the tables Month, NurseSchedule, StaffMember and ShiftSlot
        /// </summary>
        /// <param name="nurseID"></param>
        /// <returns></returns>
        DataTable Get_NurseScheduleByNurse(int nurseID);


    }
}
