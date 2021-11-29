using System.Data;
using EFCore.Interface;

namespace DataAccess.Interface.Integration
{
    public interface IShiftSlotMethods
    {
        DataTable Get_ShiftSlot(IShiftSlot shiftSlot);
    }
}
