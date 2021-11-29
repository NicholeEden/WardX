namespace EFCore.Interface
{
    /// <summary>
    /// Defines the database fields present in the WARDx Role table
    /// </summary>
    public interface IRole
    {
        int RoleID { get; set; }

        string RoleName { get; set; }
    }
}
