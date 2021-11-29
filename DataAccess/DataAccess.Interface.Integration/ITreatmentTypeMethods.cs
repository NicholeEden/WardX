using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DataAccess.Interface.Integration
{
    public interface ITreatmentTypeMethods
    {
        /// <summary>
        /// Returns a Treatment Type table with all the entries
        /// </summary>
        DataTable Get_AllTreatmentType();
    }
}
