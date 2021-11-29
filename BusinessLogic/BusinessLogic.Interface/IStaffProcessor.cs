using BusinessLogic.Model;
using System.Collections.Generic;

namespace BusinessLogic.Interface
{
    /// <summary>
    /// Defines the methods for processing 'Staff' information
    /// </summary>
    public interface IStaffProcessor
    {
        /// <summary>
        /// Returns the all the database entries as a list of 'IDoctor' and 'IStaffmember' objects
        /// </summary>
        /// <returns></returns>
        List<Doctor> GetGPDoctors();

        /// <summary>
        /// Returns the all the database entries as a list of 'IDoctor' and 'IStaffmember' objects
        /// </summary>
        /// <returns></returns>
        List<Doctor> GetSpecialistDoctors();
        List<Nurse> GetNurseID();

        /// <summary>
        /// Returns the specified database entry as an 'ISpecialization' object
        /// </summary>
        /// <param name="specializationID"></param>
        /// <returns></returns>
        Specialization GetSpecialization(int specializationID);

        /// <summary>
        /// Returns  the specified database entry as an 'IDoctor' and 'IStaffMember' object
        /// </summary>
        /// <returns></returns>
        Doctor GetGPDoctor(int doctorID);

        /// <summary>
        /// Returns  the specified database entry as an 'IDoctor' and 'IStaffMember' object
        /// </summary>
        /// <returns></returns>
        Doctor GetSpecialistDoctor(int doctorID);
    }
}
