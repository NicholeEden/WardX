using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Model
{
    public class VitalSign : IVitalSign
    {
        public int VitalSignID { get ; set ; }
        public int BloodGroupID { get ; set; }
        public string Hypoglycemia { get ; set ; }
        public string BodyTemperature { get ; set ; }
        public string PulseRate { get ; set; }
        public string BloodPressure { get ; set; }
        public string Weight { get ; set ; }
        public string BMI { get ; set ; }
    }
}
