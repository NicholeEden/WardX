namespace WARDxAPI.Model.Interface
{
    /// <summary>
    /// Defines the properties for a select input with subtext
    /// </summary>
    public interface ISubtextDropdown
    {
        /// <summary>
        /// Defines the key value
        /// </summary>
        string Key { get; set; }

        /// <summary>
        /// Defines the display value
        /// </summary>
        string Display { get; set; }

        /// <summary>
        /// Defines the description text for the display value
        /// </summary>
        string SubText { get; set; }
    }
}