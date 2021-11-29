using Microsoft.AspNetCore.Mvc;

namespace WARDxAPI.Interface
{
    /// <summary>
    /// Defines the methods implemented in the Home controller
    /// </summary>
    public interface IHomeController
    {
        /// <summary>
        /// An HTTP Get to return the view for global errors
        /// </summary>
        /// <returns></returns>
        IActionResult Error();

        /// <summary>
        /// An HTTP Get to return the view for the landing page
        /// </summary>
        /// <returns></returns>
        IActionResult Index();
    }
}