namespace EFCore.Interface
{
    public interface IClerkComputer
    {
        int ClerkID { get; set; }
        int ComputerSkillID { get; set; }
        string ProficiencyLevel { get; set; }
    }
}
