using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Model
{
    public class Treatment : ITreatment
    {
        public int TreatmentID { get ; set ; }
        public int NurseID { get ; set ; }
        public int PatientID { get ; set ; }
        public int TreatmentTypeID { get ; set ; }
        public string ObservationNotes { get ; set ; }
    }
}
