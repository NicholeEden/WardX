using WARDxAPI.Model.Interface;

namespace WARDxAPI.Model.Shared
{
    public class AlertModel : IAlertModel
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public AlertModelType Type { get; set; }
    }
}