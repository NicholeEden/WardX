namespace WARDxAPI.Model.Interface
{
    public interface IHomeModel
    {
        int SmokeBreak { get; set; }
        int Surgery { get; set; }
        int BloodTest { get; set; }
        int XRay { get; set; }
        int PendingReferrals { get; set; }
        int AdmittedPatients { get; set; }
        int DischargedPatients { get; set; }
        int CheckedIn { get; set; }
        int CheckedOut { get; set; }
    }
}