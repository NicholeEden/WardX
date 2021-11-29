using System;

namespace EFCore.Interface
{
    public interface IProcedureHistory
    {
        int ProcedureID { get; set; }
        DateTime AppointmentDate { get; set; }
        DateTime AppointmentTime { get; set; }
        string ProcedureDescription { get; set; }
        int PatientID { get; set; }
        string Notes { get; set; }
    }
}
