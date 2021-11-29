using WARDxAPI.Model.Interface;

namespace WARDxAPI.Model.Shared
{
    /// <summary>
    /// Each instance of this model will represent an entry in the Control Sidebar [Right]
    /// </summary>
    public class ControlSidebarModel : IControlSidebarModel
    {
        public string Header { get; set; }
        public string Content { get; set; }
    }
}