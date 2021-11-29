using System;

namespace EFCore.Interface
{
    public interface IAdmissionFile
    {
        int AdmissionFileID { get; set; }
        int PatientID { get; set; }
        DateTime AdmissionDate { get; set; }
        int AssignedSpecialistID { get; set; }
        DateTime? DischargeDate { get; set; }
        int BedID { get; set; }
        int? PrescriptionID { get; set; }
        string Notes { get; set; }
    }
}
