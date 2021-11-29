using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WARDxAPI.Model.Interface;

namespace WARDxAPI.Model.PatientMove
{
    public class MoveReport : IMoveReport
    {
        public List<ISelectOption> PatientNamesList { get; set; }
        public Reason ReasonList { get; set; }

        public IList<ICardTableContent> CheckOuttableContents { get; set; }
        public int PatientMovementID { get; set; }
        public int AdmissionFileID { get; set; }
        public DateTime MoveDate { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public bool isCheckedOut { get; set; }
        public Reason Reason { get; set; }

        [Required(ErrorMessage = "Please select a patient")]
        public int PatientID { get ; set; }
        public DateTime startDate { get ; set; }
        public DateTime endDate { get; set ; }
       
        public string DateInput { get ; set; }


    }
}