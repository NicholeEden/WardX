namespace EFCore.Interface
{
    //TODO: Remove this interface
    public interface IDoctorSchedule
    {
        int ScheduleID { get; set; }
        int DoctorID { get; set; }
        int MonthID { get; set; }
        int ShiftSlotID { get; set; }
        bool isAvailable { get; set; }
    }
}
