using System;

namespace EFCore.Interface
{
    public interface IMedication
    {
        int MedicationID { get; set; }
        string MedicationName { get; set; }
        int MedicationScheduleID { get; set; }
        string MedicationStrength { get; set; }
        DateTime ExpiryDate { get; set; }
        int FormulationID { get; set; }
    }
}
