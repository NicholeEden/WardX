using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace WARDxAPI.Interface
{
    public interface IStaffSchedulingController
    {
        IActionResult CreateSchedule();
        IActionResult ViewSchedule();
        IActionResult GenerateTimesheet();
        IActionResult ViewTimesheet();
    }
}