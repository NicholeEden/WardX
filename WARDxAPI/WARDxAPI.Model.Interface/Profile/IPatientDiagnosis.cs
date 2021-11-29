using EFCore.Interface;
using System.Collections.Generic;

namespace WARDxAPI.Model.Interface.Profile
{
    public interface IPatientDiagnosis : IDiagnosis
    {
        /// <summary>
        /// Defines the medical condition options
        /// </summary>
        Dictionary<string, string> ConditionList { get; set; }

        /// <summary>
        /// Defines the general practitioner doctor options
        /// </summary>
        List<ISelectOption> DoctorList { get; set; }

        /// <summary>
        /// Defines the status box information
        /// </summary>
        IStatusBoxModel Status { get; set; }
    }
}
