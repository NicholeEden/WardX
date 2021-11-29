using System;

namespace EFCore.Interface
{
    public interface IPrescription
    {
        int PrescriptionID { get; set; }
        int MedicationID { get; set; }
        int DoctorID { get; set; }
        double Dosage { get; set; }
        DateTime DateIssued { get; set; }
        string Instruction { get; set; }
    }
}
