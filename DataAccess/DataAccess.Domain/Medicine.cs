using DataAccess.Domain.Interface;
using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Domain
{
    public class Medicine : IMedicine_DataAccess
    {
        public string sp_Select()
        {
            return _StoredProcedureProvider.sp_SelectMedication.ToString();
        }
    }
}
