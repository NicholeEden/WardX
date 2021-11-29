namespace WARDxAPI.Model.Interface
{
    /// <summary>
    /// This defines the parameters needed to display values in the messages pop-up
    /// </summary>
    public interface IMessageModel
    {
        /// <summary>
        /// Defines the person who create the message
        /// </summary>
        string SenderName { get; set; }

        /// <summary>
        /// Defines the content of the message
        /// </summary>
        string MessageText { get; set; }

        /// <summary>
        /// Defines the time the message was sent
        /// </summary>
        string Time { get; set; }
    }
}
