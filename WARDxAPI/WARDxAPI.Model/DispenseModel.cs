using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Treatment;

namespace WARDxAPI.Model
{
    public class DispenseModel : IDispenseModel
    {
        public DispenseModel(IDispenseMedication dispense, IViewPrescription prescription, IAlertModel alert)
        {
            Dispense = dispense;
            ViewPrescription = prescription;
            alertModel = alert;
        }
        public IViewPrescription ViewPrescription { get; set; }
        public IDispenseMedication Dispense { get ; set ; }
        public IAlertModel alertModel { get ; set ; }
    }
}
