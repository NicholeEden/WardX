using DataAccess.Domain.Interface;
using EFCore.Interface;
using System;
using System.Data.SqlClient;

namespace DataAccess.Domain
{
    public class ShiftSlot : IShiftSlot_DataAccess
    {
        public SqlParameter[] GetSelectParameters(IShiftSlot shiftSlot)
        {
            return new SqlParameter[]
            {
                new SqlParameter(nameof(IShiftSlot.ShiftSlotID), shiftSlot)
            };
        }

        public SqlParameter[] GetShiftSlotID(IShiftSlot shiftSlot)
        {
            return new SqlParameter[]
           {
                new SqlParameter(nameof(IShiftSlot.ShiftSlotID), shiftSlot)
           };
        }

        public string sp_Get_ShiftSlot()
        {
            return _StoredProcedureProvider.sp_GetNurseScheduleByShiftSlot.ToString();
        }

        public string sp_Select()
        {
            return _StoredProcedureProvider.sp_GetNurseScheduleByShiftSlot.ToString();
        }

        public string sp_SelectByShiftSlot()
        {
            return _StoredProcedureProvider.sp_GetNurseScheduleByShiftSlot.ToString();
        }
    }
}
