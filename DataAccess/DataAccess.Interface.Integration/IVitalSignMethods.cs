using EFCore.Interface;
using System.Data;

namespace DataAccess.Interface.Integration
{
    public interface IVitalSignMethods
    {
        /// <summary>
        /// Returns Vital Signs table based on provided AdmissionFileNo
        /// </summary>
        /// <param name="AdmissionFileID"></param>
        /// <returns></returns>
        DataTable Get_VitalSigns(int AdmissionFileID);

        /// <summary>
        /// Adds a new entry to the Vital signs table
        /// </summary>
        /// <param name="vitalsign"></param>
        /// <returns></returns>
        int Add_VitalSigns(IVitalSign vitalsign);

    }
}
