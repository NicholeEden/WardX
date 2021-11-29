using BusinessLogic.Interface;
using BusinessLogic.Model;
using EFCore.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WARDxAPI.Interface;
using WARDxAPI.Model;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Profile;
using WARDxAPI.Model.Profile;
using WARDxAPI.Model.Shared;

namespace WARDxAPI.Controllers
{
    [Authorize]
    public class ProfileController :
        Controller,
        IProfileController
    {
        private IProfileModelProvider _modelProvider;
        private readonly IPatientProcessor _patientProcessor;
        private readonly IDropdownProcessor _dropdownProcessor;
        private readonly IEmailSender _sender;
        private readonly IBusinessLogic _logic;
        private readonly ILogger<ProfileController> _logger;
        private IAlertModel _alert;

        public ProfileController(
            IPatientProcessor patientProcessor,
            IDropdownProcessor dropdownProcessor,
            IEmailSender sender,
            IBusinessLogic logic,
            ILogger<ProfileController> logger)
        {
            _modelProvider = APIConfig.ResolvePatientProfileModel();
            _alert = APIConfig.ResolveAlertModel();
            _patientProcessor = patientProcessor;
            _dropdownProcessor = dropdownProcessor;
            _sender = sender;
            _logic = logic;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Search()
        {
            // browser tab title
            ViewBag.Title = "Search";

            // load error messages
            var error = HttpContext.Session.Get<AlertModel>(nameof(IAlertModel));
            if (error != null)
            {
                _modelProvider.SearchModel.Alert = error;
            }
            else
            {
                _modelProvider.SearchModel.Alert = _alert;
            }

            // clear all session data
            HttpContext.Session.Clear();

            return View(_modelProvider.SearchModel);
        }

        [HttpPost]
        public IActionResult Search(ProfileSearchModel model)
        {
            // browser tab title
            ViewBag.Title = "Search";

            // verify data
            if (ModelState.IsValid)
            {
                // get any matching patients
                var patients = _patientProcessor.GetPatients(model.Keyword);

                // no patients found
                if (patients.Count < 1)
                {
                    // create error message
                    _alert.Type = AlertModelType.Warning;
                    _alert.Header = "Search Complete.";
                    _alert.Content = $"No results matching ( { model.Keyword } ) were found. Please try again.";
                    // add error message
                    model.Alert = _alert;

                    // return model with error
                    return View(model);
                }

                // initialize the result list
                model.SearchResults = new List<IProfileSearchResult>();

                // populate the search result object
                foreach (var patient in patients)
                {
                    // new instance of search result
                    var result = new ProfileSearchResult();
                    // add patient
                    result.Patient = patient;
                    // get patient's suburb
                    result.Suburb = _patientProcessor.GetSuburb(patient.SuburbID);
                    // get patient's medical aid
                    result.MedicalAid = _patientProcessor.GetMedicalAid(patient.PatientID);
                    // get patient's next of kin
                    result.NextOfKin = _patientProcessor.GetNextOfKin(patient.PatientID);
                    // check for referral
                    var list = _patientProcessor.GetPatientsNoReferral();
                    result.hasReferral = list.Find(p => p.PatientID == patient.PatientID) == null;
                    // add to the list
                    model.SearchResults.Add(result);
                }

                // create info message
                _alert.Type = AlertModelType.Info;
                _alert.Header = "Search Complete.";
                _alert.Content = $"There were ( { model.SearchResults.Count } ) results found.";
                // add info message
                model.Alert = _alert;

                // return model with new data
                return View(model);
            }

            // create error message
            _alert.Type = AlertModelType.Danger;
            _alert.Header = "Search Error.";
            _alert.Content = "Invalid data was provided. Please use key words matching the patient's name or surname.";
            // add error message
            model.Alert = _alert;

            // return model with error
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            // browser tab title
            ViewBag.Title = "Details";

            // load error messages
            var error = HttpContext.Session.Get<AlertModel>(nameof(IAlertModel));
            if (error != null)
            {
                _modelProvider.DetailsModel.Alert = error;
            }

            // get any matching patient
            var patient = _patientProcessor.GetPatient(id);

            // no match found
            if (patient is null)
            {
                // create error message
                _alert.Type = AlertModelType.Danger;
                _alert.Header = "Data not found.";
                _alert.Content = $"No details were found on the database for the patient. Please try again.";
                // add session error
                HttpContext.Session.Set<IAlertModel>(nameof(IAlertModel), _alert);

                // return user to search
                return RedirectToAction(nameof(IProfileController.Search));
            }

            // new instance of PatientInfo
            var info = new PatientInfo();
            // add patient info
            info.Patient = patient;
            info.ReturnID = patient.PatientID;
            info.EmailAddress = patient.EmailAddress;
            // add patient suburb info
            info.PatientSuburb = _patientProcessor.GetSuburb(patient.SuburbID);
            // add next of kin info
            info.NextOfKin = _patientProcessor.GetNextOfKin(patient.PatientID);
            // add next of kin suburb info
            var key = info.NextOfKin.SuburbID;
            info.KinSuburb = _patientProcessor.GetSuburb(key);
            // add medical aid info
            info.MedicalAid = _patientProcessor.GetMedicalAid(patient.PatientID);
            // get medical aid plan
            var planID = info.MedicalAid.MedicalAidPlanID;
            info.MedicalAidPlan = _patientProcessor.GetAidPlan((int)planID);
            // get medical aid scheme
            var schemeID = info.MedicalAid.MedicalAidSchemeID;
            info.MedicalAidScheme = _patientProcessor.GetAidScheme((int)schemeID);
            // get referral to find linked diagnosis details
            var referral = _patientProcessor.GetReferral(patient.PatientID);
            if (referral != null)
            {
                var diagnosis = _patientProcessor.GetDiagnosis(referral.DiagnosisID);
                info.Diagnosis = diagnosis;
                // get medical condition
                var condition = _patientProcessor.GetMedicalCondition(diagnosis.MedicalConditionID);
                info.MedicalCondition = condition;
                // get doctor
                var gp = _logic.GetGPDoctor(diagnosis.DiagnosedBy);
                info.GPDoctor = gp;
                var specialist = _logic.GetSpecialistDoctor(referral.SpecialistID);
                info.Specialist = specialist;
            }

            // add data
            _modelProvider.DetailsModel.PatientInfo = info;

            // return mode with data
            return View(_modelProvider.DetailsModel);
        }

        public IActionResult Monitor(int id)
        {
            // browser tab title
            ViewBag.Title = "Monitor";

            // get any matching patient
            
            var referrals = _patientProcessor.GetReferralTimelines(id);

            // no match found
            if (referrals.Count < 1)
            {
                // create error message
                _alert.Type = AlertModelType.Warning;
                _alert.Header = "Data not found.";
                _alert.Content = $"No details were found on the database for the patient. Please ensure patient has a linked referral and try again.";
                // add session error
                HttpContext.Session.Set<IAlertModel>(nameof(IAlertModel), _alert);

                // return user to search
                return RedirectToAction(nameof(IProfileController.Search));
            }

            // new time-line instance
            var info = new Timeline();
            // name of time-line category
            info.LabelTitile = "Referral";
            // new time-line item list instance
            var timelineItems = new List<ITimelineItem>();
            // iterate through referrals
            foreach (var referral in referrals)
            {
                // new time-line item instance
                var item = new TimelineItem();
                // define the icon
                item.FontawesomeIcon = FontAwesome.share;
                // item header
                item.ItemHeader = "Referral Details";
                // date of item
                item.DateTime = referral.DiagnosisDate.ToString("dd/MMM/yyy");
                // new body item list instance
                var body = new List<string>();
                // add body item
                var doctor = _logic.GetGPDoctor(referral.ReferringDoctorID);
                body.Add($"Referred by Dr. { doctor.FirstName } { doctor.LastName }.");
                // add body item
                var specialist = _logic.GetSpecialistDoctor(referral.SpecialistID);
                body.Add($"Referred to Dr. { specialist.FirstName } { specialist.LastName }.");
                // add body item
                body.Add(referral.Reason);
                // add body item
                body.Add(referral.isAdmitted ? "Referral approved" : "Referral is pending");
                // add body item to time-line
                item.ContentBody = body;
                // add time-line item to list
                timelineItems.Add(item);

                // new time-line item instance
                item = new TimelineItem();
                // define the icon
                item.FontawesomeIcon = FontAwesome.medkit;
                // item header
                item.ItemHeader = "Diagnosis Details";
                // date of item
                item.DateTime = referral.DiagnosisDate.ToString("dd/MMM/yyy");
                // new body item list instance
                body = new List<string>();
                // add body item
                doctor = _logic.GetGPDoctor(referral.DiagnosedBy);
                body.Add($"Diagnosed by Dr. { doctor.FirstName } { doctor.LastName }.");
                // add body item
                var condition = _patientProcessor.GetMedicalCondition(referral.MedicalConditionID);
                body.Add($"Diagnosed with: { condition.Name }");
                // add body item
                body.Add(referral.DiagnosisDetals);
                // add body item to time-line
                item.ContentBody = body;
                // add time-line item to list
                timelineItems.Add(item);
            }
            // add time-line item list to time-line
            info.TimelineItems = timelineItems;
            // add time-line to model
            _modelProvider.TimelineModel.ReferralTimeline = info;

            
            var admission = _logic.GetAdmissionFile(id);
            
            if (admission != null)
            {
                // new time-line instance
                info = new Timeline();
                // name of time-line category
                info.LabelTitile = "Admission";
                // new time-line item list instance
                timelineItems = new List<ITimelineItem>();
                // new time-line item instance
                var item = new TimelineItem();
                // define the icon
                item.FontawesomeIcon = FontAwesome.bed;
                // item header
                item.ItemHeader = "Admission Details";
                // date of item
                item.DateTime = admission.AdmissionDate.ToString("dd/MMM/yyy");
                // new body item list instance
                var body = new List<string>();
                // add body item
                var patient = _patientProcessor.GetPatient(id);
                body.Add($"{ patient.FirstName } { patient.LastName } was admitted.");
                // add body item
                var specialist = _logic.GetSpecialistDoctor(admission.AssignedSpecialistID);
                body.Add($"Assigned to Dr. { specialist.FirstName } { specialist.LastName }.");
                // add body item
                body.Add(admission.Notes);
                // add body item to time-line
                item.ContentBody = body;
                // add time-line item to list
                timelineItems.Add(item);
            }
            // add time-line item list to time-line
            info.TimelineItems = timelineItems;
            // add time-line to model
            _modelProvider.TimelineModel.AdmissionTimeline = info;


            if (admission != null)
            {
                var movements = _logic.GetPatientMovements().FindAll(m => m.AdmissionFileID == admission.AdmissionFileID);
                if (movements != null)
                {
                    // new time-line instance
                    info = new Timeline();
                    // name of time-line category
                    info.LabelTitile = "Movement";
                    // new time-line item list instance
                    timelineItems = new List<ITimelineItem>();
                    foreach (var movement in movements)
                    {
                        // new time-line item instance
                        var item = new TimelineItem();
                        // define the icon
                        item.FontawesomeIcon = FontAwesome.signout;
                        // item header
                        item.ItemHeader = "Check out Details";
                        // date of item
                        item.DateTime = movement.CheckOutTime.ToString("dd/MMM/yyy");
                        // new body item list instance
                        var body = new List<string>();
                        // add body item
                        var patient = _patientProcessor.GetPatient(id);
                        body.Add($"{ patient.FirstName } { patient.LastName } was checked out.");
                        // add body item
                        switch (movement.Reason)
                        {
                            case Reason.SmokeBreak:
                                body.Add($"Check out was for a smoke break.");
                                break;
                            case Reason.Surgery:
                                body.Add($"Check out was for a surgery.");
                                break;
                            case Reason.BloodTests:
                                body.Add($"Check out was for a blood test.");
                                break;
                            case Reason.XRays:
                                body.Add($"Check out was for an X-Ray.");
                                break;
                            default:
                                break;
                        }
                        // add body item to time-line
                        item.ContentBody = body;
                        // add time-line item to list
                        timelineItems.Add(item); 
                    }
                    // add time-line item list to time-line
                    info.TimelineItems = timelineItems;
                    // add time-line to model
                    _modelProvider.TimelineModel.MovementTimeline = info;
                }
            }

            if (admission.DischargeDate != null)
            {
                // new time-line instance
                info = new Timeline();
                // name of time-line category
                info.LabelTitile = "Discharge";
                // new time-line item list instance
                timelineItems = new List<ITimelineItem>();
                // new time-line item instance
                var item = new TimelineItem();
                // define the icon
                item.FontawesomeIcon = FontAwesome.bed;
                // item header
                item.ItemHeader = "Discharge Details";
                // date of item
                item.DateTime = admission.DischargeDate.ToString();
                // new body item list instance
                var body = new List<string>();
                // add body item
                var patient = _patientProcessor.GetPatient(id);
                body.Add($"{ patient.FirstName } { patient.LastName } was discharged.");
                // add body item
                var specialist = _logic.GetSpecialistDoctor(admission.AssignedSpecialistID);
                body.Add($"Discharged by Dr. { specialist.FirstName } { specialist.LastName }.");
                // add body item
                body.Add(admission.Notes);
                // add body item to time-line
                item.ContentBody = body;
                // add time-line item to list
                timelineItems.Add(item);                
            }
            // add time-line item list to time-line
            info.TimelineItems = timelineItems;
            // add time-line to model
            _modelProvider.TimelineModel.DischargeTimeline = info;


            return View(_modelProvider.TimelineModel);
        }

        [HttpPost]
        public IActionResult SendEmail(PatientInfo model)
        {
            // email has valid data
            if (ModelState.IsValid)
            {
                // get credentials
                var credentials = CredentialProvider.GetCredential(true);
                // send email
                var emailSent = _sender.SendEmail(
                    ClientType.Microsoft,
                    credentials,
                    credentials.UserName,
                    model.EmailAddress,
                    model.EmailHeader,
                    model.EmailBody);

                // create alert message
                if (emailSent)
                {
                    // create success message
                    _alert.Type = AlertModelType.Success;
                    _alert.Header = "Email Sent.";
                }
                else
                {
                    // create success message
                    _alert.Type = AlertModelType.Danger;
                    _alert.Header = "Email Failed.";
                    _alert.Content = $"The email was not sent successfully.";
                }
                // add session message
                HttpContext.Session.Set<IAlertModel>(nameof(IAlertModel), _alert);
            }

            // return to details
            return Redirect(nameof(IProfileController.Details) + "/" + model.ReturnID.ToString());
        }

        [HttpGet]
        public IActionResult Create()
        {
            // browser tab title
            ViewBag.Title = "Create";

            // variables for session data
            IPatient patient = HttpContext.Session.Get<Patient>(nameof(IPatient));
            var kinSession = (HttpContext.Session.Get<MedicalAid>(nameof(INextOfKin)) != null);
            var aidSession = (HttpContext.Session.Get<MedicalAid>(nameof(IMedicalAid)) != null);

            // load error messages
            var error = HttpContext.Session.Get<AlertModel>(nameof(IAlertModel));
            if (error != null)
            {
                _modelProvider.CreateModel.Alert = error;
            }

            if (patient is null)
            {
                // clear all session data
                HttpContext.Session.Clear();
            }
            else
            {
                // set session data to Patient Create model
                _modelProvider.SetupPatientSession(patient, _modelProvider.CreateModel.PatientCreate);
            }

            // configure Profile Create Model
            _modelProvider.SetupCreateModel(
                model: _modelProvider.CreateModel,
                suburb: _dropdownProcessor.GetSuburbs(),
                plan: _dropdownProcessor.GetMedicalAidPlans(),
                scheme: _dropdownProcessor.GetMedicalAidSchemes(),
                isPatientValid: patient != null,
                isKinValid: kinSession,
                isMedAidValid: aidSession);

            // return 'Profile/Create' view with model data
            return View(_modelProvider.CreateModel);
        }

        [HttpPost]
        public IActionResult Create(PatientCreate model)
        {
            // browser tab title
            ViewBag.Title = "Create";

            // validate date of birth
            var age = DateTime.Now.AddYears(-13);
            var validDate = model.DOB < age;
            var year = model.IDNumber.Substring(0, 2);
            var month = model.IDNumber.Substring(2, 2);
            var day = model.IDNumber.Substring(4, 2);
            validDate = (model.DOB == Convert.ToDateTime($"{ day }/{ month }/{ year }"));

            var match = _patientProcessor.GetPatients().Find(p => p.IDNumber == model.IDNumber);

            // 'Profile/Create' form created successfully
            if (ModelState.IsValid && validDate && match is null)
            {
                // create model with only 'IPatient' properties
                IPatient patient = model;
                // store model as session data
                HttpContext.Session.Set<IPatient>(nameof(IPatient), patient);

                // return 'Profile/NextofKin' view
                return RedirectToAction(nameof(NextofKin));
            }

            // 'Profile/Create' form invalid
            _modelProvider.CreateModel.PatientCreate = model;

            if (validDate == false)
            {
                // create error message
                _alert.Type = AlertModelType.Warning;
                _alert.Header = "Invalid Date of Birth.";
                _alert.Content = $"The provided ID Number ( { model.IDNumber } )" +
                    $" does not match the date of birth ( { model.DOBinput } ). Please review and try again.";
            }

            if (match != null)
            {
                // create error message
                _alert.Type = AlertModelType.Danger;
                _alert.Header = "Information Duplication.";
                _alert.Content = $"A patient with matching details already exists on the database.";
            }
            // add error message
            _modelProvider.CreateModel.Alert = _alert;

            // configure Profile Create Model
            _modelProvider.SetupCreateModel(
                model: _modelProvider.CreateModel,
                suburb: _dropdownProcessor.GetSuburbs(),
                plan: _dropdownProcessor.GetMedicalAidPlans(),
                scheme: _dropdownProcessor.GetMedicalAidSchemes(),
                isPatientValid: false,
                isKinValid: false,
                isMedAidValid: false);

            // return 'Profile/Create' view with model data
            return View(_modelProvider.CreateModel);
        }

        [HttpGet]
        public IActionResult NextofKin()
        {
            // browser tab title
            ViewBag.Title = "Create";

            // variables for session data
            INextOfKin kin = HttpContext.Session.Get<NextOfKin>(nameof(INextOfKin));
            var patientSession = (HttpContext.Session.Get<Patient>(nameof(IPatient)) != null);
            var aidSession = (HttpContext.Session.Get<MedicalAid>(nameof(IMedicalAid)) != null);

            // Get request from Medical Aid or Patient
            if (patientSession || aidSession)
            {
                // get session data
                if (kin != null)
                {
                    _modelProvider.SetupKinSession(kin, _modelProvider.CreateModel.NextOfKinCreate);
                }
            }
            else
            {
                // return 'Profile/Create' view
                return RedirectToAction(nameof(Create));
            }

            // configure Profile Create Model
            _modelProvider.SetupCreateModel(
                model: _modelProvider.CreateModel,
                suburb: _dropdownProcessor.GetSuburbs(),
                plan: _dropdownProcessor.GetMedicalAidPlans(),
                scheme: _dropdownProcessor.GetMedicalAidSchemes(),
                isPatientValid: patientSession,
                isKinValid: kin != null,
                isMedAidValid: aidSession);

            // return model with new data
            return View(_modelProvider.CreateModel);
        }

        [HttpPost]
        public IActionResult NextofKin(NextOfKinCreate model)
        {
            // browser tab title
            ViewBag.Title = "Create";

            // 'Profile/NextofKin' form created successfully
            if (ModelState.IsValid)
            {
                // create model with only 'INextOfKin' properties
                INextOfKin kin = model;
                // store model as session data
                HttpContext.Session.Set<INextOfKin>(nameof(INextOfKin), kin);

                // return 'Profile/MedicalAid' view
                return RedirectToAction(nameof(MedicalAid));
            }

            // 'Profile/NextofKin' form invalid
            _modelProvider.CreateModel.NextOfKinCreate = model;

            // create error message
            _alert.Type = AlertModelType.Danger;
            _alert.Header = "Unable to validate.";
            _alert.Content = $"Please review and try again.";
            // add error message
            _modelProvider.CreateModel.Alert = _alert;

            // session variables
            var patientSession = (HttpContext.Session.Get<Patient>(nameof(IPatient)) != null);
            var aidSession = (HttpContext.Session.Get<MedicalAid>(nameof(IMedicalAid)) != null);

            // configure Profile Create Model
            _modelProvider.SetupCreateModel(
                model: _modelProvider.CreateModel,
                suburb: _dropdownProcessor.GetSuburbs(),
                plan: _dropdownProcessor.GetMedicalAidPlans(),
                scheme: _dropdownProcessor.GetMedicalAidSchemes(),
                isPatientValid: patientSession,
                isKinValid: false,
                isMedAidValid: aidSession);

            // return 'Profile/Create' view with model data
            return View(_modelProvider.CreateModel);
        }

        [HttpGet]
        public IActionResult MedicalAid()
        {
            // browser tab title
            ViewBag.Title = "Create";

            // variables for session data
            IMedicalAid aid = HttpContext.Session.Get<MedicalAid>(nameof(IMedicalAid));
            var patientSession = (HttpContext.Session.Get<Patient>(nameof(IPatient)) != null);
            var kinSession = (HttpContext.Session.Get<NextOfKin>(nameof(INextOfKin)) != null);

            // Get request from Next of Kin
            if (kinSession && aid != null)
            {
                // get session data
                _modelProvider.SetupAidSession(aid, _modelProvider.CreateModel.MedicalAidCreate);
            }

            // configure Profile Create Model
            _modelProvider.SetupCreateModel(
                model: _modelProvider.CreateModel,
                suburb: _dropdownProcessor.GetSuburbs(),
                plan: _dropdownProcessor.GetMedicalAidPlans(),
                scheme: _dropdownProcessor.GetMedicalAidSchemes(),
                isPatientValid: patientSession,
                isKinValid: kinSession,
                isMedAidValid: aid != null);

            // return model with new data
            return View(_modelProvider.CreateModel);
        }

        [HttpPost]
        public IActionResult MedicalAid(MedicalAidCreate model)
        {
            // browser tab title
            ViewBag.Title = "Create";

            // session variables
            var patientSession = (HttpContext.Session.Get<Patient>(nameof(IPatient)) != null);
            var kinSession = (HttpContext.Session.Get<NextOfKin>(nameof(INextOfKin)) != null);

            // 'Profile/MedicalAid' form created successfully
            if (ModelState.IsValid)
            {
                // create model with only 'IMedicalAid' properties
                IMedicalAid aid = model;
                // store model as session data
                HttpContext.Session.Set<IMedicalAid>(nameof(IMedicalAid), aid);

                if (patientSession && kinSession)
                {
                    // return Implementation of review page required
                    return RedirectToAction(nameof(Confirm));
                }
            }

            // 'Profile/MedicalAid' form invalid
            _modelProvider.CreateModel.MedicalAidCreate = model;

            // create error message
            _alert.Type = AlertModelType.Danger;
            _alert.Header = "Unable to validate.";
            _alert.Content = $"Please review and try again.";
            // add error message
            _modelProvider.CreateModel.Alert = _alert;

            // configure Profile Create Model
            _modelProvider.SetupCreateModel(
                model: _modelProvider.CreateModel,
                suburb: _dropdownProcessor.GetSuburbs(),
                plan: _dropdownProcessor.GetMedicalAidPlans(),
                scheme: _dropdownProcessor.GetMedicalAidSchemes(),
                isPatientValid: patientSession,
                isKinValid: kinSession,
                isMedAidValid: false);

            // return 'Profile/Create' view with model data
            return View(_modelProvider.CreateModel);
        }

        [HttpGet]
        public IActionResult Confirm()
        {
            // browser tab title
            ViewBag.Title = "Create";

            // variables for session data
            IMedicalAid aid = HttpContext.Session.Get<MedicalAid>(nameof(IMedicalAid));
            INextOfKin kin = HttpContext.Session.Get<NextOfKin>(nameof(INextOfKin));
            IPatient patient = HttpContext.Session.Get<Patient>(nameof(IPatient));

            // Profile Create session data incomplete
            if (patient is null || kin is null || aid is null)
            {
                // create error message
                _alert.Type = AlertModelType.Danger;
                _alert.Header = "Profile data incomplete.";
                _alert.Content = $"Not all patient profile details were provided. Please try again.";
                // add session error
                HttpContext.Session.Set<IAlertModel>(nameof(IAlertModel), _alert);

                // return 'Profile/Create' view
                return RedirectToAction(nameof(Create));
            }
            else
            {
                // get session data
                _modelProvider.SetupConfirmCreate(patient, kin, aid, _modelProvider.CreateModel.ConfirmCreate);
            }

            // load error messages
            var error = HttpContext.Session.Get<AlertModel>(nameof(IAlertModel));
            if (error != null)
            {
                _modelProvider.CreateModel.Alert = error;
            }

            // configure Profile Create Model
            _modelProvider.SetupCreateModel(
                model: _modelProvider.CreateModel,
                suburb: _dropdownProcessor.GetSuburbs(),
                plan: _dropdownProcessor.GetMedicalAidPlans(),
                scheme: _dropdownProcessor.GetMedicalAidSchemes(),
                isPatientValid: patient != null,
                isKinValid: kin != null,
                isMedAidValid: aid != null);

            // return model with new data
            return View(_modelProvider.CreateModel);
        }

        [HttpPost]
        public IActionResult Confirm(ConfirmCreate model)
        {
            // browser tab title
            ViewBag.Title = "Create";

            // variables for session data
            IMedicalAid aid = HttpContext.Session.Get<MedicalAid>(nameof(IMedicalAid));
            INextOfKin kin = HttpContext.Session.Get<NextOfKin>(nameof(INextOfKin));
            IPatient patient = HttpContext.Session.Get<Patient>(nameof(IPatient));

            // Session data loaded
            if (patient != null && kin != null && aid != null)
            {
                // create new profile
                var result = _patientProcessor.CreateProfile(patient, kin, aid);

                if (result == ProcessResult.Succeeded)
                {
                    // clear all session data
                    HttpContext.Session.Clear();

                    // create success message
                    _alert.Type = AlertModelType.Success;
                    _alert.Header = "Profile Created.";
                    _alert.Content = $"A new patient profile was created successfully.";
                    // add session message
                    HttpContext.Session.Set<IAlertModel>(nameof(IAlertModel), _alert);

                    // return user to Profile Search
                    return RedirectToAction(nameof(Search));
                }

                switch (result)
                {
                    case ProcessResult.Failed:
                        // create error message
                        _alert.Type = AlertModelType.Danger;
                        _alert.Header = "Unable to Create Profile.";
                        _alert.Content = $"We were unable to create a new patient profile. Please try again.";
                        break;
                    case ProcessResult.PatientFailed:
                        // create error message
                        _alert.Type = AlertModelType.Danger;
                        _alert.Header = "Unable to Create Profile.";
                        _alert.Content = $"We were unable to create a new patient profile." +
                            $" The error was encountered in Patient Information. Please try again.";
                        break;
                    case ProcessResult.NextofKinFailed:
                        // create error message
                        _alert.Type = AlertModelType.Danger;
                        _alert.Header = "Unable to Create Profile.";
                        _alert.Content = $"We were unable to create a new patient profile." +
                            $" The error was encountered in Next of Kin Information. Please try again.";
                        break;
                    case ProcessResult.MedicalAidFailed:
                        // create error message
                        _alert.Type = AlertModelType.Danger;
                        _alert.Header = "Unable to Create Profile.";
                        _alert.Content = $"We were unable to create a new patient profile." +
                            $" The error was encountered in Medical Aid Information. Please try again.";
                        break;
                }
                // add session message
                HttpContext.Session.Set<IAlertModel>(nameof(IAlertModel), _alert);

                // return user to Profile Search
                return RedirectToAction(nameof(Confirm));
            }
            // create error message
            _alert.Type = AlertModelType.Danger;
            _alert.Header = "Unable to Create Profile.";
            _alert.Content = $"We were unable to create a new patient profile. Please try again.";

            // add session message
            HttpContext.Session.Set<IAlertModel>(nameof(IAlertModel), _alert);

            // Reload confirmation view
            return RedirectToAction(nameof(Confirm));
        }

        [HttpGet]
        public IActionResult Diagnosis()
        {
            // browser tab title
            ViewBag.Title = "Diagnosis";

            // variables for session data
            IDiagnosis diagnosis = HttpContext.Session.Get<Diagnosis>(nameof(IDiagnosis));
            var error = HttpContext.Session.Get<AlertModel>(nameof(IAlertModel));

            if (error != null)
            {
                _modelProvider.ReferModel.Alert = error;
            }

            if (diagnosis != null)
            {
                _modelProvider.SetupDiagnosisSession(diagnosis, _modelProvider.ReferModel.PatientDiagnosis);
            }
            else
            {
                // clear all session data
                HttpContext.Session.Clear();
            }

            // load general practitioners
            var selectOptions = new List<ISelectOption>();
            foreach (var doctor in _logic.GetGPDoctors())
            {
                var special = _logic.GetSpecialization((int)doctor.SpecializationID);
                var option = new SelectOption();
                option.Key = doctor.DoctorID.ToString();
                option.Value = doctor.FirstName + " " + doctor.LastName;
                option.Subtext = special.Description;
                selectOptions.Add(option);
            }
            _modelProvider.ReferModel.PatientDiagnosis.DoctorList = selectOptions;

            _modelProvider.SetupReferModel(
                model: _modelProvider.ReferModel,
                condition: _dropdownProcessor.GetMedicalConditionList(),
                patients: _patientProcessor.GetPatients(),
                isDiagnosisValid: diagnosis != null,
                isReferralValid: HttpContext.Session.Get<Referral>(nameof(IReferral)) != null);

            return View(_modelProvider.ReferModel);
        }

        [HttpPost]
        public IActionResult Diagnosis(PatientDiagnosis model)
        {
            // browser tab title
            ViewBag.Title = "Diagnosis";

            // set current date
            model.DiagnosisDate = DateTime.Now;

            // 'Profile/Diagnosis' form create successfully
            if (ModelState.IsValid)
            {
                // create model with only 'IDiagnosis' properties
                IDiagnosis diagnosis = model;
                // store model as session data
                HttpContext.Session.Set<IDiagnosis>(nameof(IDiagnosis), diagnosis);

                // return 'Profile/Referral' view
                return RedirectToAction(nameof(Referral));
            }

            // add error message
            _alert.Type = AlertModelType.Danger;
            _alert.Header = "Submit error";
            _alert.Content = "Unable to save the diagnosis details, please try again.";
            _modelProvider.ReferModel.Alert = _alert;

            // load select options
            var selectOptions = new List<ISelectOption>();
            foreach (var doctor in _logic.GetGPDoctors())
            {
                var special = _logic.GetSpecialization((int)doctor.SpecializationID);
                var option = new SelectOption();
                option.Key = doctor.DoctorID.ToString();
                option.Value = doctor.FirstName + " " + doctor.LastName;
                option.Subtext = special.Description;
                selectOptions.Add(option);
            }
            model.DoctorList = selectOptions;

            _modelProvider.ReferModel.PatientDiagnosis = model;

            _modelProvider.SetupReferModel(
                model: _modelProvider.ReferModel,
                condition: _dropdownProcessor.GetMedicalConditionList(),
                patients: _patientProcessor.GetPatients(),
                isDiagnosisValid: false,
                isReferralValid: HttpContext.Session.Get<Referral>(nameof(IReferral)) != null);

            return View(_modelProvider.ReferModel);
        }

        [HttpGet]
        public IActionResult Referral()
        {
            // browser tab title
            ViewBag.Title = "Referral";

            // variables for session data
            IDiagnosis diagnosis = HttpContext.Session.Get<Diagnosis>(nameof(IDiagnosis));
            IReferral referral = HttpContext.Session.Get<Referral>(nameof(IReferral));

            if (referral != null)
            {
                _modelProvider.SetupReferralSession(referral, _modelProvider.ReferModel.PatientReferral);
            }

            // load select options
            var selectOptions = new List<ISelectOption>();
            foreach (var doctor in _logic.GetGPDoctors())
            {
                var special = _logic.GetSpecialization((int)doctor.SpecializationID);
                var option = new SelectOption();
                option.Key = doctor.DoctorID.ToString();
                option.Value = doctor.FirstName + " " + doctor.LastName;
                option.Subtext = special.Description;
                selectOptions.Add(option);
            }
            _modelProvider.ReferModel.PatientReferral.GPDoctorList = selectOptions;

            selectOptions = new List<ISelectOption>();
            foreach (var doctor in _logic.GetSpecialistDoctors())
            {
                var special = _logic.GetSpecialization((int)doctor.SpecializationID);
                var option = new SelectOption();
                option.Key = doctor.DoctorID.ToString();
                option.Value = doctor.FirstName + " " + doctor.LastName;
                option.Subtext = special.Description;
                selectOptions.Add(option);
            }
            _modelProvider.ReferModel.PatientReferral.SpecialistList = selectOptions;

            _modelProvider.SetupReferModel(
                model: _modelProvider.ReferModel,
                condition: _dropdownProcessor.GetMedicalConditionList(),
                patients: _patientProcessor.GetPatientsNoReferral(),
                isDiagnosisValid: diagnosis != null,
                isReferralValid: referral != null);

            return View(_modelProvider.ReferModel);
        }

        [HttpPost]
        public IActionResult Referral(PatientReferral model)
        {
            // browser tab title
            ViewBag.Title = "Referral";

            // get session data
            IDiagnosis diagnosis = HttpContext.Session.Get<Diagnosis>(nameof(IDiagnosis));

            // 'Profile/Referral' form create successfully
            if (ModelState.IsValid && diagnosis != null)
            {
                // link diagnosis information
                model.DiagnosisID = diagnosis.DiagnosisID;
                // create model with only 'IReferral' properties
                IReferral referral = model;
                // store model as session data
                HttpContext.Session.Set<IReferral>(nameof(IReferral), referral);

                // return 'Profile/Submit' view
                return RedirectToAction(nameof(Submit));
            }

            // add existing data
            _modelProvider.ReferModel.PatientReferral = model;

            if (diagnosis is null)
            {
                // create error message
                _alert.Type = AlertModelType.Warning;
                _alert.Header = "Incomplete Information";
                _alert.Content = "Diagnosis information was not provided. Please review and try again.";
            }
            else
            {
                // create error message
                _alert.Type = AlertModelType.Danger;
                _alert.Header = "Submit Error";
                _alert.Content = "We were unable to submit the information successfully. Please try again.";
            }
            // add error message
            _modelProvider.ReferModel.Alert = _alert;

            // load select options
            var selectOptions = new List<ISelectOption>();
            foreach (var doctor in _logic.GetGPDoctors())
            {
                var special = _logic.GetSpecialization((int)doctor.SpecializationID);
                var option = new SelectOption();
                option.Key = doctor.DoctorID.ToString();
                option.Value = doctor.FirstName + " " + doctor.LastName;
                option.Subtext = special.Description;
                selectOptions.Add(option);
            }
            _modelProvider.ReferModel.PatientReferral.GPDoctorList = selectOptions;

            selectOptions = new List<ISelectOption>();
            foreach (var doctor in _logic.GetSpecialistDoctors())
            {
                var special = _logic.GetSpecialization((int)doctor.SpecializationID);
                var option = new SelectOption();
                option.Key = doctor.DoctorID.ToString();
                option.Value = doctor.FirstName + " " + doctor.LastName;
                option.Subtext = special.Description;
                selectOptions.Add(option);
            }
            _modelProvider.ReferModel.PatientReferral.SpecialistList = selectOptions;

            _modelProvider.SetupReferModel(
                model: _modelProvider.ReferModel,
                condition: _dropdownProcessor.GetMedicalConditionList(),
                patients: _patientProcessor.GetPatients(),
                isDiagnosisValid: diagnosis != null,
                isReferralValid: false);

            return View(_modelProvider.ReferModel);
        }

        [HttpGet]
        public IActionResult Submit()
        {
            // browser tab title
            ViewBag.Title = "Submit";

            // variables for session data
            IDiagnosis diagnosis = HttpContext.Session.Get<Diagnosis>(nameof(IDiagnosis));
            IReferral referral = HttpContext.Session.Get<Referral>(nameof(IReferral));
            // Patient has active referral
            var pending = _patientProcessor.GetPendingReferral().Find(r => r.PatientID == referral.PatientID);

            // Patient Referral session data incomplete
            if (pending != null)
            {
                // create error message
                _alert.Type = AlertModelType.Danger;
                _alert.Header = "Referral exists.";
                _alert.Content = $"The chosen patient has a pending referral.";
                // add session error
                HttpContext.Session.Set<IAlertModel>(nameof(IAlertModel), _alert);
                // return 'Profile/Diagnosis' view
                return RedirectToAction(nameof(IProfileController.Diagnosis));
            }

            // Patient Referral session data incomplete
            if (diagnosis is null || referral is null)
            {
                // create error message
                _alert.Type = AlertModelType.Warning;
                _alert.Header = "Referral data incomplete.";
                _alert.Content = $"Not all referral details were provided. Please try again.";
                // add session error
                HttpContext.Session.Set<IAlertModel>(nameof(IAlertModel), _alert);
                // return 'Profile/Diagnosis' view
                return RedirectToAction(nameof(IProfileController.Diagnosis));
            }

            // load error messages
            var error = HttpContext.Session.Get<AlertModel>(nameof(IAlertModel));
            if (error != null)
            {
                _modelProvider.ReferModel.Alert = error;
            }

            // configure Submit Referral Model
            _modelProvider.SetupSubmitModel(
                model: _modelProvider.ReferModel.SubmitReferral,
                diagnosis: diagnosis,
                referral: referral,
                patient: _patientProcessor.GetPatient(referral.PatientID),
                GPdoctor: _logic.GetGPDoctor(referral.ReferringDoctorID),
                specialist: _logic.GetSpecialistDoctor(referral.SpecialistID));

            _modelProvider.SetupReferModel(
                model: _modelProvider.ReferModel,
                condition: _dropdownProcessor.GetMedicalConditionList(),
                patients: _patientProcessor.GetPatients(),
                isDiagnosisValid: diagnosis != null,
                isReferralValid: referral != null);

            // return model with new data
            return View(_modelProvider.ReferModel);
        }

        [HttpPost]
        public IActionResult Submit(SubmitReferral model)
        {
            // browser tab title
            ViewBag.Title = "Submit";

            // get session data
            var diagnosis = HttpContext.Session.Get<Diagnosis>(nameof(IDiagnosis));
            var referral = HttpContext.Session.Get<Referral>(nameof(IReferral));

            // all data provided
            if (diagnosis != null && referral != null)
            {
                // create new referral
                var result = _patientProcessor.CreateReferral(diagnosis, referral);

                if (result == ProcessResult.Succeeded)
                {
                    // clear all session data
                    HttpContext.Session.Clear();

                    // create success message
                    _alert.Type = AlertModelType.Success;
                    _alert.Header = "Referral Created.";
                    _alert.Content = $"A new referral was created successfully.";
                    // add session message
                    HttpContext.Session.Set<IAlertModel>(nameof(IAlertModel), _alert);

                    // return user to Profile Search
                    return RedirectToAction(nameof(Search));
                }
            }
            // create error message
            _alert.Type = AlertModelType.Danger;
            _alert.Header = "Unable to Create Referral.";
            _alert.Content = $"We were unable to create a new referral. Please try again.";

            // add session message
            HttpContext.Session.Set<IAlertModel>(nameof(IAlertModel), _alert);

            // return to 'Profile/Submit'
            return RedirectToAction(nameof(IProfileController.Submit));
        }
    }
}
