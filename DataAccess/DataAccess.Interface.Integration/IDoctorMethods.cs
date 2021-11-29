using System.Data;

namespace DataAccess.Interface.Integration
{
    public interface IDoctorMethods
    {
        /// <summary>
        /// Returns the Doctor table with all values of General Practitioners
        /// </summary>
        /// <returns></returns>
        DataTable GetAll_DoctorGP();

        /// <summary>
        /// Returns the Doctor table with all values of Ward Specialists
        /// </summary>
        /// <returns></returns>
        DataTable GetAll_DoctorSpecialist();

        /// <summary>
        /// Returns the Doctor table with Doctor name and contact details
        /// </summary>
        /// <returns></returns>
        DataTable GetDoctor_ContactInfo(int doctorID);
    }
}
