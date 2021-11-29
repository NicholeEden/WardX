using BusinessLogic.Model;
using EFCore.Interface;
using Microsoft.AspNetCore.Mvc;
using WARDx.Data;
using WARDx.DataAcess;
using WARDxAPI.Model.Shared;

namespace WARDxAPI.Controllers
{
    public class PatientTreatmentController : Controller
    {
        private readonly IDataAccess _dataAccess;
        private readonly IDataProcessor _dataProcessor;

        public PatientTreatmentController()
        {
            _dataAccess = DataAccessConfig.ResolveDataAccess();
            _dataProcessor = DataProcessorConfig.ResolveDataProcessor();
        }

        // GET: PatientTreatmentController
        public ActionResult Index(int id)
        {
            var model = new PatientTreatmentModel();

            // SELECT with parameters
            var data = new Patient
            {
                PatientID = id
            };
            // get patient from database
            var patient = _dataAccess.GetData<Patient>(
                storedProcedure: "sp_SelectPatientByID",
                parameterNames: new string[]
                {
                    nameof(IPatient.PatientID)
                },
                value: data);
            // create dictionary
            var patientList = _dataProcessor.GetDictionary<Patient>(
                value: patient,
                keyParameter: nameof(IPatient.PatientID),
                displayParameters: new string[] {
                    nameof(IPatient.FirstName),
                    nameof(IPatient.LastName)
                },
                separator: " ");
            // load dictionary options to model
            model.PatientOptions = patientList;


            // get all nurses from database
            var nurses = _dataAccess.GetData<NurseDetail>(storedProcedure: "sp_SelectAllNurse");
            // convert data to dictionary
            var nurseList = _dataProcessor.GetDictionary<NurseDetail>(
                value: nurses,
                keyParameter: nameof(INurse.NurseID),
                displayParameters: new string[]
                {
                    nameof(IStaffMember.FirstName),
                    nameof(IStaffMember.LastName)
                },
                separator: " ");
            // load nurse options
            model.NurseOptions = nurseList;

            // get all treatment type details from database
            var types = _dataAccess.GetData<TreatmentType>(storedProcedure: "sp_SelectTreatmentType");
            // convert data to dictionary
            var typeList = _dataProcessor.GetDictionary<TreatmentType>(
                value: types,
                keyParameter: nameof(ITreatmentType.TreatmentTypeID),
                displayParameter: nameof(ITreatmentType.Description));
            // load type options\
            model.TreatmentTypeOptions = typeList;

            return View(model);
        }

        // GET: PatientTreatmentController/Upload
        [HttpPost]
        public ActionResult Upload(PatientTreatmentModel model)
        {
            // validate data
            if (ModelState.IsValid)
            {
                
                try
                {
                    _dataAccess.ExecuteData(
                    storedProcedure: "sp_InsertTreatment",
                    parameterNames: new string[] {
                        nameof(ITreatment.NurseID),
                        nameof(ITreatment.PatientID),
                        nameof(ITreatment.TreatmentTypeID),
                        nameof(ITreatment.ObservationNotes)
                    },
                    value: model);
                    // success message
                }
                catch (System.Exception)
                {
                    // error message
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
