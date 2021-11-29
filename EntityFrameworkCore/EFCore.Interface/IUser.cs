namespace EFCore.Interface
{
    /// <summary>
    /// Defines the database fields present in the WARDx User table
    /// </summary>
    public interface IUser
    {
        int UserID { get; set; }
        string UserName { get; set; }
        string PasswordHash { get; set; }

        /// <summary>
        /// Defines the display icon name for the WARDx User
        /// </summary>
        string Avatar { get; set; }
    }
}
