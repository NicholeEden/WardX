using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface.Treatment;

namespace WARDxAPI.Model.Treatment
{
    public class DispenseMedication : IDispenseMedication
    {
        public IPatient Patient { get ; set ; }
        public IDoctor Doctor { get; set ; }
        public IPrescription Prescription { get ; set ; }
    }
}
