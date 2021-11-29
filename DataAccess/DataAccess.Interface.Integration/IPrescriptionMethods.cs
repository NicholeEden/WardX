using EFCore.Interface;
using System.Data;

namespace DataAccess.Interface.Integration
{
    public interface IPrescriptionMethods
    {
        /// <summary>
        /// Returns Prescription table based on the provided PatientID
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        DataTable Get_Prescription(int patientID);

        /// <summary>
        /// Returns Prescription table with all the entries
        /// </summary>
        /// <returns></returns>
        DataTable Get_AllPrecsription();

        /// <summary>
        /// Adds a new entry to the Prescription table
        /// </summary>
        /// <param name="prescription"></param>
        /// <returns></returns>
        int Add_Prescription(IPrescription prescription);

        /// <summary>
        /// Updates a record in the Prescription table
        /// </summary>
        /// <param name="prescription"></param>
        /// <returns></returns>
        int Update_Prescription(IPrescription prescription);

    }
}
