using EFCore.Interface;
using System.Collections.Generic;

namespace WARDxAPI.Model.Interface.Profile
{
    /// <summary>
    /// Defines the properties for the Profile/Create - Medical Aid Information view
    /// </summary>
    public interface IMedicalAidCreate : IMedicalAid
    {
        /// <summary>
        /// Returns a list of Medical Aid Scheme values for the select element
        /// </summary>
        Dictionary<string, string> SchemeList { get; set; }

        /// <summary>
        /// Returns a list of Medical Aid Plan values for the select element
        /// </summary>
        Dictionary<string, string> PlanList { get; set; }

        /// <summary>
        /// Defines the status box information
        /// </summary>
        IStatusBoxModel Status { get; set; }
    }
}
