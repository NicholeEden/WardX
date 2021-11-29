using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess.Interface.Integration
{
    public interface IMedicineMethods
    {
        /// <summary>
        /// Returns Medicine table with all the entries
        /// </summary>
        /// <returns></returns>
        DataTable Get_AllMedicine();
    }
}
