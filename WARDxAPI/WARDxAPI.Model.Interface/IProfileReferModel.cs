using System.Collections.Generic;
using WARDxAPI.Model.Interface.Profile;

namespace WARDxAPI.Model.Interface
{
    /// <summary>
    /// Defines the parameters required for the patient referral process
    /// </summary>
    public interface IProfileReferModel
    {
        IPatientDiagnosis PatientDiagnosis { get; set; }
        IPatientReferral PatientReferral { get; set; }
        ISubmitReferral SubmitReferral { get; set; }
        IAlertModel Alert { get; set; }
        List<IStatusBoxModel> StatusBoxes { get; set; }
    }
}
