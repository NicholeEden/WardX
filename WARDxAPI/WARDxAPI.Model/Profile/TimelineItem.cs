using System.Collections.Generic;
using WARDxAPI.Model.Interface.Profile;

namespace WARDxAPI.Model.Profile
{
    public class TimelineItem : ITimelineItem
    {
        public string ItemHeader { get; set; }
        public FontAwesome FontawesomeIcon { get; set; }
        public string DateTime { get; set; }
        public List<string> ContentBody { get; set; }
    }
}
