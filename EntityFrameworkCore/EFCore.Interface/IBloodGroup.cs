namespace EFCore.Interface
{
    public interface IBloodGroup
    {
        int BloodGroupID { get; set; }
        string BloodGroupName { get; set; }
        string Description { get; set; }
    }
}
