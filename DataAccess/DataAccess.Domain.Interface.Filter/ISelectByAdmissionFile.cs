using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Domain.Interface.Filter
{
    public interface ISelectByAdmissionFile
    {

        /// <summary>
        /// This method returns the stored procedure for selecting data from the table based on a AdmissionFileID
        /// </summary>
        /// <returns></returns>
        string sp_SelectByAdmissionFileID();
    }
}
