using DataAccess.Domain.Interface.Component;
using DataAccess.Domain.Interface.Function;
using DataAccess.Domain.Interface.Filter;
using EFCore.Interface;
using System.Data.SqlClient;

namespace DataAccess.Domain.Interface
{
    public interface IShiftSlot_DataAccess :
        ICanSelect
    {
        /// <summary>
        /// Recieves input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] GetSelectParameters(IShiftSlot shiftSlot);
        string sp_SelectByShiftSlot();
        SqlParameter[] GetShiftSlotID(IShiftSlot shiftSlot);
        string sp_Get_ShiftSlot();
    }
}
