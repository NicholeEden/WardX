using WARDxAPI.Model.Interface;

namespace WARDxAPI.Models
{
    public class HomeModel : IHomeModel
    {
        public int SmokeBreak { get; set; }
        public int Surgery { get; set; }
        public int BloodTest { get; set; }
        public int XRay { get; set; }
        public int PendingReferrals { get; set; }
        public int AdmittedPatients { get; set; }
        public int DischargedPatients { get; set; }
        public int CheckedIn { get; set; }
        public int CheckedOut { get; set; }
    }
}
