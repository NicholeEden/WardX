using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace WARDxAPI.Model.Interface.Treatment
{
    public interface IDispenseMedication
    {
        IPatient Patient { get; set; }
        IDoctor Doctor { get; set; }
        IPrescription Prescription { get; set; }

        //List<CardTableContent>
    }
}
