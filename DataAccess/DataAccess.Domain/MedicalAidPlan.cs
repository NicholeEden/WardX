using DataAccess.Domain.Interface;
using EFCore.Interface;

namespace DataAccess.Domain
{
    public class MedicalAidPlan : IMedicalAidPlan_DataAccess
    {
        public string sp_Select()
        {
            return _StoredProcedureProvider.sp_SelectMedicalAidPlan.ToString();
        }
    }
}
