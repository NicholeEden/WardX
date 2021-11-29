using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface.Treatment;

namespace WARDxAPI.Model.Interface
{
    public interface ITreatmentModel
    {
        //Defines the view to record treatment
        IRecordTreatment RecordTreatment { get; set; }

        

        IAlertModel alertModel { get; set; }
    }
}
