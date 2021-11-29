using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Interface
{
    public interface ITreatment
    {
        int TreatmentID { get; set; }
        int NurseID { get; set; }
        int PatientID { get; set; }
        int TreatmentTypeID { get; set; }
        string ObservationNotes { get; set; }
    }
}
