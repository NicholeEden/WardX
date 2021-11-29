using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Interface;
using Microsoft.AspNetCore.Mvc;
using WARDxAPI.Model;
using WARDxAPI.Models;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Shared;
using WARDxAPI.Model.Treatment;
using BusinessLogic.Model;
using WARDxAPI.Interface;
using EFCore.Interface;
using WARDxAPI.Model.Interface.Treatment;
using WARDx.DataAcess;
using WARDx.Data;

namespace WARDxAPI.Controllers
{
    public class TreatmentController : Controller
    {
        private readonly ITreatmentModelProvider _modelProvider;
        private readonly IPatientProcessor _patientProcessor;
        private readonly ITreatmentProcessor _treatmentProcessor;
        private readonly IBusinessLogic _logic;
        private readonly IStaffProcessor _staffProcessor;
        private readonly IAdmissionProcessor _admissionProcessor;
        private readonly IAlertModel alert;
        private readonly IDataAccess _dataAccess;
        private readonly IDataProcessor _dataProcessor;
        public TreatmentController(
            IPatientProcessor patientProcessor,
            ITreatmentProcessor treatmentProcessor,
            IBusinessLogic logic,
            IStaffProcessor staffProcessor,
            IAdmissionProcessor admissionProcessor)
        {
            _modelProvider = APIConfig.ResolveTreatmentModel();
            _patientProcessor = patientProcessor;
            _treatmentProcessor = treatmentProcessor ;
            _logic = logic;
            _staffProcessor = staffProcessor ;
            _admissionProcessor = admissionProcessor ;
            alert = APIConfig.ResolveAlertModel();
            _dataAccess = DataAccessConfig.ResolveDataAccess();
            _dataProcessor = DataProcessorConfig.ResolveDataProcessor();
        }
        #region Treatment
        [HttpGet]
        public IActionResult Treatment(int id)
        {

            ViewBag.Title = "Treatment";

            var treatAlert = HttpContext.Session.Get<AlertModel>(nameof(IAlertModel));
            if (treatAlert != null)
            {
                // add alert
                _modelProvider.TreatmentModel.alertModel = treatAlert;
                HttpContext.Session.Clear();
            }


            #region Patient
            // SELECT with parameters
            var model = new Patient
            {
                PatientID = id
            };
            var patient = _dataAccess.GetData<Patient>(
                storedProcedure: "sp_SelectPatientByID",
                parameterNames: new string[]
                {
                    nameof(IPatient.PatientID)
                },
                value: model);

            // no match found
            if (patient is null)
            {
                // create error message
                alert.Type = AlertModelType.Danger;
                alert.Header = "No patient specified.";
                alert.Content = $"Please search for patient name and try again.";
                // add session error
                HttpContext.Session.Set<IAlertModel>(nameof(IAlertModel), alert);

                // return user to search
                return Redirect("~/Profile/" + nameof(IProfileController.Search));
            }

            //load the select option
            var patientName = _dataProcessor.GetDictionary<Patient>(value: patient,
                keyParameter: nameof(IPatient.PatientID),
                displayParameters: new string[]
                {
                nameof(IPatient.FirstName),
                nameof(IPatient.LastName)
                },
                separator: " ");
            _modelProvider.TreatmentModel.RecordTreatment.PatientList = patientName;
            #endregion

            #region Nurse
            var nurses = _dataAccess.GetData<NurseDetail>(storedProcedure: "sp_SelectAllNurse");
            var list = _dataProcessor.GetSelectOption<NurseDetail>(value: nurses,
                keyParameter: nameof(INurse.NurseID),
                displayParameters: new string[]
                {
                nameof(IStaffMember.FirstName),
                nameof(IStaffMember.LastName)
                },
                subtextParameters: new string[]
                {
                    nameof(Specialization.Description)
                },
                separator: " ");
            _modelProvider.TreatmentModel.RecordTreatment.NurseList = list;
            //load select option
            #endregion

            #region TreatmentType
            var treatmentTypes = _dataAccess.GetData<TreatmentType>(storedProcedure: "sp_SelectTreatmentType");
            //load select option
            var typeList = _dataProcessor.GetSelectOption<TreatmentType>(value: treatmentTypes,
                keyParameter: nameof(ITreatmentType.TreatmentTypeID),
                displayParameters: new string[]
                {
                nameof(ITreatmentType.Description)
                },
                subtextParameters: new string[]
                {
                    " "
                },
                separator: " ");
            _modelProvider.TreatmentModel.RecordTreatment.TreatmentTypeList = typeList;
            #endregion


            //Store  object in memory session
            HttpContext.Session.Set<IPatient>(nameof(IPatient), patient.Find(p => p.PatientID == id));

            return View(_modelProvider.TreatmentModel);

        }
        [HttpPost]
        public IActionResult Treatment(RecordTreatment model)
        {

            //browser tab title
            ViewBag.Title = "Treatment";

            if (ModelState.IsValid)
            {
                //Treatment treatment = (Treatment)model.RecordTreatment;

                try
                {
                    _dataAccess.ExecuteData(
                     storedProcedure: "sp_InsertTreatment",
                    parameterNames: new string[]
                    {
                        nameof(ITreatment.NurseID),
                        nameof(ITreatment.ObservationNotes),
                        nameof(ITreatment.PatientID),
                        nameof(ITreatment.TreatmentTypeID)
                    },
                    value: model);
                    alert.Type = AlertModelType.Success;
                    alert.Header = "Success!";
                    alert.Content = "A Treatment entry has been successfully added";
                    // save in session
                    HttpContext.Session.Set<IAlertModel>(nameof(IAlertModel), alert);
                }
                catch
                {
                    alert.Type = AlertModelType.Danger;
                    alert.Header = "Alert!";
                    alert.Content = "A Treatment entry was unsuccesful!";
                    // save in session
                    HttpContext.Session.Set<IAlertModel>(nameof(IAlertModel), alert);
                }

            }
            #region Patient
            // SELECT with parameters
            var patient = new Patient
            {
                PatientID = model.PatientID
            };
            var patientName = _dataAccess.GetData<Patient>(
                storedProcedure: "sp_SelectPatientByID",
                parameterNames: new string[]
                {
                    nameof(IPatient.PatientID)
                },
                value: patient);


            // no match found
            if (patientName is null)
            {
                // create error message
                alert.Type = AlertModelType.Danger;
                alert.Header = "No patient specified.";
                alert.Content = $"Please search for patient name and try again.";
                // add session error
                HttpContext.Session.Set<IAlertModel>(nameof(IAlertModel), alert);

                // return user to search
                return Redirect("~/Profile/" + nameof(IProfileController.Search));
            }

            //load the select option
            var patientNames = _dataProcessor.GetDictionary<Patient>(value: patientName,
                keyParameter: nameof(IPatient.PatientID),
                displayParameters: new string[]
                {
                nameof(IPatient.FirstName),
                nameof(IPatient.LastName)
                },
                separator: " ");
            _modelProvider.TreatmentModel.RecordTreatment.PatientList = patientNames;
           

            #endregion

            #region Nurse
            var nurses = _dataAccess.GetData<NurseDetail>(storedProcedure: "sp_SelectAllNurse");
            var list = _dataProcessor.GetSelectOption<NurseDetail>(value: nurses,
                keyParameter: nameof(INurse.NurseID),
                displayParameters: new string[]
                {
                nameof(IStaffMember.FirstName),
                nameof(IStaffMember.LastName)
                },
                subtextParameters: new string[]
                {
                    nameof(Specialization.Description)
                },
                separator: " ");
            _modelProvider.TreatmentModel.RecordTreatment.NurseList = list;
            //load select option
            #endregion

            #region TreatmentType
            var treatmentTypes = _dataAccess.GetData<TreatmentType>(storedProcedure: "sp_SelectTreatmentType");
            //load select option
            var typeList = _dataProcessor.GetSelectOption<TreatmentType>(value: treatmentTypes,
                keyParameter: nameof(ITreatmentType.TreatmentTypeID),
                displayParameters: new string[]
                {
                nameof(ITreatmentType.Description)
                },
                subtextParameters: new string[]
                {
                    " "
                },
                separator: " ");
            _modelProvider.TreatmentModel.RecordTreatment.TreatmentTypeList = typeList;
            #endregion

            _modelProvider.TreatmentModel.RecordTreatment = model;

            return RedirectToAction(nameof(Treatment));

        }
        [HttpGet]
        //public IActionResult ViewTreatment()
        //{
        //    ViewBag.Title = "Treatment";
        //    // get session data
        //    var treatAlert = HttpContext.Session.Get<AlertModel>(nameof(IAlertModel));
        //    if (treatAlert != null)
        //    {
        //        // add alert
        //        _modelProvider.VitalsModel.alertModel = treatAlert;
        //    }
        //    var treatItem = HttpContext.Session.Get<Patient>(nameof(IPatient));
        //    if (treatItem != null)
        //    {
        //        //Select with parameters
        //        var treatment = new Treatment
        //        {
        //            PatientID = treatItem.PatientID
        //        };
        //        //Get data from table
        //        var treatmentList = _dataAccess.GetData<Treatment>(
        //       storedProcedure: "sp_SelectTreatment",
        //       parameterNames: new string[]
        //       {
        //            nameof(ITreatment.PatientID)
        //       },
        //       value: treatment);

