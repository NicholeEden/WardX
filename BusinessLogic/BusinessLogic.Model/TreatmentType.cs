using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Model
{
    public class TreatmentType : ITreatmentType
    {
        public int TreatmentTypeID { get ; set ; }
        public string Description { get ; set ; }
    }
}
