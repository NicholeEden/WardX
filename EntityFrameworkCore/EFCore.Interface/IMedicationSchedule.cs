namespace EFCore.Interface
{
    public interface IMedicationSchedule
    {
        int MedicationScheduleID { get; set; }
        string SchedulingStatus { get; set; }
    }
}
    