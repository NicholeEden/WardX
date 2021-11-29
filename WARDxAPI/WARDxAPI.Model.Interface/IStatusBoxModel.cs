namespace WARDxAPI.Model.Interface
{
    /// <summary>
    /// Defines the properties required to display status box content
    /// </summary>
    public interface IStatusBoxModel
    {
        /// <summary>
        /// Returns true if the model data provided is valid
        /// </summary>
        bool isVerified { get; set; }

        /// <summary>
        /// A description of the status section
        /// </summary>
        string SectionName { get; set; }
    }
}
