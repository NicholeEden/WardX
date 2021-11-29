namespace EFCore.Interface
{
    /// <summary>
    /// Defines the database fields present in the WARDx User Role table
    /// </summary>
    public interface IUserRole
    {
        int UserID { get; set; }
        int RoleID { get; set; }
    }
}
