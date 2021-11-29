using System;

namespace EFCore.Interface
{
    public interface IPatientVisitor
    {
        int PatientVisitorID { get; set; }
        int AdmissionFileID { get; set; }
        DateTime VisitDate { get; set; }
        DateTime TimeIn { get; set; }

        /// <summary>
        /// Is null while the patient visitor is currently checked in
        /// </summary>
        DateTime? TimeOut { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        bool isCheckedIn { get; set; }
    }
}