        //        var content = _dataProcessor.GetTableContent<Treatment>(
        //            value: treatment,
        //            keyParameter: nameof(ITreatment.TreatmentID),
        //            value1Parameter: nameof(ITreatment.TreatmentID),
        //            value2Parameter: nameof(ITreatment.PatientID),
        //            value3Parameter: nameof(ITreatment.NurseID),
        //            value4Parameter: nameof(ITreatment.TreatmentTypeID),
        //            value5Parameter: nameof(ITreatment.ObservationNotes)
                    
        //        _modelProvider. = content;
        //    }
        //}


        #endregion

        #region Prescribe
        [HttpGet]
        public IActionResult Prescribe(int id)
        {
            //browser tab title
            ViewBag.Title = "Prescribe";

            var prescAlert = HttpContext.Session.Get<AlertModel>(nameof(IAlertModel));
            if (prescAlert != null)
            {
                // add alert
                _modelProvider.PrescriptionModel.alertModel= prescAlert;
                HttpContext.Session.Clear();
            }

            #region Medication List

            var medication = _dataAccess.GetData<Medication>(
                storedProcedure: "sp_SelectMedication");

            //load the select option
            var medicineList = _dataProcessor.GetSelectOption<Medication>(value: medication,
                keyParameter: nameof(IMedication.MedicationID),
                displayParameters: new string[]
                {
                nameof(IMedication.MedicationName),
                nameof(IMedication.MedicationStrength)
                },
                subtextParameters: new string[]
                {
                    nameof(IMedication.ExpiryDate)
                },
                separator: " ");
            _modelProvider.PrescriptionModel.PrescriptionModel.MedicineNameList = medicineList;

            #endregion

            #region Doctor List

            var doctor = _dataAccess.GetData<DoctorDetail>(
                storedProcedure: "sp_SelectDoctorSpecialist");

            //load the select option
            var doctorList = _dataProcessor.GetSelectOption<DoctorDetail>(value: doctor,
                keyParameter: nameof(IDoctor.DoctorID),
                displayParameters: new string[]
                {
                nameof(IStaffMember.FirstName),
                nameof(IStaffMember.LastName)
                },
                subtextParameters: new string[]
                {
                    nameof(IDoctor.PracticeNumber)
                },
                separator: " ");
            _modelProvider.PrescriptionModel.PrescriptionModel.DoctorList = doctorList;

            #endregion

            // SELECT with parameters
            var model = new AdmissionFile
            {
                PatientID = id
            };
            var admissionFile = _dataAccess.GetDataFilterd<AdmissionFile>(
                     storedProcedure: "sp_SelectAdmissionFileByPatientID",
                     parameterNames: new string[] {
                        nameof(IAdmissionFile.PatientID)
                     },
                     value: model);
            // no match found
            if (admissionFile is null)
            {
                // create error message
                alert.Type = AlertModelType.Danger;
                alert.Header = "No admission file was found.";
                alert.Content = $"Please search for patient name and try again.";
                // add session error
                HttpContext.Session.Set<IAlertModel>(nameof(IAlertModel), alert);

                // return user to search
                return Redirect("~/Profile/" + nameof(IProfileController.Search));
            }
            HttpContext.Session.Set<IAdmissionFile>(nameof(IAdmissionFile), admissionFile);

            return View(_modelProvider.PrescriptionModel);
        }
        [HttpPost]
        public IActionResult Prescribe(RecordPrescription model)
        {
            ViewBag.Title = "Prescribe";
            //Get session data
            var admissionFile = HttpContext.Session.Get<AdmissionFile>(nameof(IAdmissionFile));
            model.AdmissionFileID = admissionFile.AdmissionFileID;
            if (ModelState.IsValid)
            {
               _dataAccess.ExecuteData(
                 storedProcedure: "sp_InsertPrescription",
                parameterNames: new string[]
                {
                    nameof(IPrescription.MedicationID),
                    nameof(IPrescription.Dosage),
                    nameof(IPrescription.DoctorID),
                    nameof(IPrescription.Instruction),
                    nameof(IPrescription.DateIssued),
                    nameof(IAdmissionFile.AdmissionFileID)
                },
                value: model); ;

                try
                {
                    alert.Type = AlertModelType.Success;
                    alert.Header = "Success!";
                    alert.Content = "A Prescription entry has been successfully added";
                    // save in session
                    HttpContext.Session.Set<IAlertModel>(nameof(IAlertModel), alert);
                }
                catch(Exception ex)
                {
                    alert.Type = AlertModelType.Danger;
                    alert.Header = "Alert!";
                    alert.Content = "A Prescription entry was unsuccesful!";
                    // save in session
                    HttpContext.Session.Set<IAlertModel>(nameof(IAlertModel), alert);
                }
            }

            
            return RedirectToAction(nameof(Prescribe));
        }
        #endregion

