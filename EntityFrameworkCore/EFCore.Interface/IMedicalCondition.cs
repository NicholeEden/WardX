namespace EFCore.Interface
{
    /// <summary>
    /// Defines the database fields present in the Medical Condition table
    /// </summary>
    public interface IMedicalCondition
    {
        int MedicalConditionID { get; set; }
        string Name { get; set; }
        string Symptom { get; set; }
    }
}
