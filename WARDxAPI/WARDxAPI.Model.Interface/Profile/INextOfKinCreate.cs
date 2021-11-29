using EFCore.Interface;
using System.Collections.Generic;

namespace WARDxAPI.Model.Interface.Profile
{
    /// <summary>
    /// Defines the properties for the Profile/Create - Next of Kin Information view
    /// </summary>
    public interface INextOfKinCreate : INextOfKin
    {
        /// <summary>
        /// Returns a list of suburb values for the select element
        /// </summary>
        Dictionary<string, string> SuburbList { get; set; }

        /// <summary>
        /// Defines the status box information
        /// </summary>
        IStatusBoxModel Status { get; set; }
    }
}