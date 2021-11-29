using DataAccess.Domain.Interface;
using EFCore.Interface;

namespace DataAccess.Domain
{
    public class Specialization : ISpecialization_DataAccess
    {
        public string sp_Select()
        {
            return _StoredProcedureProvider.sp_SelectSpecialization.ToString();
        }
    }
}
