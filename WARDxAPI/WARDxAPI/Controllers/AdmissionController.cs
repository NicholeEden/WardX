using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Interface;
using BusinessLogic.Model;
using EFCore.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WARDxAPI.Interface;
using WARDxAPI.Model;
using WARDxAPI.Model.Admission;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Shared;

namespace WARDxAPI.Controllers
{
    [Authorize]
    public class AdmissionController : Controller , IAdmissionController
    {
        private readonly IAdmissionModelProvider _modelProvider;
        private  IAdmissionProcessor _admissionProcessor;
        private readonly IPatientProcessor _patientProcessor;
        private readonly IStaffProcessor _staffProcessor;
        private readonly IBusinessLogic _logic;
        private IAlertModel _alert;

        public AdmissionController(IAdmissionProcessor admissionProcessor, IPatientProcessor patientProcessor,IStaffProcessor staffProcessor ,IBusinessLogic logic)
        {
            _modelProvider = APIConfig.ResolveAdmissionModel();
            _alert = APIConfig.ResolveAlertModel();
            _admissionProcessor = admissionProcessor;
            _patientProcessor = patientProcessor;
            _staffProcessor = staffProcessor;
            _logic = logic;
        }

        [HttpGet]

        public IActionResult AdmissionFile()
        {
            //browser tab title
            ViewBag.Title = "AdmissionFile";

            var AdmissionFileList = _admissionProcessor.GetAdmissionFiles();

            var contentList = new List<ICardTableContent>();

            foreach (var admissionFile in AdmissionFileList)
            {
                //Intantiate a new CardTableContent
                var content = new CardTableContent();


                var patient = _patientProcessor.GetPatient(admissionFile.PatientID);

                var specialists = _staffProcessor.GetSpecialistDoctors();

                //TODO: There is no business logic implementation
                var specialistDoc = specialists.Find(speciaDoc => speciaDoc.DoctorID == admissionFile.AssignedSpecialistID);

                var admissionFileBed = _admissionProcessor.GetAllBeds();

                var bed = admissionFileBed.Find(bedName => bedName.BedID == admissionFile.BedID);

                var prescription = _admissionProcessor.GetPrescriptions();

                var prescDetail = prescription.Find(presc => presc.PrescriptionID == admissionFile.PrescriptionID);


                //Set the AdmissionFile as the Key
                content.Key = admissionFile.AdmissionFileID;
                content.Value1 = admissionFile.AdmissionFileID.ToString();
                content.Value2 = patient.FirstName + " " + patient.LastName;
                content.Value3 = admissionFile.AdmissionDate.ToString();
                content.Value4 = specialistDoc.FirstName + " " + specialistDoc.LastName;
                content.Value5 = bed.Description;
                content.Value6 = admissionFile.DischargeDate.ToString();
                if(prescDetail == null)
                {
                    content.Value7 = admissionFile.PrescriptionID.ToString();
                }
                else
                {
                    content.Value7 = prescDetail.MedicationName;
                }
                content.Value8 = admissionFile.Notes;


                //Adding the CardTableContent Instance to the list
                contentList.Add(content);
            }

            _modelProvider.AdmissionFileModel.ViewAdmissionFileModel.CardTableContents = contentList;
  

            return View(_modelProvider.AdmissionFileModel);

        }

