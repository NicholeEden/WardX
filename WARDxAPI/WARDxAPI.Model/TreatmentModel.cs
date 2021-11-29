using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Treatment;

namespace WARDxAPI.Model
{
    public class TreatmentModel:ITreatmentModel
    {
        public TreatmentModel(IRecordTreatment recordTreatment, IAlertModel alert)
        {
            RecordTreatment = recordTreatment;
            alertModel = alert;
        }
        public IRecordTreatment RecordTreatment { get; set; }
        public IAlertModel alertModel { get ; set ; }
    }
}
