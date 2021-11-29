using System;

namespace EFCore.Interface
{
    //TODO: Remove this interface
    public interface INurseInspection
    {
        int NurseInspectionID { get; set; }
        int NurseID { get; set; }
        int PatientID { get; set; }
        DateTime Date { get; set; }
        DateTime Time { get; set; }
        string Comments { get; set; }
    }
}
