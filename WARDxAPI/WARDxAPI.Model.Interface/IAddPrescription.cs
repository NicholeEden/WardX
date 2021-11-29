using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface.Treatment;

namespace WARDxAPI.Model.Interface
{
    public interface IAddPrescription
    {
        //Defines the view to record treatment
        IRecordPrescription PrescriptionModel{get ; set; }
        IAlertModel alertModel { get; set; }
    }
}
