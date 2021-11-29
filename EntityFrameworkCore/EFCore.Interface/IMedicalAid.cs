namespace EFCore.Interface
{
    /// <summary>
    /// Defines the database fields present in the Medical Aid table
    /// </summary>
    public interface IMedicalAid
    {
        MedicalAidSchemes MedicalAidSchemeID { get; set; }
        MedicalAidPlans MedicalAidPlanID { get; set; }
        string MemberNumber { get; set; }
        string PrincipalFirstName { get; set; }
        string PrincipalLastName { get; set; }
        string DependantCode { get; set; }
        int PatientID { get; set; }
    }
}
