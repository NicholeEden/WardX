using EFCore.Interface;
using System.Collections.Generic;

namespace WARDxAPI.Model.Interface.Profile
{
    public interface IPatientReferral : IReferral
    {
        /// <summary>
        /// Defines the patient options
        /// </summary>
        List<ISelectOption> PatientList { get; set; }

        /// <summary>
        /// Defines the ward specialist doctor options
        /// </summary>
        List<ISelectOption> SpecialistList { get; set; }

        /// <summary>
        /// Defines the general practitioner doctor options
        /// </summary>
        List<ISelectOption> GPDoctorList { get; set; }

        /// <summary>
        /// Defines the property used to store the admission date before conversion to 'DateTime'
        /// </summary>
        string DateInput { get; set; }

        /// <summary>
        /// Defines the status box information
        /// </summary>
        IStatusBoxModel Status { get; set; }
    }
}
