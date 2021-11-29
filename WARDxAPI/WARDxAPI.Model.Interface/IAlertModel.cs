namespace WARDxAPI.Model.Interface
{
    /// <summary>
    /// Defines the properties in the alert model
    /// </summary>
    public interface IAlertModel
    {
        string Header { get; set; }
        string Content { get; set; }
        AlertModelType Type { get; set; }
    }

    /// <summary>
    /// Defines the alert type to display
    /// </summary>
    public enum AlertModelType
    {
        None,
        Success,
        Info,
        Warning,
        Danger
    }
}