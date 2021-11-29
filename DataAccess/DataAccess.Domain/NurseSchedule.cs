using DataAccess.Domain.Interface;
using EFCore.Interface;
using System.Data.SqlClient;
using System;

namespace DataAccess.Domain
{
    public class NurseSchedule : INurseSchedule_DataAccess
    {
        public SqlParameter[] Parameters { get; }

        public SqlParameter[] GetInsertParameters(INurseSchedule nurseSchedule)
        {
            return new SqlParameter[]
            {
                new SqlParameter($"@{nameof(INurseSchedule.ScheduleID)}", nurseSchedule.ScheduleID),
                new SqlParameter($"@{nameof(INurseSchedule.ShiftSlotID)}", nurseSchedule.ShiftSlotID),
                new SqlParameter($"@{nameof(INurseSchedule.NurseID)}", nurseSchedule.NurseID),
                new SqlParameter($"@{nameof(INurseSchedule.MonthID)}", nurseSchedule.MonthID),
                new SqlParameter($"@{nameof(INurseSchedule.isAvailable)}", nurseSchedule.isAvailable),
            };
        }

        public SqlParameter[] GetNurseIDParameter(int nurseID)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(INurse.NurseID), nurseID)
            };
        }

        public SqlParameter[] GetSelectParameters(INurseSchedule nurseSchedule)
        {
            return new SqlParameter[]
           {
                new SqlParameter($"@{nameof(INurseSchedule.ScheduleID)}", nurseSchedule.ScheduleID),
                new SqlParameter($"@{nameof(INurseSchedule.ShiftSlotID)}", nurseSchedule.ShiftSlotID),
                new SqlParameter($"@{nameof(INurseSchedule.NurseID)}", nurseSchedule.NurseID),
                new SqlParameter($"@{nameof(INurseSchedule.MonthID)}", nurseSchedule.MonthID),
                new SqlParameter($"@{nameof(INurseSchedule.isAvailable)}", nurseSchedule.isAvailable),
           };
        }

        public SqlParameter[] GetShiftSlotID(int ShiftSlotID)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(INurseSchedule.ShiftSlotID), value: ShiftSlotID)
            };
        }

        public SqlParameter[] GetUpdateParameters(INurseSchedule nurseSchedule)
        {
            return new SqlParameter[]
          {
                new SqlParameter($"@{nameof(INurseSchedule.ScheduleID)}", nurseSchedule.ScheduleID),
                new SqlParameter($"@{nameof(INurseSchedule.ShiftSlotID)}", nurseSchedule.ShiftSlotID),
                new SqlParameter($"@{nameof(INurseSchedule.NurseID)}", nurseSchedule.NurseID),
                new SqlParameter($"@{nameof(INurseSchedule.MonthID)}", nurseSchedule.MonthID),
                new SqlParameter($"@{nameof(INurseSchedule.isAvailable)}", nurseSchedule.isAvailable),
          };
        }

        public SqlParameter[] Get_NurseSchedule(int shiftSlotID)
        {
            return new SqlParameter[]
           {
                new SqlParameter(nameof(INurseSchedule.ShiftSlotID), value: shiftSlotID)
           };
        }

        public string sp_GetNurseSchedule(int ShiftSlotID)
        {
            throw new System.NotImplementedException();
        }

        public string sp_GetNurseScheduleByNurse()
        {
            return _StoredProcedureProvider.sp_GetNurseScheduleByNurse.ToString();
        }

        public string sp_Get_NurseSchedule()
        {
            return _StoredProcedureProvider.sp_GetNurseScheduleByShiftSlot.ToString();
        }

        public string sp_Get_Schedule()
        {
            return _StoredProcedureProvider.sp_GetNurseScheduleByShiftSlot.ToString();
           
        }

        public string sp_Insert()
        {
            return _StoredProcedureProvider.sp_GetNurseScheduleByShiftSlot.ToString();
        }

        public string sp_Select()
        {
            return _StoredProcedureProvider.sp_GetNurseScheduleByShiftSlot.ToString();
        }

        public string sp_Update()
        {
            return _StoredProcedureProvider.sp_GetNurseScheduleByShiftSlot.ToString();
        }

        public SqlParameter[] SqlParameters(INurseSchedule nurseSchedule)
        {
            return new SqlParameter[]
            {
                new SqlParameter($"@{nameof(INurseSchedule.ScheduleID)}", nurseSchedule.ScheduleID),
                new SqlParameter($"@{nameof(INurseSchedule.ShiftSlotID)}", nurseSchedule.ShiftSlotID),
                new SqlParameter($"@{nameof(INurseSchedule.NurseID)}", nurseSchedule.NurseID),
                new SqlParameter($"@{nameof(INurseSchedule.MonthID)}", nurseSchedule.MonthID),
                new SqlParameter($"@{nameof(INurseSchedule.isAvailable)}", nurseSchedule.isAvailable),
            };
        }
    }
}
