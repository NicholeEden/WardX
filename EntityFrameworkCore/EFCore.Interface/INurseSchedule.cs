namespace EFCore.Interface
{
    public interface INurseSchedule
    {
        int ScheduleID { get; set; }
        bool isAvailable { get; set; }
        int NurseID { get; set; }
        int MonthID { get; set; }
        int ShiftSlotID { get; set; }
    }
}
