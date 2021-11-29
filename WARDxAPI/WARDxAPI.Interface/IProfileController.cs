using Microsoft.AspNetCore.Mvc;

namespace WARDxAPI.Interface
{
    /// <summary>
    /// Defines the HTTP Get and Post methods for the 'Profile' Controller.
    /// </summary>
    public interface IProfileController
    {
        /// <summary>
        /// An HTTP Get to return the view used to create a patient profile
        /// </summary>
        /// <returns></returns>
        IActionResult Create();

        /// <summary>
        /// An HTTP Get to return the view used to create a patient profile
        /// </summary>
        /// <returns></returns>
        IActionResult NextofKin();

        /// <summary>
        /// An HTTP Get to return the view used to create a patient profile
        /// </summary>
        /// <returns></returns>
        IActionResult MedicalAid();

        /// <summary>
        /// An HTTP Get to return the view used to create a patient profile
        /// </summary>
        /// <returns></returns>
        IActionResult Confirm();

        /// <summary>
        /// An HTTP Get to return the view used to show patient details
        /// </summary>
        /// <returns></returns>
        IActionResult Details(int id);

        /// <summary>
        /// An HTTP Get to return the view used to create a diagnosis for a patient
        /// </summary>
        /// <returns></returns>
        IActionResult Diagnosis();

        /// <summary>
        /// An HTTP Get to return the view used to search for a patient profile
        /// </summary>
        /// <returns></returns>
        IActionResult Search();

        /// <summary>
        /// An HTTP Get to return the view used to refer a patient for admission
        /// </summary>
        /// <returns></returns>
        IActionResult Referral();

        /// <summary>
        /// An HTTP Get to return the view used to refer a patient for admission
        /// </summary>
        /// <returns></returns>
        IActionResult Submit();

        /// <summary>
        /// An HTTP Get to return the view to monitor a patient
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IActionResult Monitor(int id);
    }
}