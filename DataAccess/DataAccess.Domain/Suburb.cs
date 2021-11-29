using DataAccess.Domain.Interface;
using EFCore.Interface;

namespace DataAccess.Domain
{
    public class Suburb : ISuburb_DataAccess
    {
        public string sp_Select()
        {
            return _StoredProcedureProvider.sp_SelectSuburb.ToString();
        }
    }
}