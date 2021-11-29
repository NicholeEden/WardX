using BusinessLogic.Model;
using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Admission;

namespace WARDxAPI.Interface
{
    /// <summary>
    /// Defines the models required by the Admission Controller and Views
    /// </summary>
    public interface IAdmissionModelProvider
    {

        /// <summary>
        /// Defines the models needed to create an admissionFile
        /// </summary>
        ICreateAdmissionModel CreateAdmitModel { get; }


        IPatientAdmissionFileModel AdmissionFileModel { get; }
        


    }
}