        [HttpPost]
        public IActionResult EditAdmissionFile(PatientAdmissionFileUpdate model)
        {
            ViewBag.Title = "EditAdmissionFile";

            var admission = HttpContext.Session.Get<AdmissionFile>(nameof(IAdmissionFile));

            if (admission.DischargeDate != null && admission.PrescriptionID != null)
            {
                _alert.Type = AlertModelType.Warning;
                _alert.Header = "AdmissionFile Infringement";
                _alert.Content = "Cannot modify a closed File";
                _modelProvider.AdmissionFileModel.AlertModel = _alert;

                var _selectOptions = new List<ISelectOption>();

                foreach (var bed in _logic.GetAllAvailableBeds(true))
                {
                    var option = new SelectOption();
                    option.Key = bed.BedID.ToString(); ;
                    option.Value = bed.Description;
                    _selectOptions.Add(option);
                }

                _modelProvider.AdmissionFileModel.PatientAdmissionFileUpdate.BedList = _selectOptions;

                return View(_modelProvider.AdmissionFileModel);
            }

            if (ModelState.IsValid)
            {
                IAdmissionFile admissionFile = model;

                admissionFile.AdmissionFileID = admission.AdmissionFileID;

                var result = _logic.UpdateAdmission(admissionFile, admissionFile.BedID, false);

                if (result == ProcessResult.Succeeded)
                {
                    _alert.Type = AlertModelType.Success;
                    _alert.Header = "Admission File has been updated";
                    _alert.Content = "An Admission File entry has been created";
                    _modelProvider.CreateAdmitModel.AlertModel = _alert;

                    return RedirectToAction(nameof(AdmissionFile));
                }

            }

            _modelProvider.AdmissionFileModel.PatientAdmissionFileUpdate.PatientName = model.PatientName;

            _modelProvider.AdmissionFileModel.PatientAdmissionFileUpdate.SpecialistName = model.SpecialistName;


            var selectOptions = new List<ISelectOption>();

            foreach (var bed in _logic.GetAllAvailableBeds(true))
            {
                var option = new SelectOption();
                option.Key = bed.BedID.ToString(); ;
                option.Value = bed.Description;
                selectOptions.Add(option);
            }

            _modelProvider.AdmissionFileModel.PatientAdmissionFileUpdate.BedList = selectOptions;

            _alert.Type = AlertModelType.Danger;
            _alert.Header = "AdmissionFile was not Updated";
            _alert.Content = "The updating of the Admission File was unsuccessful";
            _modelProvider.CreateAdmitModel.AlertModel = _alert;


            return View(_modelProvider.AdmissionFileModel);


        }

        [HttpGet]
        public IActionResult EditAdmissionFile(int id)
        {
            ViewBag.Title = "EditAdmissionFile";

            //Use id to get referral
            IAdmissionFile admissionFile = _admissionProcessor.GetAdmissionFile(id);

            //Store referral object in memory session
            HttpContext.Session.Set<IAdmissionFile>(nameof(IAdmissionFile), admissionFile);

            if (admissionFile.DischargeDate != null && admissionFile.PrescriptionID != null)
            {
                _alert.Type = AlertModelType.Warning;
                _alert.Header = "AdmissionFile Infringement";
                _alert.Content = "Cannot modify a closed File";
                _modelProvider.AdmissionFileModel.AlertModel = _alert;

                var _selectOptions = new List<ISelectOption>();

                foreach (var bed in _logic.GetAllAvailableBeds(true))
                {
                    var option = new SelectOption();
                    option.Key = bed.BedID.ToString(); ;
                    option.Value = bed.Description;
                    _selectOptions.Add(option);
                }

                _modelProvider.AdmissionFileModel.PatientAdmissionFileUpdate.BedList = _selectOptions;

                return View(_modelProvider.AdmissionFileModel);


            }
            //Use Referral.PatientID to get the Patient
            IPatient patient = _logic.GetPatient(admissionFile.PatientID);
            //Set patientName using patient details
            _modelProvider.AdmissionFileModel.PatientAdmissionFileUpdate.PatientName = patient.FirstName + " " + patient.LastName;
            //Use Referral.SpecialistID to get the doctor
            var doctor = _logic.GetSpecialistDoctor(admissionFile.AssignedSpecialistID);
            //Set doctor name using doctor details

            _modelProvider.AdmissionFileModel.PatientAdmissionFileUpdate.SpecialistName = doctor.FirstName + " " + doctor.LastName;

            var selectOptions = new List<ISelectOption>();

            foreach (var bed in _logic.GetAllAvailableBeds(true))
            {
                var option = new SelectOption();
                option.Key = bed.BedID.ToString(); ;
                option.Value = bed.Description;
                selectOptions.Add(option);
            }

            _modelProvider.AdmissionFileModel.PatientAdmissionFileUpdate.BedList = selectOptions;


            

            return View(_modelProvider.AdmissionFileModel);
        }

