using BusinessLogic.Interface;
using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BusinessLogic.Tests
{
    public class PatientMoveTests
    {
       

           
       




    }
    public class Move : IPatientMovement
    {
        public int PatientMovementID { get; set; }
        public int AdmissionFileID { get; set; }
        public DateTime MoveDate { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public bool isCheckedOut { get; set; }
        public Reason Reason { get; set; }
    }

}




