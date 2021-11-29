using System.Data;

namespace DataAccess.Interface.Integration
{
    public interface IDoctorTypeMethods
    {
        /// <summary>
        /// Returns the Doctor Type values
        /// </summary>
        /// <returns></returns>
        DataTable Get_DoctorType();
    }
}
