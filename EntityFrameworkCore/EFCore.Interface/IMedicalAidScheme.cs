namespace EFCore.Interface
{
    /// <summary>
    /// Defines the database fields present in the Medical Aid Scheme table
    /// </summary>
    public interface IMedicalAidScheme
    {
        int MedicalAidSchemeID { get; set; }
        string Name { get; set; }
    }
}
