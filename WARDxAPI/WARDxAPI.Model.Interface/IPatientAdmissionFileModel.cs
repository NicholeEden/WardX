using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface.Admission;

namespace WARDxAPI.Model.Interface
{
    public interface IPatientAdmissionFileModel
    {
        IViewAdmissionFileModel ViewAdmissionFileModel { get; set; }

        IPatientAdmissionFileUpdate PatientAdmissionFileUpdate { get; set; }

        IAlertModel AlertModel { get; set; }
    }
}
