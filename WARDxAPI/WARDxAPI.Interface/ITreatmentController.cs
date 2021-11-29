using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace WARDxAPI.Interface
{
    public interface ITreatmentController
    {
        IActionResult Treatment();
        IActionResult Dispense();
        IActionResult Prescribe();
        IActionResult Information();
        IActionResult ViewPrescription();
        IActionResult RecordVitals();
        IActionResult ViewVitals();
        IActionResult RequestDoctor();

    }
}
