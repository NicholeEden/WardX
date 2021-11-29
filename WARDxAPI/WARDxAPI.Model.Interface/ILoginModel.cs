namespace WARDxAPI.Model.Interface
{
    /// <summary>
    /// This defines the parameters needed by the Account/Login view
    /// </summary>
    public interface ILoginModel
    {
        /// <summary>
        /// Defines the username / employee id
        /// </summary>
        string EmployeeID { get; set; }

        /// <summary>
        /// Defines the user password
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// Defines if cookies are kept after seession expires
        /// </summary>
        bool RememberMe { get; set; }
    }
}
