using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WARDxAPI.Model.Interface;

namespace WARDxAPI.Model.PatientMove
{
    public class MoveCheckIn : IMoveCheckIn
    {
        public List<ISelectOption> PatientNamesList { get; set; }
        public IList<ICardTableContent> CheckOuttableContents { get; set; }
        [Required(ErrorMessage = "Please select a patient")]
        public int PatientMovementID { get; set; }
        public int AdmissionFileID { get; set; }
        public DateTime MoveDate { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public bool isCheckedOut { get; set; }
        [Required(ErrorMessage = "Please enter a valid reason")]
        public Reason Reason { get; set; }

        [Required(ErrorMessage = "Please select a patient")]
        public int PatientID { get ; set; }
        public int CheckedInCounter { get; set; }
        public int CheckedOutCounter { get; set; }
    }
}