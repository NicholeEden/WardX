using EFCore.Interface;
using System.Data;

namespace DataAccess.Interface.Integration
{
    public interface IEmergencyContactMethods
    {
        /// <summary>
        /// Returns the EmergencyContact values based on the Patient ID
        /// </summary>
        /// <returns></returns>
        DataTable Get_EmergencyContact(int patientID);

        /// <summary>
        /// Inserts a new EmergencyContact entry
        /// </summary>
        /// <returns></returns>
        int Add_EmergencyContact(IEmergencyContact emergencyContact);

        /// <summary>
        /// Updates a EmergencyContact entry
        /// </summary>
        /// <returns></returns>
        int Update_EmergencyContact(IEmergencyContact emergencyContact);
    }
}
