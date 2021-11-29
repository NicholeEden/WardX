using EFCore.Interface;
using System.Data;

namespace DataAccess.Interface.Integration
{
    public interface INextOfKinMethods
    {
        /// <summary>
        /// Returns the NextOfKin values based on the Patient ID
        /// </summary>
        /// <returns></returns>
        DataTable Get_NextOfKin(int patientID);

        /// <summary>
        /// Inserts a new NextOfKin entry
        /// </summary>
        /// <returns></returns>
        int Add_NextOfKin(INextOfKin nextOfKin);

        /// <summary>
        /// Updates a NextOfKin entry
        /// </summary>
        /// <returns></returns>
        int Update_NextOfKin(INextOfKin nextOfKin);
    }
}
