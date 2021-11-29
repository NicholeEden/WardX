using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace WARDxAPI.Model.Interface.Admission
{
    public interface IPatientAdmitDiagnosis : IDiagnosis
    {
        /// <summary>
        /// Defines the medical condition options
        /// </summary>
        Dictionary<string, string> ConditionList { get; set; }

        /// <summary>
        /// Defines the general practitioner doctor options
        /// </summary>
        List<ISelectOption> DoctorList { get; set; }
    }
}
