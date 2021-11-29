using System.Data;
using EFCore.Interface;

namespace DataAccess.Tests

{
    internal interface IMonthMethods_DataAccess
    {
        DataTable GetAllMonths();
        public string sp_GetMonth();
        
   
    }

    
}