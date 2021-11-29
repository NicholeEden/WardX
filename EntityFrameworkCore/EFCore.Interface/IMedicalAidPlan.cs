namespace EFCore.Interface
{
    /// <summary>
    /// Defines the database fields present in the Medical Aid Plan table
    /// </summary>
    public interface IMedicalAidPlan
    {
        int MedicalAidPlanID { get; set; }
        string Name { get; set; }
    }
}
