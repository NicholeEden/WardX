namespace EFCore.Interface
{
    public interface IVitalSign
    {
        int VitalSignID { get; set; }
        int BloodGroupID { get; set; }
        string Hypoglycemia { get; set; }
        string BodyTemperature { get; set; }
        string PulseRate { get; set; }
        string BloodPressure { get; set; }
        string Weight { get; set; }
        string BMI { get; set; }
    }
}
