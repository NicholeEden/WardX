namespace WARDxAPI.Model.Interface
{
    /// <summary>
    /// A model for the Control Sidebar [Right] content
    /// </summary>
    public interface IControlSidebarModel
    {
        /// <summary>
        /// The title of the section
        /// </summary>
        string Header { get; set; }

        /// <summary>
        /// The content of the section
        /// </summary>
        string Content { get; set; }
    }
}
