using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Treatment;

namespace WARDxAPI.Model
{
    public class VitalsModel: IVitalsModel
    {
        public VitalsModel(IRecordVitals recordVitals, IViewVitals viewVitals, IAlertModel alert)
        {
            RecordVitals = recordVitals;
            ViewVitals = viewVitals;
            alertModel = alert;
        }
        public IRecordVitals RecordVitals { get; set; }
        public IViewVitals ViewVitals { get; set; }
        public IAlertModel alertModel { get ; set ; }
    }
}
