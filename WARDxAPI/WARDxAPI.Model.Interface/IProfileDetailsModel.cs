using WARDxAPI.Model.Interface.Profile;

namespace WARDxAPI.Model.Interface
{
    /// <summary>
    /// This defines the parameters needed by the Profile/Details view
    /// </summary>
    public interface IProfileDetailsModel
    {
        IAlertModel Alert { get; set; }

        IPatientInfo PatientInfo { get; set; }
    }
}
