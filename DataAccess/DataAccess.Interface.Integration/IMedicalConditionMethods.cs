using System.Data;

namespace DataAccess.Interface.Integration
{
    public interface IMedicalConditionMethods
    {
        /// <summary>
        /// Returns the MedicalCondition values
        /// </summary>
        /// <returns></returns>
        DataTable GetAll_MedicalCondition();
    }
}
