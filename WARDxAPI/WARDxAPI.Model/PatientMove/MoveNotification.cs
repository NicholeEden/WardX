using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WARDxAPI.Model.Interface;

namespace WARDxAPI.Model.PatientMove
{
    public class MoveNotification : IMoveNotification
    {
        public DateTime latetime { get; set; }
        public int PatientMovementID { get; set; }
        public int AdmissionFileID { get; set; }
        public DateTime MoveDate { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public bool isCheckedOut { get; set; }
        public Reason Reason { get; set; }
    }
}