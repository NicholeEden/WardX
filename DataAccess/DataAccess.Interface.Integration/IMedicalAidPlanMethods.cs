using System.Data;

namespace DataAccess.Interface.Integration
{
    public interface IMedicalAidPlanMethods
    {
        /// <summary>
        /// Returns the full MedicalAidPlan table with all values
        /// </summary>
        /// <returns></returns>
        DataTable GetAll_MedicalAidPlan();
    }
}
