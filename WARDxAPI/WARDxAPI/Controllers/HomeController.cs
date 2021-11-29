using BusinessLogic.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WARDxAPI.Interface;
using WARDxAPI.Models;

namespace WARDxAPI.Controllers
{
    [Authorize]
    public class HomeController :
        Controller,
        IHomeController
    {
        private readonly IBusinessLogic _logic;

        public HomeController(IBusinessLogic logic)
        {
            _logic = logic;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Home";

            HttpContext.Session.Clear();

            var model = new HomeModel();

            var movement = _logic.GetPatientMovements();
            model.BloodTest = movement.FindAll(m => m.Reason == EFCore.Interface.Reason.BloodTests).Count;
            model.SmokeBreak = movement.FindAll(m => m.Reason == EFCore.Interface.Reason.SmokeBreak).Count;
            model.Surgery = movement.FindAll(m => m.Reason == EFCore.Interface.Reason.Surgery).Count;
            model.XRay = movement.FindAll(m => m.Reason == EFCore.Interface.Reason.XRays).Count;

            model.PendingReferrals = _logic.GetPendingReferral().Count;
            model.AdmittedPatients = _logic.GetAdmissionFiles().FindAll(a => a.DischargeDate == null).Count;
            model.DischargedPatients = _logic.GetAdmissionFiles().FindAll(a => a.DischargeDate != null).Count;
            model.CheckedIn = movement.FindAll(x => x.isCheckedOut == false).Count;
            model.CheckedOut = movement.FindAll(x => x.isCheckedOut == true).Count;

            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View();
        }
    }
}