        [HttpPost]
        public IActionResult Admit(PatientAdmit model)
        {
            //browser tab title
            ViewBag.Title = "Admit";

            //Use id to get referral
            //Use Referral.PatientID to get the Patient
            //Set patientName using patient details
            //Retrieve Referral in memory
            var referral = HttpContext.Session.Get<Referral>(nameof(IReferral));

            if (ModelState.IsValid)
            {
                IAdmissionFile admissionFile = model;
                
                

                admissionFile.PatientID = referral.PatientID;
                admissionFile.AssignedSpecialistID = referral.SpecialistID;
                admissionFile.AdmissionDate = DateTime.Now;

                var result = _logic.CreateAdmission(admissionFile, admissionFile.BedID, false, referral.ReferralID, true);

                if (result == ProcessResult.Succeeded)
                {
                    _alert.Type = AlertModelType.Success;
                    _alert.Header = "Patient has been admitted";
                    _alert.Content = "A new patient Admission File has been created";
                    _modelProvider.CreateAdmitModel.AlertModel = _alert;

                    return RedirectToAction(nameof(AdmissionFile));
                }
                
            }

            _modelProvider.CreateAdmitModel.PatientAdmit.PatientName = model.PatientName;

            _modelProvider.CreateAdmitModel.PatientAdmit.SpecialistName = model.SpecialistName;


            var selectOptions = new List<ISelectOption>();


            foreach (var bed in _logic.GetAllAvailableBeds(true))
            {
                var option = new SelectOption();
                option.Key = bed.BedID.ToString(); ;
                option.Value = bed.Description;
                selectOptions.Add(option);
            }

            _modelProvider.CreateAdmitModel.PatientAdmit.BedList = selectOptions;

            int availableBeds = _logic.GetAllAvailableBeds(true).Count();

            //assigning the value of the [availableBeds] to the model containing the BedCount
            _modelProvider.CreateAdmitModel.PatientAdmit.BedCount = availableBeds;


            _alert.Type = AlertModelType.Danger;
            _alert.Header = "Patient was not admitted";
            _alert.Content = "A new patient entry in Admission File was unsuccessful";
            _modelProvider.CreateAdmitModel.AlertModel = _alert;

            return View(_modelProvider.CreateAdmitModel);
        }

        [HttpGet]
        public IActionResult Admit(int id)
        {
            //browser tab title
            ViewBag.Title = "Admit";

            //Use id to get referral
            IReferral referral = _patientProcessor.GetReferral(id);

            //Store referral object in memory session
            HttpContext.Session.Set<IReferral>(nameof(IReferral), referral);
            //Use Referral.PatientID to get the Patient
            IPatient patient = _logic.GetPatient(referral.PatientID);
            //Set patientName using patient details
            _modelProvider.CreateAdmitModel.PatientAdmit.PatientName = patient.FirstName + " " + patient.LastName;
            //Use Referral.SpecialistID to get the doctor
            var doctor = _logic.GetSpecialistDoctor(referral.SpecialistID);
            //Set doctor name using doctor details

            _modelProvider.CreateAdmitModel.PatientAdmit.SpecialistName = doctor.FirstName + " " + doctor.LastName;


            var selectOptions = new List<ISelectOption>();

            foreach (var bed in _logic.GetAllAvailableBeds(true))
            {
                var option = new SelectOption();
                option.Key = bed.BedID.ToString(); ;
                option.Value = bed.Description;
                selectOptions.Add(option);
            }

            _modelProvider.CreateAdmitModel.PatientAdmit.BedList = selectOptions;

            //TO DO: create a stored procedure that allows isAvaliable parameter to get available beds

            //creating a variable to store number of beds in database
            int availableBeds = _logic.GetAllAvailableBeds(true).Count();

            //assigning the value of the [availableBeds] to the model containing the BedCount
            _modelProvider.CreateAdmitModel.PatientAdmit.BedCount = availableBeds;

            

            return View(_modelProvider.CreateAdmitModel);
        }

