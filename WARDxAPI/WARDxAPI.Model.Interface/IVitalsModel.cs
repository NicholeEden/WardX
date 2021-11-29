using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface.Treatment;

namespace WARDxAPI.Model.Interface
{
    public interface IVitalsModel
    {
        //Defines the view to view Patient's vitals Signs for Patient Treatment
        IViewVitals ViewVitals { get; set; }

        //Defines the view to record Vital signs for Patient Treatment
        IRecordVitals RecordVitals { get; set; }

        IAlertModel alertModel { get; set; }
    }
}
