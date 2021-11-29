using BusinessLogic.Security;
using EFCore.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WARDx.Data;
using WARDx.DataAcess;
using WARDxAPI.Interface;
using WARDxAPI.Model.Shared;

namespace WARDxAPI.Controllers
{
    public class AccountController :
        Controller,
        IAccountController
        
    {
        private readonly IDataAccess _dataAccess;
        private readonly IDataProcessor _dataProcessor;
        private readonly SignInManager<WARDxUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<WARDxUser> _userManager;

        public AccountController(
            SignInManager<WARDxUser> signInManager,
            ILogger<AccountController> logger,
            UserManager<WARDxUser> userManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
            _dataAccess = DataAccessConfig.ResolveDataAccess();
            _dataProcessor = DataProcessorConfig.ResolveDataProcessor();
        }

        public void ClockIn(int StaffID)
        {
            // create data model
            var data = new NurseDetail { NurseID = StaffID };
            // add database entry for clock in
            _dataAccess.ExecuteData<NurseDetail>(
                storedProcedure: "sp_ClockIn",
                parameterNames: new string[] {
                    nameof(INurse.NurseID)
                },
                value: data);
        }

        public void ClockOut(int StaffID)
        {
            // create data model
            var data = new NurseDetail { NurseID = StaffID };
            // update database clocking entry
            _dataAccess.ExecuteData<NurseDetail>(
                storedProcedure: "sp_ClockOut",
                parameterNames: new string[] {
                    nameof(INurse.NurseID)
                },
                value: data);
        }

        [HttpGet]
        public IActionResult Login()
        {
            // browser tab title
            ViewBag.Title = "Login";

            return View();
        }
        

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl)
        {
            // all validation conditions were met
            if (ModelState.IsValid)
            {
                // sign in user based on the credentials supplied
                var result = await _signInManager.PasswordSignInAsync(model.EmployeeID,
                    model.Password,
                    model.RememberMe,
                    lockoutOnFailure: false);
                // user credentials were found on database
                if (result.Succeeded)
                {
                    // call the clock in method
                    var user = await _userManager.FindByNameAsync(model.EmployeeID);
                    if (user.StaffType == StaffType.Nurse)
                    {
                        ClockIn(user.StaffID);
                    }

                    // return URL was provided and is a supported path
                    if (string.IsNullOrEmpty(returnUrl) == false && Url.IsLocalUrl(returnUrl))
                    {
                        // send user to previous page
                        return Redirect(returnUrl);
                    }
                    // return user to default home page
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                // add error message to the model
                ViewBag.Error = "Invalid login credentials";
            }
            // browser tab title
            ViewBag.Title = "Login";
            // reload page with current model data
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GuestLogin()
        {
            // sign in user based on the credentials supplied
            var result = await _signInManager.PasswordSignInAsync("HWMS062020101", "A.Abbington@wardx.co.za", false, false);
            // return user to default home page
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            // browser tab title
            ViewBag.Title = "Logout";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl, string userName)
        {
            // return URL was provided and is a supported path
            if (string.IsNullOrEmpty(returnUrl) == false && Url.IsLocalUrl(returnUrl))
            {
                // send user to previous page
                return Redirect(returnUrl);
            }
            // sign out user
            await _signInManager.SignOutAsync();

            // call the clock out method
            var user = await _userManager.FindByNameAsync(userName);
            if (user.StaffType == StaffType.Nurse)
            {
                ClockOut(user.StaffID);
            }

            // return user to login page
            return RedirectToAction(nameof(AccountController.Login));
        }
    }
}
