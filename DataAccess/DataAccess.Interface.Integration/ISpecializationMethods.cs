using System.Data;
using EFCore.Interface;

namespace DataAccess.Interface.Integration
{
    public interface ISpecializationMethods
    {
        DataTable Get_Specialization(ISpecialization specialization);

        /// <summary>
        /// Returns all values in the 'Specialization' table
        /// </summary>
        /// <returns></returns>
        DataTable GetAll_Specialization();
    }
}
