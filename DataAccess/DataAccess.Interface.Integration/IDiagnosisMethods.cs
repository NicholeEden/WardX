using EFCore.Interface;
using System.Data;

namespace DataAccess.Interface.Integration
{
    public interface IDiagnosisMethods
    {
        /// <summary>
        /// Returns the Diagnosis values based on the ID
        /// </summary>
        /// <returns></returns>
        DataTable Get_Diagnosis(int id);

        /// <summary>
        /// Inserts a new Diagnosis entry
        /// </summary>
        /// <returns></returns>
        int Add_Diagnosis(IDiagnosis diagnosis);
    }
}
