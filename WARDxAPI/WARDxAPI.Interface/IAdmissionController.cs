using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace WARDxAPI.Interface
{
    /// <summary>
    /// Defines the HTTP Get and Post methods for the 'Admission' Controller.
    /// </summary>
    public interface IAdmissionController
    {
        /// <summary>
        /// An HTTP Get to return the view used for Patient Admission
        /// </summary>
        /// <returns></returns>
        IActionResult Admit(int id);

        /// <summary>
        /// An HTTP Get to return the view used for AdmissionFile
        /// </summary>
        /// <returns></returns>
        IActionResult AdmissionFile();

        /// <summary>
        /// An HTTP Get to return the view used for EditAdmissionFile
        /// </summary>
        /// <returns></returns>
        IActionResult EditAdmissionFile(int id);

        /// <summary>
        /// An HTTP Get to return the view used for Discharge
        /// </summary>
        /// <returns></returns>
        IActionResult Discharge(int id);

        /// <summary>
        /// An HTTP Get to return the view used for Refferal
        /// </summary>
        /// <returns></returns>
        IActionResult Referral();

    }
}
