using System.Collections.Generic;
using WARDxAPI.Model.Interface.Profile;

namespace WARDxAPI.Model.Interface
{
    /// <summary>
    /// This defines the parameters needed by the Profile/Search view
    /// </summary>
    public interface IProfileSearchModel
    {
        /// <summary>
        /// Defines the property for search input keyword(s)
        /// </summary>
        string Keyword { get; set; }
        List<IProfileSearchResult> SearchResults { get; set; }
        IAlertModel Alert { get; set; }
    }
}