        #region Dispense
        [HttpGet]
        public IActionResult Dispense(int id)
        {
           
            // browser tab title
            ViewBag.Title = "Dispense";
            #region Patient
            //// SELECT with parameters
            //var model = new Patient
            //{
            //    PatientID = id
            //};
            //var patient = _dataAccess.GetData<Patient>(
            //    storedProcedure: "sp_SelectPatientByID",
            //    parameterNames: new string[]
            //    {
            //        nameof(IPatient.PatientID)
            //    },
            //    value: model);
            //List<Patient> patientlist = new List<Patient>() { patient };
            //var content = _dataProcessor.GetTableContent<Patient>(
            //        value: patientlist,
            //        keyParameter: nameof(IPatient.PatientID),
            //        value1Parameter: nameof(IPatient.VitalSignID),
            //        value2Parameter: nameof(IVitalSign.Hypoglycemia),
            //        value3Parameter: nameof(IVitalSign.BodyTemperature),
            //        value4Parameter: nameof(IVitalSign.PulseRate),
            //        value5Parameter: nameof(IVitalSign.BloodPressure),
            //        value6Parameter: nameof(IVitalSign.Weight),
            //        value7Parameter: nameof(IVitalSign.BMI));
            //_modelProvider.VitalsModel.ViewVitals.VitalsTableContents = content;

            #endregion

            #region Prescription
            var model = new AdmissionFile
            {
                PatientID = id
            };
            var admissionFile = _dataAccess.GetDataFilterd<AdmissionFile>(
                     storedProcedure: "sp_SelectAdmissionFileByPatientID",
                     parameterNames: new string[] {
                        nameof(IAdmissionFile.PatientID)
                     },
                     value: model);

            var admit = new AdmissionFile
            {
                AdmissionFileID = admissionFile.AdmissionFileID
            };
            var prescription = _dataAccess.GetDataFilterd(
                     storedProcedure: "sp_SelectPrescriptionByAdmissionFileID",
                     parameterNames: new string[] {
                        nameof(IAdmissionFile.AdmissionFileID)
                     },
                     value: admit);
            if (prescription != null)
            {
                //var content = _dataProcessor.GetTableContent<PrescriptionDetail>(
                //    value: prescription,
                //    keyParameter: nameof(IPrescription.PrescriptionID),
                //    value1Parameter: nameof(IPrescription.PrescriptionID),
                //    value2Parameter: nameof(IMedication.MedicationName),
                //    value3Parameter: nameof(IPrescription.Dosage),
                //    value4Parameter: nameof(IDoctor.PracticeNumber),
                //    value5Parameter: nameof(IPrescription.Instruction),
                //    value6Parameter: nameof(IPrescription.DateIssued));
            }
            else
            {
                // redirect to 'Treatment/RecordVitals'
                return Redirect(nameof(ITreatmentController.RecordVitals));
            }



            #endregion


            return View(_modelProvider.DispenseModel);
        }
        #endregion

