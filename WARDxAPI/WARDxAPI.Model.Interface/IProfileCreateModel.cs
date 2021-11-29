using System.Collections.Generic;
using WARDxAPI.Model.Interface.Profile;

namespace WARDxAPI.Model.Interface
{
    /// <summary>
    /// Defiles the parameters needed by the Profile/Create view
    /// </summary>
    public interface IProfileCreateModel
    {
        IPatientCreate PatientCreate { get; set; }
        INextOfKinCreate NextOfKinCreate { get; set; }
        IMedicalAidCreate MedicalAidCreate { get; set; }
        IConfirmCreate ConfirmCreate { get; set; }
        IAlertModel Alert { get; set; }
        List<IStatusBoxModel> StatusBoxes { get; set; }
    }
}