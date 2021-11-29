using WARDxAPI.Model.Interface.Profile;

namespace WARDxAPI.Model.Interface
{
    /// <summary>
    /// Defines a model for displaying time-lines
    /// </summary>
    public interface IProfileTimelineModel
    {
        /// <summary>
        /// Defines referral events
        /// </summary>
        ITimeline ReferralTimeline { get; set; }

        /// <summary>
        /// Defines admission events
        /// </summary>
        ITimeline AdmissionTimeline { get; set; }

        /// <summary>
        /// Defines discharge events
        /// </summary>
        ITimeline DischargeTimeline { get; set; }

        /// <summary>
        /// Defines treatment events
        /// </summary>
        ITimeline TreatmentTimeline { get; set; }

        /// <summary>
        /// Defines movement events
        /// </summary>
        ITimeline MovementTimeline { get; set; }
    }
}