        #region Vitals

        [HttpGet]
        public IActionResult RecordVitals()
        {
            //browser tab title
            ViewBag.Title = "Record";

            var bloodG = _dataAccess.GetData<BloodGroup>(storedProcedure: "sp_SelectBloodGroup");
            // load blood group options
            var list = _dataProcessor.GetSelectOption<BloodGroup>(
                value: bloodG,
                keyParameter: nameof(IBloodGroup.BloodGroupID),
                displayParameters: new string[] { 
                    nameof(IBloodGroup.BloodGroupName)
                },
                subtextParameters: new string[] {
                    " "
                },
                separator: " ");

            _modelProvider.VitalsModel.RecordVitals.BloodGroupList = list;
            
            return View(_modelProvider.VitalsModel);
        }

        [HttpPost]
        public IActionResult RecordVitals(RecordVitals model)
        {
            // browser tab title
            ViewBag.Title = "Vitals";

            // get vital sign information from model
            var primaryKey = _dataAccess.ExecuteData<RecordVitals>(
                storedProcedure: "sp_InsertVitalSign",
                parameterNames: new string[] { 
                    nameof(IVitalSign.BloodGroupID),
                    nameof(IVitalSign.BloodPressure),
                    nameof(IVitalSign.BMI),
                    nameof(IVitalSign.BodyTemperature),
                    nameof(IVitalSign.Hypoglycemia),
                    nameof(IVitalSign.PulseRate),
                    nameof(IVitalSign.Weight),
                    nameof(IVitalSign.VitalSignID)
                },
                value: model,
                returnParameter: nameof(IVitalSign.VitalSignID));

            // valid primary key
            if (primaryKey >= 1)
            {
                // set alert message
                alert.Type = AlertModelType.Success;
                alert.Header = "Success!";
                alert.Content = "A Vital Sign entry has been successfully added";
                // save in session
                HttpContext.Session.Set<IAlertModel>(nameof(IAlertModel), alert);

                // get database information
                var signID = new VitalSign { VitalSignID = primaryKey };
                var vital = _dataAccess.GetDataFilterd<VitalSign>(
                    storedProcedure: "sp_SelectVitalSignByID",
                    parameterNames: new string[] {
                        nameof(IVitalSign.VitalSignID)
                    },
                    value: signID);
                // save in session
                HttpContext.Session.Set<IVitalSign>(nameof(IVitalSign), vital);

                // redirect to 'Treatment/ViewVitals'
                return RedirectToAction(nameof(ITreatmentController.ViewVitals));

            }
            else
            {
                // create error message
                alert.Type = AlertModelType.Danger;
                alert.Header = "Alert!";
                alert.Content = "A Vital Sign entry has been successfully added";
            }

            // add current form information to mode
            _modelProvider.VitalsModel.RecordVitals = model;

            var bloodG = _dataAccess.GetData<BloodGroup>(storedProcedure: "sp_SelectBloodGroup");
            // load blood group options
            var list = _dataProcessor.GetSelectOption<BloodGroup>(
                value: bloodG,
                keyParameter: nameof(IBloodGroup.BloodGroupID),
                displayParameters: new string[] {
                    nameof(IBloodGroup.BloodGroupName)
                },
                subtextParameters: new string[] {
                    " "
                },
                separator: " ");

            _modelProvider.VitalsModel.RecordVitals.BloodGroupList = list;

            _modelProvider.VitalsModel.alertModel = alert;

            return View(_modelProvider.VitalsModel);

        }

