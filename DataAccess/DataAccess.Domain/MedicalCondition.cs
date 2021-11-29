using DataAccess.Domain.Interface;
using EFCore.Interface;

namespace DataAccess.Domain
{
    public class MedicalCondition : IMedicalCondition_DataAccess
    {
        public string sp_Select()
        {
            return _StoredProcedureProvider.sp_SelectMedicalCondition.ToString();
        }
    }
}
