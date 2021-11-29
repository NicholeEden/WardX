using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Treatment;

namespace WARDxAPI.Model
{
    public class AddPrescription:IAddPrescription
    {
        public AddPrescription(IRecordPrescription recordPrescription, IAlertModel alert)
        {
            PrescriptionModel = recordPrescription;
            alertModel = alert;
        }
        public IRecordPrescription PrescriptionModel { get; set; }
        public IAlertModel alertModel { get ; set ; }
    }
}
