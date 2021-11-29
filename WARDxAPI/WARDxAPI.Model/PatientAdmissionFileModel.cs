using System;
using System.Collections.Generic;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Admission;
using System.Text;

namespace WARDxAPI.Model
{
    public class PatientAdmissionFileModel : IPatientAdmissionFileModel
    {
        public PatientAdmissionFileModel(IViewAdmissionFileModel viewAdmissionFileModel, IPatientAdmissionFileUpdate patientAdmissionFileUpdate, IAlertModel alertModel)
        {
            ViewAdmissionFileModel = viewAdmissionFileModel;
            PatientAdmissionFileUpdate = patientAdmissionFileUpdate;
            AlertModel = alertModel;
        }
        public IViewAdmissionFileModel ViewAdmissionFileModel { get; set; }
        public IPatientAdmissionFileUpdate PatientAdmissionFileUpdate { get; set; }
        public IAlertModel AlertModel { get; set; }
    }
}
