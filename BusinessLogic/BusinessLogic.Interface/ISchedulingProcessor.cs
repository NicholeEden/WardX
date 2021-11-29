using BusinessLogic.Model;
using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interface
{
    public interface ISchedulingProcessor
    {
        Dictionary<string, string> GetMonths();

        Dictionary<string, string> GetShiftSlots();

        bool isShiftAvailable(int ShiftSlotID);

        List<INurseSchedule> GetNurseSchedules();

        INurse GetNurse(int nurseID);

        IStaffMember GetStaffMember(int nurseID);

        IMonth GetMonth(int monthID);

        IShiftSlot GetShiftSlot(int shiftSlotID);

        List<Nurse> GetNurses();

    }
}
