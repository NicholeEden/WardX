using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Model
{
    public class Medication : IMedication
    {
        public int MedicationID { get; set; }
        public string MedicationName { get ; set ; }
        public int MedicationScheduleID { get ; set ; }
        public string MedicationStrength { get ; set ; }
        public DateTime ExpiryDate { get ; set ; }
        public int FormulationID { get ; set ; }
    }
}
