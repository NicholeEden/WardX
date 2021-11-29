using BusinessLogic.Model;
using EFCore.Interface;
using System.Collections.Generic;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Profile;

namespace WARDxAPI.Interface
{
    /// <summary>
    /// Defines the models required by the Patient Profile Controller and Views
    /// </summary>
    public interface IProfileModelProvider
    {
        /// <summary>
        /// Provides a model for the view 'Profile/Search'
        /// </summary>
        IProfileSearchModel SearchModel { get; }

        /// <summary>
        /// Provides a model for the view 'Profile/Create'
        /// </summary>
        IProfileCreateModel CreateModel { get; }

        /// <summary>
        /// Configures the model for the 'Profile/Create
        /// </summary>
        /// <param name="model"></param>
        /// <param name="suburb"></param>
        /// <param name="plan"></param>
        /// <param name="scheme"></param>
        /// <param name="isPatientValid"></param>
        /// <param name="isKinValid"></param>
        /// <param name="isMedAidValid"></param>
        void SetupCreateModel(
            IProfileCreateModel model,
            Dictionary<string, string> suburb,
            Dictionary<string, string> plan,
            Dictionary<string, string> scheme,
            bool isPatientValid,
            bool isKinValid,
            bool isMedAidValid);

        /// <summary>
        /// Configures the model with data for the current session
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="model"></param>
        void SetupPatientSession(
            IPatient patient,
            IPatientCreate model);

        /// <summary>
        /// Configures the model with data for the current session
        /// </summary>
        /// <param name="kin"></param>
        /// <param name="model"></param>
        void SetupKinSession(
            INextOfKin kin,
            INextOfKinCreate model);

        /// <summary>
        /// Configures the model with data for the current session
        /// </summary>
        /// <param name="aid"></param>
        /// <param name="model"></param>
        void SetupAidSession(
            IMedicalAid aid,
            IMedicalAidCreate model);

        /// <summary>
        /// Configures the model with data for the current session
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="kin"></param>
        /// <param name="aid"></param>
        /// <param name="model"></param>
        void SetupConfirmCreate(
            IPatient patient,
            INextOfKin kin,
            IMedicalAid aid,
            IConfirmCreate model);

        /// <summary>
        /// Provides a model for the view 'Profile/Details'
        /// </summary>
        IProfileDetailsModel DetailsModel { get; }

        /// <summary>
        /// Provides a model for the 'Profile/Refer' process
        /// </summary>
        IProfileReferModel ReferModel { get; }

        /// <summary>
        /// Configures the model with data for the current session
        /// </summary>
        /// <param name="diagnosis"></param>
        /// <param name="model"></param>
        void SetupDiagnosisSession(
            IDiagnosis diagnosis,
            IPatientDiagnosis model);

        /// <summary>
        /// Configures the model with data for the current session
        /// </summary>
        /// <param name="referral"></param>
        /// <param name="model"></param>
        void SetupReferralSession(
            IReferral referral,
            IPatientReferral model);

        /// <summary>
        /// Configures the model for the 'Profile/Refer
        /// </summary>
        /// <param name="model"></param>
        /// <param name="condition"></param>
        /// <param name="patients"></param>
        /// <param name="isDiagnosisValid"></param>
        /// <param name="isReferralValid"></param>
        void SetupReferModel(
            IProfileReferModel model,
            Dictionary<string, string> condition,
            List<Patient> patients,
            bool isDiagnosisValid,
            bool isReferralValid);

        /// <summary>
        /// Configures the model with data from the current session
        /// </summary>
        /// <param name="model"></param>
        /// <param name="diagnosis"></param>
        /// <param name="referral"></param>
        /// <param name="patient"></param>
        /// <param name="GPdoctor"></param>
        /// <param name="specialist"></param>
        void SetupSubmitModel(
            ISubmitReferral model,
            IDiagnosis diagnosis,
            IReferral referral,
            Patient patient,
            Doctor GPdoctor,
            Doctor specialist);

        /// <summary>
        /// Provides a model for the view 'Profile/Monitor'
        /// </summary>
        IProfileTimelineModel TimelineModel { get; set; }
    }
}
