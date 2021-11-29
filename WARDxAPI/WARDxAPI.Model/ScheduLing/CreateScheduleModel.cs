using EFCore.Interface;
using System.Collections.Generic;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.StaffScheduling;

namespace WARDxAPI.Model
{
    public class CreateScheduleModel : ICreateScheduleModel

    {
        public CreateScheduleModel(
            ICreateSchedule createSchedule,
            IAlertModel AlertModel)
        {
            CreateSchedule = createSchedule;
                alertModel = AlertModel;
        }
        //public INurse nurse { get; set; }
        //public INurseSchedule nurseSchedule { get; set; }
        //public IMonth month { get; set; }
        //public IShiftSlot shiftSlot { get; set; }
        //public IStaffMember staffMember { get; set; }
        public ICreateSchedule CreateSchedule { get; set; }
        public IAlertModel alertModel { get; set; }
        public Dictionary<string, string> MonthOptions { get; set; }
        public int MonthID { get; set; }

        public Dictionary<string, string> ShiftSlotOptions { get; set; }
        public int ShiftSlotID { get; set; }

        public Dictionary<string, string> NurseOptions { get; set; }
        public int NurseID { get; set; }

    }
}