        [HttpGet]
        public IActionResult ViewVitals()
        {
            //browser tab title
            ViewBag.Title = "ViewVitals";

            // get session data
            var vitalAlert = HttpContext.Session.Get<AlertModel>(nameof(IAlertModel));
            if (vitalAlert != null)
            {
                // add alert
                _modelProvider.VitalsModel.alertModel = vitalAlert;
            }

            // get vital sign information
            var item = HttpContext.Session.Get<VitalSign>(nameof(IVitalSign));
            if (item != null)
            {
                List<VitalSign> list = new List<VitalSign>() { item };

                var content = _dataProcessor.GetTableContent<VitalSign>(
                    value: list,
                    keyParameter: nameof(IVitalSign.VitalSignID),
                    value1Parameter: nameof(IVitalSign.VitalSignID),
                    value2Parameter: nameof(IVitalSign.Hypoglycemia),
                    value3Parameter: nameof(IVitalSign.BodyTemperature),
                    value4Parameter: nameof(IVitalSign.PulseRate),
                    value5Parameter: nameof(IVitalSign.BloodPressure),
                    value6Parameter: nameof(IVitalSign.Weight),
                    value7Parameter: nameof(IVitalSign.BMI));
                _modelProvider.VitalsModel.ViewVitals.VitalsTableContents = content;
            }
            else
            {
                // redirect to 'Treatment/RecordVitals'
                return Redirect(nameof(ITreatmentController.RecordVitals));
            }

            // clear session data
            HttpContext.Session.Clear();
            return View(_modelProvider.VitalsModel);
        }
        #endregion

