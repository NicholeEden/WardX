using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WARDxAPI.Interface
{
    /// <summary>
    /// Defines the methods to implement for authentication
    /// </summary>
    public interface IAccountController
    {
        /// <summary>
        /// An HTTP Get to return the view for login in
        /// </summary>
        /// <returns></returns>
        IActionResult Login();

        void ClockIn(int StaffID);

        /// <summary>
        /// An HTTP Get to return the view for login out
        /// </summary>
        /// <returns></returns>
        IActionResult Logout();

        void ClockOut(int StaffID);

        /// <summary>
        /// An HTTP Post to return the view for confirming a logout
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<IActionResult> Logout(string returnUrl, string userName);
    }
}