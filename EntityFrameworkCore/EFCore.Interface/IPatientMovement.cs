using System;

namespace EFCore.Interface
{
    public interface IPatientMovement
    {
        int PatientMovementID { get; set; }

        int AdmissionFileID { get; set; }

        DateTime MoveDate { get; set; }

        /// <summary>
        /// Is null while the patient is still checked out
        /// </summary>
        /// 
        DateTime? CheckInTime { get; set; }

        DateTime CheckOutTime { get; set; }

        bool isCheckedOut { get; set; }

        Reason Reason { get; set; }
    }
}