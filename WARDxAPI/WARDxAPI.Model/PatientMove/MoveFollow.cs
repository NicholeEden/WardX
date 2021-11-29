using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.PatientMove;

namespace WARDxAPI.Model.PatientMove
{
    public class moveFollow : IMoveFollow
    {
        public List<ISelectOption> PatientEmailList { get; set; }
        public int PatientID { get; set; }
        public int PatientMovementID { get; set; }
        public int AdmissionFileID { get; set; }
        public DateTime MoveDate { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public bool isCheckedOut { get; set; }
        public Reason Reason { get; set; }
        public string Body { get; set; }

        [Required(ErrorMessage = "Please enter a valid subject")]
        public string Subject { get; set; }

        public string fromEmail { get; set; }
        [Required(ErrorMessage = "Please select a valid email address"),
            MaxLength(1024),
            DataType(DataType.EmailAddress),
            Display(Name = "Email Address"),
          ]
        public string toEmail { get; set; }
    }
}
