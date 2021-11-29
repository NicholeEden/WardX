using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface.Treatment;

namespace WARDxAPI.Model.Interface
{
    public interface IDispenseModel
    {
        //Defines the view to view Prescription for Paient Treatment 
        IViewPrescription ViewPrescription { get; set; }

        //Defines the view to dispense medication for Patient Treatment
        IDispenseMedication Dispense { get; set; }

        IAlertModel alertModel { get; set; }
    }
}
