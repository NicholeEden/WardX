using System.Data;

namespace DataAccess.Interface.Integration
{
    public interface IMedicalAidSchemeMethods
    {
        /// <summary>
        /// Returns the MedicalAidScheme values
        /// </summary>
        /// <returns></returns>
        DataTable GetAll_MedicalAidScheme();
    }
}
