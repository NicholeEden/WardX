using EFCore.Interface;
using System.Collections.Generic;

namespace WARDxAPI.Model.Interface.Profile
{
    /// <summary>
    /// Defines the properties for the Profile/Create - Personal Information view
    /// </summary>
    public interface IPatientCreate : IPatient
    {
        /// <summary>
        /// Returns a list of suburb values for the select element
        /// </summary>
        Dictionary<string, string> SuburbList { get; set; }

        /// <summary>
        /// Stores DOB input for processing
        /// </summary>
        string DOBinput { get; set; }

        /// <summary>
        /// Defines the status box information
        /// </summary>
        IStatusBoxModel Status { get; set; }
    }
}
