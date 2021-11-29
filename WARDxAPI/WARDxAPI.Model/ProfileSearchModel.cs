using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Profile;

namespace WARDxAPI.Model
{
    public class ProfileSearchModel : IProfileSearchModel
    {
        [Required]
        public string Keyword { get; set; }
        public List<IProfileSearchResult> SearchResults { get; set; }
        public IAlertModel Alert { get; set; }
    }
}