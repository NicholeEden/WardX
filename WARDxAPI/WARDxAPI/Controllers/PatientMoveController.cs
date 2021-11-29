using BusinessLogic.Interface;
using BusinessLogic.Model;
using EFCore.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WARDxAPI.Interface;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.PatientMove;
using WARDxAPI.Model.Shared;

namespace WARDxAPI.Controllers
{

    //comment
    public class PatientMoveController : Controller,
        IPatientMoveController
    {
        private readonly IPatientMoveModelProvider _modelProvider;
        private readonly IPatientProcessor _patientProcessor;
        private readonly IMoveProcessor _moveProcessor;
        private readonly IBusinessLogic _logic;
        private readonly IAlertModel alert;
        private readonly IEmailSender _sender;

        public PatientMoveController(IPatientProcessor patientProcessor, IMoveProcessor moveProcessor, IBusinessLogic logic, IEmailSender sender)
        {
            _modelProvider = APIConfig.ResolvePatientMoveModel();
            alert = APIConfig.ResolveAlertModel();
            this._patientProcessor = patientProcessor;

            this._moveProcessor = moveProcessor;
            this._logic = logic;
            _sender = sender;

        }
        //GET METHODS
        #region CHECKOUT GET AND POST
        [HttpGet]
        public IActionResult CheckOut()
        {
            //browser tab title
            ViewBag.Title = "CheckOut";

            //Get Alert from Post 
            var alertPM = HttpContext.Session.Get<AlertModel>(nameof(IAlertModel));

            if (alertPM != null)
            {
                _modelProvider.checkOutModel.alertModel = alertPM;
                // clear session data
                HttpContext.Session.Clear();
            }

            #region PatientNameList
            //Load list data
            //get a list of patiets from database using business logic method
            var patients = _patientProcessor.GetPatients();

            //create new instance of a list of options
            var patientList = new List<ISelectOption>();
            //add patients to the list
            foreach (var patient in patients)
            {
                // use foreign key to get details from database using business logic method
                //TODO
                //var special = _admissionProcessor.GetAdmissionFile(patient.PatientID);
                //Add a patient to the list of select options
                //create a select option to add to option list
                var option = new SelectOption();
                //use above option to add patients to patient list
                //add patient as an option
                option.Key = patient.PatientID.ToString();
                option.Value = patient.FirstName.ToString() + " " + patient.LastName.ToString();

                patientList.Add(option);
            }
            //add list of options to your model property
            _modelProvider.checkOutModel.moveCheckOut.PatientNamesList = patientList;

            #endregion

            //populate Datatable
            #region CheckedOutPatients Table
            //Get database information using business logic information
            var checkedOutList = _moveProcessor.GetPatientMovements().Where(x => x.isCheckedOut == true);

            var contentList = new List<ICardTableContent>();

            foreach (var patient in checkedOutList)
            {
                //Intantiate a new CardTableContent
                var content = new CardTableContent();


                var ad = _logic.GetAdmissionFileByadmissionID(patient.AdmissionFileID);
                var patientid = _patientProcessor.GetPatient(ad.PatientID);


                //Set the patientMove as the Key
                content.Key = patient.PatientMovementID;
                content.Value1 = patientid.FirstName + " " + patientid.LastName;
                content.Value2 = patient.AdmissionFileID.ToString();
                content.Value3 = patient.CheckOutTime.ToString();
                content.Value4 = patient.Reason.ToString();
                content.Value5 = patient.isCheckedOut.ToString();


                //Adding the CardTableContent Instance to the list
                contentList.Add(content);
            }

            _modelProvider.checkOutModel.moveCheckOut.CheckOuttableContents = contentList;
            #endregion




            return View(_modelProvider.checkOutModel);
        }

        [HttpPost]
        public IActionResult CheckOut(MoveCheckOut model)
        {

            //browser tab title
            ViewBag.Title = "CheckOut";


            //If form is valid. Passed Validation
            if (ModelState.IsValid)
            {
                //Instantiate IPatientmovement object required by BLL
                IPatientMovement movement = model;

                //Provide properties here with values that arent resolved in the form
                //Resolve admission file
                var admissionFile = _logic.GetAdmissionFile(model.PatientID);
                //use above admissionFile to get the admissionFileid

                movement.AdmissionFileID = admissionFile.AdmissionFileID;
                //movement.CheckOutTime = DateTime.Now;
                //movement.MoveDate = DateTime.Now;
                movement.isCheckedOut = true;



                //Declare BLL method
                var result = _logic.AddCheckOut(movement);


                if (result == ProcessResult.Succeeded)
                {
                    alert.Type = AlertModelType.Success;
                    alert.Header = " Success!";
                    alert.Content = "Patient has been checked Out";



                }
                else
                {
                    //If not result is unsuccessful, display an error message
                    alert.Type = AlertModelType.Danger;
                    alert.Header = "CheckOut Unsuccessful! ";
                    alert.Content = "Please try again!";

                }
            }




            //Create Alert and save it into memory
            //Invoke HttpContext and access session and set
            HttpContext.Session.Set<IAlertModel>(nameof(IAlertModel), alert);
            return RedirectToAction(nameof(CheckOut)); ;
        }
        #endregion



        #region CHECKIN GET AND POST
        [HttpGet]
        public IActionResult CheckIn()
        {
            //browser tab title
            ViewBag.Title = "CheckIn";

            // get session data
            var alertPM = HttpContext.Session.Get<AlertModel>(nameof(IAlertModel));
            if (alertPM != null)
            {
                // add alert
                _modelProvider.checkInModel.alertModel = alertPM;
                // clear session data
                HttpContext.Session.Clear();
            }

            // get list of checked in patients
            var checkedInPatients = _moveProcessor.GetPatientMovements();
            // create table content list
            var contentList = new List<ICardTableContent>();
            // iterate through checked in patients
            foreach (var movement in checkedInPatients.Where(x => x.isCheckedOut == false))
            {
                //Instantiate a new CardTableContent
                var content = new CardTableContent();
                // get admission file for patient
                var admission = _logic.GetAdmissionFileByadmissionID(movement.AdmissionFileID);
                // get patient details
                var patient = _patientProcessor.GetPatient(admission.PatientID);

                DateTime checkin = new DateTime();
                // set table content
                if (movement.CheckInTime != null)
                {
                    checkin = (DateTime)movement.CheckInTime;

                }
                content.Value1 = patient.FirstName + " " + patient.LastName;
                content.Value2 = movement.AdmissionFileID.ToString();
                content.Value3 = movement.CheckInTime != null ? checkin.ToShortTimeString() : "Waiting for check in";
                content.Value4 = movement.Reason.ToString();
                content.Value5 = movement.isCheckedOut ? "Checked Out" : "Checked In";
                //Adding the CardTableContent Instance to the list
                contentList.Add(content);


            }





            var patientOptions = new List<ISelectOption>();

            foreach (var movement in checkedInPatients.Where(x => x.isCheckedOut == true))
            {
                //create a select option to add to option list
                var option = new SelectOption();
                // get admission file for patient
                var admission = _logic.GetAdmissionFileByadmissionID(movement.AdmissionFileID);
                // get patient details
                var patient = _patientProcessor.GetPatient(admission.PatientID);

                // set the patient movement id as the key
                option.Key = movement.PatientMovementID.ToString();
                option.Value = patient.FirstName.ToString() + " " + patient.LastName.ToString();
                patientOptions.Add(option);

            }

            //#region PatientNameList
            ////Load list data
            ////get a list of patients from database using business logic method
            //var patients = _patientProcessor.GetPatients();
            //var patientmoves = _logic.GetPatientMovements();
            ////create new instance of a list of options
            //var patientOptions = new List<ISelectOption>();
            ////add patients to the list
            //foreach (var patient in patients)
            //{
            //    // use foreign key to get details from database using business logic method
            //    //TODO
            //    //var special = _admissionProcessor.GetAdmissionFile(patient.PatientID);
            //    //Add a patient to the list of select options
            //    //create a select option to add to option list
            //    var option = new SelectOption();
            //    //use above option to add patients to patient list

            //    // get patient admission file details
            //    var currentFile = _logic.GetAdmissionFile(patient.PatientID);
            //    // patient must have a movement entry
            //    if (currentFile != null)
            //    {
            //        // get patient movement details
            //        var currentPatientMove = checkedInPatients.Find(m => m.AdmissionFileID == currentFile.AdmissionFileID);
            //        // patient must have and admission file
            //        if (currentPatientMove != null&& currentPatientMove.isCheckedOut ==true)
            //        {
            //            // set the patient movement id as the key
            //            option.Key = currentPatientMove.PatientMovementID.ToString();
            //            option.Value = patient.FirstName.ToString() + " " + patient.LastName.ToString();
            //            patientOptions.Add(option);
            //        }
            //    }
            //}
            //add list of options to your model property
            _modelProvider.checkInModel.moveCheckIn.PatientNamesList = patientOptions;

            #endregion

            //populate Datatable
            #region CheckedInPatients Table
            //Get database information using business logic information


            _modelProvider.checkInModel.moveCheckIn.CheckOuttableContents = contentList;
            #endregion


            return View(_modelProvider.checkInModel);
        }
        [HttpPost]
        public IActionResult CheckIn(MoveCheckIn model)
        {
            //browser tab title
            ViewBag.Title = "CheckIn";
            //If form is valid. Passed Validation
            if (ModelState.IsValid)
            {
                //Instantiate IPatientmovement object required by BLL
                IPatientMovement movement = model;
                //Provide properties here with values that arent resolved in the form
                movement.PatientMovementID = model.PatientMovementID;


                //Resolve admission file
                var admissionFile = _logic.GetPatientMovements().Find(x => x.PatientMovementID == model.PatientMovementID);

                movement.AdmissionFileID = admissionFile.AdmissionFileID;
                movement.isCheckedOut = true;

                //Declare BLL method
                _logic.UpdateCheckOut(movement);


                alert.Type = AlertModelType.Success;
                alert.Header = " Success!";
                alert.Content = "Patient has been checked In";


            }

            //Create Alert and save it into memory
            //Invoke HttpContext and access session and set
            HttpContext.Session.Set<IAlertModel>(nameof(IAlertModel), alert);
            return RedirectToAction(nameof(CheckIn)); ;

        }

     


        #region MOVEMENTS [REPORT] GET AND POST
        [HttpGet]
        public IActionResult Movements()
        {
            ViewBag.Title = "Movements";

            // get session data
            var alertPM = HttpContext.Session.Get<AlertModel>(nameof(IAlertModel));
            if (alertPM != null)
            {
                // add alert
                _modelProvider.checkInModel.alertModel = alertPM;
                // clear session data
                HttpContext.Session.Clear();
            }

            #region PatientNameList
            //Load list data
            //get a list of patiets from database using business logic method
            var patients = _patientProcessor.GetPatients();

            //create new instance of a list of options
            var patientLists = new List<ISelectOption>();
            //add patients to the list
            foreach (var patient in patients)
            {

                var option = new SelectOption();

                option.Key = patient.PatientID.ToString();
                option.Value = patient.FirstName.ToString() + " " + patient.LastName.ToString();

                patientLists.Add(option);
            }
            //add list of options to your model property
            _modelProvider.movementsModel.movementReports.PatientNamesList = patientLists;

            #endregion


            return View(_modelProvider.movementsModel);
        }
        [HttpPost]


        public IActionResult Movements(MoveReport model)
        {
            _modelProvider.movementsModel.movementReports = model;
            //Populate PatientNamesList
            #region PatientNameList
            //Load list data
            //get a list of patiets from database using business logic method
            var patients = _patientProcessor.GetPatients();

            //create new instance of a list of options
            var patientLists = new List<ISelectOption>();
            //add patients to the list
            foreach (var patient in patients)
            {

                var option = new SelectOption();

                option.Key = patient.PatientID.ToString();
                option.Value = patient.FirstName.ToString() + " " + patient.LastName.ToString();

                patientLists.Add(option);
            }
            //add list of options to your model property
            _modelProvider.movementsModel.movementReports.PatientNamesList = patientLists;

            #endregion


            if (ModelState.IsValid)
            {

                //Get date range inputs
                var range = model.DateInput.Split('-');
                model.startDate = Convert.ToDateTime(range[0]);
                model.endDate = Convert.ToDateTime(range[1]);

                //Get IPatient object
                var patient = new Patient() { PatientID = model.PatientID };

                //Get database information using business logic information
                //Declare BLL Method
                var resultList = _moveProcessor.GetDateRangeReport(patient, model.startDate, model.endDate);
                var contentList = new List<ICardTableContent>();

                if (resultList.Count > 0)
                {
                    foreach (var pat in resultList)
                    {
                        var content = new CardTableContent();

                        //To retrieve patient name and display it in the datatable
                        var adFileid = _logic.GetAdmissionFileByadmissionID(pat.AdmissionFileID);
                        var patientid = _patientProcessor.GetPatient(adFileid.PatientID);


                        //Set the patientMove as the Key
                        content.Key = pat.PatientMovementID;

                        //Set the values (columns)
                        content.Value1 = patientid.FirstName.ToString() + " " + patientid.LastName.ToString();
                        content.Value2 = pat.AdmissionFileID.ToString();
                        content.Value3 = pat.CheckOutTime.ToString();
                        content.Value4 = pat.CheckOutTime.ToString();
                        content.Value5 = pat.Reason.ToString();


                        //Adding the CardTableContent Instance to the list
                        contentList.Add(content);
                    }

                    _modelProvider.movementsModel.movementReports.CheckOuttableContents = contentList;
                    alert.Type = AlertModelType.Success;
                    alert.Header = "Search Successful! ";
                    _modelProvider.movementsModel.alertModel = alert;

                    return View(_modelProvider.movementsModel);


                }
                //If not result is unsuccessful, display an error message
                alert.Type = AlertModelType.Danger;
                alert.Header = "Search Unsuccessful! ";
                alert.Content = "Please try again!";
                _modelProvider.movementsModel.alertModel = alert;

            }
            else
            {
                //If not result is unsuccessful, display an error message
                alert.Type = AlertModelType.Danger;
                alert.Header = "Search Unsuccessful! ";
                alert.Content = "Please try again!";
                _modelProvider.movementsModel.alertModel = alert;
                return View(_modelProvider.movementsModel);
            }

            return View(_modelProvider.movementsModel);



        }


        #endregion

        #region FOLLOW UP GET AND POST
        [HttpGet]
        public IActionResult FollowUp()
        {
            ViewBag.Title = "FollowUp";

            // get session data
            var alertPM = HttpContext.Session.Get<AlertModel>(nameof(IAlertModel));
            if (alertPM != null)
            {
                // add alert
                _modelProvider.checkInModel.alertModel = alertPM;
                // clear session data
                HttpContext.Session.Clear();
            }
            #region PatientEmailList
            //Load list data
            //get a list of patiets from database using business logic method
            var patients = _patientProcessor.GetPatients();

            //create new instance of a list of options
            var patientLists = new List<ISelectOption>();
            //add patients to the list
            foreach (var patient in patients)
            {
                // use foreign key to get details from database using business logic method
                //TODO
                //var special = _admissionProcessor.GetAdmissionFile(patient.PatientID);
                //Add a patient to the list of select options
                //create a select option to add to option list
                var option = new SelectOption();
                //use above option to add patients to patient list
                //add patient as an option
                option.Key = patient.EmailAddress.ToString();
                option.Value = patient.EmailAddress.ToString();

                option.Subtext = patient.FirstName.ToString() + " " + patient.LastName.ToString();
                patientLists.Add(option);
            }
            //add list of options to your model property
            _modelProvider.followUpModel.moveFollow.PatientEmailList = patientLists;

            #endregion


            return View(_modelProvider.followUpModel);
        }
        [HttpPost]
        public IActionResult FollowUp(moveFollow model)
        {
            ViewBag.Title = "FollowUp";

            #region PatientEmailList
            //Load list data
            //get a list of patients from database using business logic method
            var patients = _patientProcessor.GetPatients();

            //create new instance of a list of options
            var patientLists = new List<ISelectOption>();
            //add patients to the list
            foreach (var patient in patients)
            {

                var option = new SelectOption();
                option.Key = patient.EmailAddress.ToString();
                option.Value = patient.EmailAddress.ToString();

                option.Subtext = patient.FirstName.ToString() + " " + patient.LastName.ToString();
                patientLists.Add(option);
            }
            //add list of options to your model property
            _modelProvider.followUpModel.moveFollow.PatientEmailList = patientLists;

            #endregion
            if (ModelState.IsValid)
            {

               //get credentials
                var credentials = CredentialProvider.GetCredential(true);


                var fromEmail = credentials.UserName;


                //BLL Method
                var result = _sender.SendEmail(ClientType.Microsoft, credentials, fromEmail, model.toEmail, model.Subject, model.Body);


                if (result)
                {

                    alert.Type = AlertModelType.Success;
                    alert.Header = "Email sent! ";
                    alert.Content = $"Successfully sent to {model.toEmail!}";
                 
                 

                }
                else
                {


                    alert.Type = AlertModelType.Danger;
                    alert.Header = "Email not sent! ";
                    alert.Content = "Please try again!";


                }


                //Create Alert and save it into memory
                //Invoke HttpContext and access session and set
                HttpContext.Session.Set<IAlertModel>(nameof(IAlertModel), alert);
            }


            
            return RedirectToAction(nameof(FollowUp));



        }
        #endregion

        [HttpGet]
        public IActionResult Online()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Notifications()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Notifications(MoveNotification model)
        {

            IPatientMovement movement = model;

            if (ModelState.IsValid)
            {
                var late = DateTime.Now.AddMinutes(-5);
                model.latetime = late;

                var latepatients = _logic.GetNotifications(late, true);
                foreach (var latePerson in latepatients)
                {

                }
                _modelProvider.notificationsModel.moveNotification = model;
            }

            return View(_modelProvider.notificationsModel);
        }

    }
}
