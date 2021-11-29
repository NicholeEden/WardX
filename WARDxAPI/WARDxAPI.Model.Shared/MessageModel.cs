using WARDxAPI.Model.Interface;

namespace WARDxAPI.Model.Shared
{
    public class MessageModel : IMessageModel
    {
        public string SenderName { get; set; }
        public string MessageText { get; set; }
        public string Time { get; set; }
    }
}
