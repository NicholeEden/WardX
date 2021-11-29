using System.Collections.Generic;
using WARDxAPI.Model.Interface.Profile;

namespace WARDxAPI.Model.Profile
{
    public class Timeline : ITimeline
    {
        public string LabelTitile { get; set; }
        public List<ITimelineItem> TimelineItems { get; set; }
    }
}