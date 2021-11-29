using DataAccess.Domain.Interface.Filter;
using DataAccess.Domain.Interface.Function;
using EFCore.Interface;
using System.Data.SqlClient;

namespace DataAccess.Domain.Interface
{
    public interface IMedicalAid_DataAccess :
        ISelectByPatient,
        ICanInsert,
        ICanUpdate
    {
        /// <summary>
        /// Recieves input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] GetPatientIDParameter(int id);

        /// <summary>
        /// Recieves input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] GetInsertParameters(IMedicalAid medicalAid);

        /// <summary>
        /// Recieves input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] GetUpdateParameters(IMedicalAid medicalAid);
    }
}
