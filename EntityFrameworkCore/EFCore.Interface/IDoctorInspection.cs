using System;

namespace EFCore.Interface
{
    //TODO: Remove this interface
    public interface IDoctorInspection
    {
        int DoctorInspectionID { get; set; }
        int DoctorID { get; set; }
        int PatientID { get; set; }
        DateTime Date { get; set; }
        string Comments { get; set; }
    }
}
