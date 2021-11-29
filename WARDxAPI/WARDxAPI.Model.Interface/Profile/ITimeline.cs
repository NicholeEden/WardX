using System.Collections.Generic;

namespace WARDxAPI.Model.Interface.Profile
{
    /// <summary>
    /// Defines a single time-line item
    /// </summary>
    public interface ITimeline
    {
        /// <summary>
        /// Defines the section title
        /// </summary>
        string LabelTitile { get; set; }

        /// <summary>
        /// Defines the content of the section
        /// </summary>
        List<ITimelineItem> TimelineItems { get; set; }
    }
}
