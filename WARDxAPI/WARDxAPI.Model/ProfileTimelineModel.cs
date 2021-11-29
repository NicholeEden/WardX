using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Profile;

namespace WARDxAPI.Model
{
    public class ProfileTimelineModel : IProfileTimelineModel
    {
        public ProfileTimelineModel(
            ITimeline referral,
            ITimeline admission,
            ITimeline discharge,
            ITimeline treatment,
            ITimeline movement)
        {
            ReferralTimeline = referral;
            AdmissionTimeline = admission;
            DischargeTimeline = discharge;
            TreatmentTimeline = treatment;
            MovementTimeline = movement;
        }
        public ITimeline ReferralTimeline { get; set; }
        public ITimeline AdmissionTimeline { get; set; }
        public ITimeline DischargeTimeline { get; set; }
        public ITimeline TreatmentTimeline { get; set; }
        public ITimeline MovementTimeline { get; set; }
    }
}
