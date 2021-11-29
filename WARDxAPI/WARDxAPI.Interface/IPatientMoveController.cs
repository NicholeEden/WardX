using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace WARDxAPI.Interface
{
    /// <summary>
    /// Defines the HTTP Get and Post methods for the 'PatientMove' Controller.
    /// </summary>
    public interface IPatientMoveController
    {
        #region CheckOut
        /// <summary>
        /// An HTTP Get to return the view used for Patient Check Out
        /// </summary>
        /// <returns></returns>
        IActionResult CheckOut();

       
        #endregion

        #region CheckIn
        // <summary>
        /// An HTTP Get to return the view used to Patient Check In
        /// </summary>
        /// <returns></returns>
        IActionResult CheckIn();

     
        #endregion

        #region Movements
        // <summary>
        /// An HTTP Get to return the view used to display Patient Movements
        /// </summary>
        /// <returns></returns>
        IActionResult Movements();

        #endregion

        // <summary>
        /// An HTTP Get to return the view used to Patient Follow Up
        /// </summary>
        /// <returns></returns>
        IActionResult FollowUp();


        IActionResult Online();


    }
}
