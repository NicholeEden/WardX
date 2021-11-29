using DataAccess.Domain.Interface.Component;
using DataAccess.Domain.Interface.Function;
using DataAccess.Domain.Interface.Filter;
using EFCore.Interface;
using System.Data.SqlClient;

namespace DataAccess.Domain.Interface
{
    public interface INurseSchedule_DataAccess :
        ICanInsert,
        ISQLParameter,
        ICanSelect,
        ICanUpdate
    {
        /// <summary>
        /// Receives input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] GetInsertParameters(INurseSchedule nurseSchedule);

        /// <summary>
        /// Receives input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] SqlParameters(INurseSchedule nurseSchedule);

        /// <summary>
        /// Receives input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] GetSelectParameters(INurseSchedule nurseSchedule);

        /// <summary>
        /// Receives input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] GetUpdateParameters(INurseSchedule nurseSchedule);

        SqlParameter[] GetShiftSlotID(int ShiftSlotID);

        /// <summary>
        /// Returns the NurseID parameter
        /// </summary>
        /// <param name="nurseID"></param>
        /// <returns></returns>
        SqlParameter[] GetNurseIDParameter(int nurseID);

        /// <summary>
        /// Returns the stored procedure
        /// </summary>
        /// <returns></returns>
        string sp_GetNurseScheduleByNurse();

        string sp_Get_NurseSchedule();
        string sp_GetNurseSchedule(int ShiftSlotID);
        SqlParameter[] Get_NurseSchedule(int shiftSlotID);
        string sp_Get_Schedule();
    }
}
