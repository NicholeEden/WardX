namespace WARDxAPI.Model.Interface
{
    /// <summary>
    /// This interface defines the content to be displayed in a select input
    /// </summary>
    public interface ISelectOption
    {
        /// <summary>
        /// Defines the id value to be used
        /// </summary>
        string Key { get; set; }

        /// <summary>
        /// Defines the diplay value to be used
        /// </summary>
        string Value { get; set; }

        /// <summary>
        /// Defines the display value for subtext
        /// </summary>
        string Subtext { get; set; }
    }
}