        #region Request Doctor
        [HttpGet]
        public IActionResult RequestDoctor()
        {
            ViewBag.Title = "Request";

            // get doctors for database
            var doctors = _dataAccess.GetData<Doctor>(storedProcedure: "sp_SelectDoctorSpecialist");
            // load the 'DoctorEmailList' with doctors
            var list = _dataProcessor.GetSelectOption<Doctor>(
                value: doctors,
                keyParameter: nameof(IStaffMember.EmailAddress),
                displayParameters: new string[] {
                    nameof(IStaffMember.FirstName),
                    nameof(IStaffMember.LastName)
                },
                subtextParameters: new string[] {
                    nameof(IStaffMember.EmailAddress)
                },
                separator: " ");

            _modelProvider.RequestModel.SendRequest.DoctorEmailList = list;
            return View(_modelProvider.RequestModel);
        }

        [HttpPost]
        public IActionResult RequestDoctor(SendRequest model)
        {
            ViewBag.Title = "Request";



            if (ModelState.IsValid)
            {

                var credentials = CredentialProvider.GetCredential(true);

                var fromEmail = credentials.UserName;


                //BLL Method
                var result = _logic.SendEmail(
                    ClientType.Microsoft,
                    credentials,
                    credentials.UserName,
                    model.ToEmail,
                    model.Subject,
                    model.Body);


                if (result)
                {

                    alert.Type = AlertModelType.Success;
                    alert.Header = "Email sent! ";
                    alert.Content = $"Successfully sent to ";


                    return RedirectToAction(nameof(RequestDoctor));
                }
                else
                {


                    alert.Type = AlertModelType.Danger;
                    alert.Header = "Email not sent! ";
                    alert.Content = "Please try again!";


                }
            }
            //Load list data
            //get a list of admission files from database using business logic method
            var AdmissionFileList = _admissionProcessor.GetAdmissionFiles();

            // get doctors for database
            var doctors = _dataAccess.GetData<Doctor>(storedProcedure: "sp_SelectDoctorSpecialist");
            // load the 'DoctorEmailList' with doctors
            var list = _dataProcessor.GetSelectOption<Doctor>(
                value: doctors,
                keyParameter: nameof(IStaffMember.EmailAddress),
                displayParameters: new string[] {
                    nameof(IStaffMember.EmailAddress)
                },
                subtextParameters: new string[] {
                    nameof(IStaffMember.FirstName),
                    nameof(IStaffMember.LastName)
                },
                separator: " ");
            //add list of options to your model property
            _modelProvider.RequestModel.SendRequest.DoctorEmailList = list;

            return RedirectToAction(nameof(RequestDoctor));
        }

        #endregion



        #region Not Used
        public IActionResult Information()
        {
            return View("Information");
        }
        public IActionResult SearchPrescription()
        {
            return View("SearchPrescription");
        }
        #endregion
    }
}
