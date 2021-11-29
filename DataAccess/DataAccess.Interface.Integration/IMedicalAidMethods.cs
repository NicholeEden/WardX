using EFCore.Interface;
using System.Data;

namespace DataAccess.Interface.Integration
{
    public interface IMedicalAidMethods
    {
        /// <summary>
        /// Returns the MedicalAid values based on the Patient ID
        /// </summary>
        /// <returns></returns>
        DataTable Get_MedicalAid(int patientID);

        /// <summary>
        /// Inserts a new MedicalAid entry
        /// </summary>
        /// <returns></returns>
        int Add_MedicalAid(IMedicalAid medicalAid);

        /// <summary>
        /// Updates a MedicalAid entry
        /// </summary>
        /// <returns></returns>
        int Update_MedicalAid(IMedicalAid medicalAid);
    }
}
