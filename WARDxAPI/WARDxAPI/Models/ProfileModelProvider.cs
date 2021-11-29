using BusinessLogic.Model;
using EFCore.Interface;
using System.Collections.Generic;
using WARDxAPI.Interface;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Profile;
using WARDxAPI.Model.Shared;

namespace WARDxAPI.Models
{
    public class ProfileModelProvider : IProfileModelProvider
    {
        public ProfileModelProvider(
            IProfileSearchModel searchModel,
            IProfileCreateModel createModel,
            IProfileDetailsModel detailsModel,
            IProfileTimelineModel timelineModel,
            IProfileReferModel referModel)
        {
            SearchModel = searchModel;
            CreateModel = createModel;
            DetailsModel = detailsModel;
            TimelineModel = timelineModel;
            ReferModel = referModel;
        }

        public IProfileSearchModel SearchModel { get; set; }
        public IProfileCreateModel CreateModel { get; set; }
        public IProfileDetailsModel DetailsModel { get; set; }
        public IProfileReferModel ReferModel { get; }
        public IProfileTimelineModel TimelineModel { get; set; }

        public void SetupAidSession(
            IMedicalAid aid,
            IMedicalAidCreate model)
        {
            model.MedicalAidPlanID = aid.MedicalAidPlanID;
            model.MedicalAidSchemeID = aid.MedicalAidSchemeID;
            model.MemberNumber = aid.MemberNumber;
            model.PrincipalFirstName = aid.PrincipalFirstName;
            model.PrincipalLastName = aid.PrincipalLastName;
            model.DependantCode = aid.DependantCode;
        }

        public void SetupConfirmCreate(
            IPatient patient,
            INextOfKin kin,
            IMedicalAid aid,
            IConfirmCreate model)
        {
            model.PatientGender = patient.Gender;
            model.PatientName = patient.FirstName + " " + patient.LastName;
            model.Relationship = kin.Relationship;
            model.KinGender = kin.Gender;
            model.KinName = kin.FirstName + " " + kin.LastName;

            var plan = (MedicalAidPlans)aid.MedicalAidPlanID;
            model.MedicalAidPlan = plan.ToString();

            var scheme = (MedicalAidSchemes)aid.MedicalAidSchemeID;
            model.MedicalAidScheme = scheme.ToString();
            model.isValid = true;
        }

        public void SetupCreateModel(
            IProfileCreateModel model,
            Dictionary<string, string> suburb,
            Dictionary<string, string> plan,
            Dictionary<string, string> scheme,
            bool isPatientValid,
            bool isKinValid,
            bool isMedAidValid)
        {
            // populate list of suburb options
            model.PatientCreate.SuburbList = suburb;
            model.NextOfKinCreate.SuburbList = suburb;
            // populate list of medical aid plan and scheme
            model.MedicalAidCreate.PlanList = plan;
            model.MedicalAidCreate.SchemeList = scheme;

            // new instance of 'List<IStatusBoxModel>'
            var boxes = new List<IStatusBoxModel>();
            // patient status
            CreateModel.PatientCreate.Status.isVerified = isPatientValid;
            boxes.Add(CreateModel.PatientCreate.Status);
            // next of kin status
            CreateModel.NextOfKinCreate.Status.isVerified = isKinValid;
            boxes.Add(CreateModel.NextOfKinCreate.Status);
            // medical aid status
            CreateModel.MedicalAidCreate.Status.isVerified = isMedAidValid;
            boxes.Add(CreateModel.MedicalAidCreate.Status);
            // add status data
            CreateModel.StatusBoxes = boxes;
        }

        public void SetupDiagnosisSession(
            IDiagnosis diagnosis,
            IPatientDiagnosis model)
        {
            model.DiagnosedBy = diagnosis.DiagnosedBy;
            model.DiagnosisDate = diagnosis.DiagnosisDate;
            model.DiagnosisDetals = diagnosis.DiagnosisDetals;
            model.DiagnosisID = diagnosis.DiagnosisID;
            model.MedicalConditionID = diagnosis.MedicalConditionID;
        }

        public void SetupKinSession(
            INextOfKin kin,
            INextOfKinCreate model)
        {
            model.AddressLine1 = kin.AddressLine1;
            model.AddressLine2 = kin.AddressLine2;
            model.EmailAddress = kin.EmailAddress;
            model.FirstName = kin.FirstName;
            model.Gender = kin.Gender;
            model.LastName = kin.LastName;
            model.MobileNumber = kin.MobileNumber;
            model.Relationship = kin.Relationship;
            model.SuburbID = kin.SuburbID;
        }

        public void SetupPatientSession(
            IPatient patient,
            IPatientCreate model)
        {
            model.AddressLine1 = patient.AddressLine1;
            model.AddressLine2 = patient.AddressLine2;
            // TODO: fix date format as string
            model.EmailAddress = patient.EmailAddress;
            model.FirstName = patient.FirstName;
            model.Gender = patient.Gender;
            model.IDNumber = patient.IDNumber;
            model.LastName = patient.LastName;
            model.MobileNumber = patient.MobileNumber;
            model.SuburbID = patient.SuburbID;
        }

        public void SetupReferModel(
            IProfileReferModel model,
            Dictionary<string, string> condition,
            List<Patient> patients,
            bool isDiagnosisValid,
            bool isReferralValid)
        {
            // load select options
            model.PatientDiagnosis.ConditionList = condition;

            var selectOptions = new List<ISelectOption>();
            foreach (var patient in patients)
            {
                var option = new SelectOption();
                option.Key = patient.PatientID.ToString();
                option.Value = patient.FirstName + " " + patient.LastName;
                option.Subtext = patient.Gender.ToString();
                selectOptions.Add(option);
            }
            model.PatientReferral.PatientList = selectOptions;

            // new instance of 'List<IStatusBoxModel>'
            var boxes = new List<IStatusBoxModel>();
            // diagnosis status
            model.PatientDiagnosis.Status.isVerified = isDiagnosisValid;
            boxes.Add(model.PatientDiagnosis.Status);
            // diagnosis status
            model.PatientReferral.Status.isVerified = isReferralValid;
            boxes.Add(ReferModel.PatientReferral.Status);
            // add status data
            model.StatusBoxes = boxes;
        }

        public void SetupReferralSession(
            IReferral referral,
            IPatientReferral model)
        {
            model.AdmissionDate = referral.AdmissionDate;
            model.DiagnosisID = referral.DiagnosisID;
            model.PatientID = referral.PatientID;
            model.Reason = referral.Reason;
            model.ReferralID = referral.ReferralID;
            model.ReferringDoctorID = referral.ReferringDoctorID;
            model.SpecialistID = referral.SpecialistID;
        }

        public void SetupSubmitModel(
            ISubmitReferral model,
            IDiagnosis diagnosis,
            IReferral referral,
            Patient patient,
            Doctor GPdoctor,
            Doctor specialist)
        {
            model.GPName = GPdoctor.FirstName + " " + GPdoctor.LastName;
            model.GPPracticeNumber = GPdoctor.PracticeNumber;
            model.PatientGender = patient.Gender;
            model.PatientName = patient.FirstName + " " + patient.LastName;
            model.SpecialistName = specialist.FirstName + " " + specialist.LastName;
            model.SpecialistPracticeNumber = specialist.PracticeNumber;
            model.isValid = true;
        }
    }
}
