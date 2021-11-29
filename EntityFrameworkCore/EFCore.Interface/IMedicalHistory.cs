namespace EFCore.Interface
{//TODO: Remove this interface
    public interface IMedicalHistory
    {
        int PatientID { get; set; }
        string Diagnosis { get; set; }
        string ExistingCondition { get; set; }
        double BMI { get; set; }
        double Weight { get; set; }
        int BloodGroupID { get; set; }
        string Allergies { get; set; }
    }
}
