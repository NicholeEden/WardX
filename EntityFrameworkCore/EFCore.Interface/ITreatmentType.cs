using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Interface
{
    public interface ITreatmentType
    {
        int TreatmentTypeID { get; set; }
        string Description { get; set; }
    }
}