        [HttpPost]
        public IActionResult Discharge(PatientDischarge model)
        {
            //browser tab title
            ViewBag.Title = "Discharge";

            var _admissionFile = HttpContext.Session.Get<AdmissionFile>(nameof(IAdmissionFile));

            if (_admissionFile.DischargeDate != null && _admissionFile.PrescriptionID != null)
            {
                _alert.Type = AlertModelType.Warning;
                _alert.Header = "AdmissionFile Infringement";
                _alert.Content = "Cannot modify a closed File";
                _modelProvider.CreateAdmitModel.AlertModel = _alert;
                return View(_modelProvider.CreateAdmitModel);
            }


            if (ModelState.IsValid)
            {
                IAdmissionFile admissionFile = model;

                admissionFile.AdmissionFileID = _admissionFile.AdmissionFileID;
                admissionFile.DischargeDate = DateTime.Now;
                if(_admissionFile.PrescriptionID == null)
                {
                    _alert.Type = AlertModelType.Warning;
                    _alert.Header = "Discharge requirement";
                    _alert.Content = "Cannot discharge patient without a prescription";
                    _modelProvider.CreateAdmitModel.AlertModel = _alert;
                    return View(_modelProvider.CreateAdmitModel);
                }


                var result = _logic.UpdateAdmissionWithDischarge(admissionFile, admissionFile.BedID, true);

                if(result == ProcessResult.Succeeded)
                {
                    _alert.Type = AlertModelType.Success;
                    _alert.Header = "Patient has been Discharged";
                    _alert.Content = "Patient discharge details uploaded on the AdmissionFile";
                    _modelProvider.CreateAdmitModel.AlertModel = _alert;
                    return RedirectToAction(nameof(AdmissionFile));
                }
            }

            _modelProvider.CreateAdmitModel.PatientDischarge.PatientName = model.PatientName;
            



            _alert.Type = AlertModelType.Danger;
            _alert.Header = "Patient was not Discharged";
            _alert.Content = "A new patient discharge entry in Admission File was unsuccessful";
            _modelProvider.CreateAdmitModel.AlertModel = _alert;

            return View(_modelProvider.CreateAdmitModel);
        }

        [HttpGet]
        public IActionResult Discharge(int id)
        {
            //browser tab title
            ViewBag.Title = "Discharge";

            IAdmissionFile admissionFile = _logic.GetAdmissionFile(id);

            HttpContext.Session.Set<IAdmissionFile>(nameof(IAdmissionFile), admissionFile);

            if (admissionFile.DischargeDate != null && admissionFile.PrescriptionID != null)
            {
                _alert.Type = AlertModelType.Warning;
                _alert.Header = "AdmissionFile Infringement";
                _alert.Content = "Cannot modify a closed File";
                _modelProvider.CreateAdmitModel.AlertModel = _alert;
                return View(_modelProvider.CreateAdmitModel);
            }

            IPatient patient = _logic.GetPatient(admissionFile.PatientID);

            _modelProvider.CreateAdmitModel.PatientDischarge.PatientName = patient.FirstName + " " + patient.LastName;



            return View(_modelProvider.CreateAdmitModel);
        }



        [HttpGet]
        public IActionResult Referral()
        {
            //browser tab title
            ViewBag.Title = "Referral";

            //Get database information using business logic information
            var referralList = _admissionProcessor.GetReferrals(false);

            var contentList = new List<ICardTableContent>();

            foreach (var referral in referralList)
            {
                //Intantiate a new CardTableContent
                var content = new CardTableContent();


                var patient = _patientProcessor.GetPatient(referral.PatientID);

                var doctors = _staffProcessor.GetGPDoctors();

                //TODO: There is no business logic implementation
                var doctorSpecific = doctors.Find(docSpeci => docSpeci.DoctorID == referral.ReferringDoctorID);

                var specialists = _staffProcessor.GetSpecialistDoctors();

                var specialistDoc = specialists.Find(speciaDoc => speciaDoc.DoctorID == referral.SpecialistID);

                //Set the ReferralID as the Key
                content.Key = referral.ReferralID;

                content.Value1 = patient.FirstName + " " + patient.LastName;

                content.Value2 = doctorSpecific.FirstName + " " + doctorSpecific.LastName;

                content.Value3 = specialistDoc.FirstName + " " + specialistDoc.LastName;

                //Adding the CardTableContent Instance to the list
                contentList.Add(content);
            }

            _modelProvider.CreateAdmitModel.ViewReferralModel.CardTableContents = contentList;

            return View(_modelProvider.CreateAdmitModel);
        }


    }
}
