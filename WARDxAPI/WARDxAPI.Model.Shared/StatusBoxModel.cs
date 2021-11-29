using WARDxAPI.Model.Interface;

namespace WARDxAPI.Model.Shared
{
    public class StatusBoxModel : IStatusBoxModel
    {
        public bool isVerified { get; set; }
        public string SectionName { get; set; }
    }
}
