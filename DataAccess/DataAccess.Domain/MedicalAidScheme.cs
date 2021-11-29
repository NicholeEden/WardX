using DataAccess.Domain.Interface;
using EFCore.Interface;

namespace DataAccess.Domain
{
    public class MedicalAidScheme : IMedicalAidScheme_DataAccess
    {
        public string sp_Select()
        {
            return _StoredProcedureProvider.sp_SelectMedicalAidScheme.ToString();
        }
    }
}
