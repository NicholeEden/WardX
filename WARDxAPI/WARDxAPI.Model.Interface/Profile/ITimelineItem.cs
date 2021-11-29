using System.Collections.Generic;

namespace WARDxAPI.Model.Interface.Profile
{
    /// <summary>
    /// Defines the time-line item content
    /// </summary>
    public interface ITimelineItem
    {
        /// <summary>
        /// Defines the item header description
        /// </summary>
        string ItemHeader { get; set; }

        /// <summary>
        /// Defines the icon name
        /// </summary>
        FontAwesome FontawesomeIcon { get; set; }

        /// <summary>
        /// Defines the date and time of the record
        /// </summary>
        string DateTime { get; set; }

        List<string> ContentBody { get; set; }
    }

    public enum FontAwesome
    {
        bed,
        medkit,
        share,
        signin,
        signout
    }
}
