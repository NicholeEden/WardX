using BusinessLogic.Model;
using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WARDxAPI.Interface;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Admission;
using WARDxAPI.Model.Shared;

namespace WARDxAPI.Models
{
    public class AdmissionModelProvider : IAdmissionModelProvider
    {
        public AdmissionModelProvider(ICreateAdmissionModel createModel, IPatientAdmissionFileModel admissionFileModel)
        {
            CreateAdmitModel = createModel;

            AdmissionFileModel = admissionFileModel;

        }
        

        public ICreateAdmissionModel CreateAdmitModel { get; }

        public IPatientAdmissionFileModel AdmissionFileModel { get; }

    }
}
