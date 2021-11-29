using System;

namespace EFCore.Interface
{
    public interface IPatientVital
    {
        int VitalSignID { get; set; }
        int AdmisssionFileID { get; set; }
        DateTime DateRecorded { get; set; }
    }
}
