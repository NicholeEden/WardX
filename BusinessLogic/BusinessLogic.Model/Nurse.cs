using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Model
{
    public class Nurse : INurse
    {
        public int NurseID { get; set; }
        public bool isWardManager { get; set; }
        public bool isHeadNurse { get; set; }
        public int SpecializationID { get; set; }
        public int NurseTypeID { get; set; }
    }
}
