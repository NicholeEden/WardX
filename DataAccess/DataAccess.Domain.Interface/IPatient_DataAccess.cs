using DataAccess.Domain.Interface.Filter;
using DataAccess.Domain.Interface.Function;
using EFCore.Interface;
using System.Data.SqlClient;

namespace DataAccess.Domain.Interface
{
    public interface IPatient_DataAccess :
        ISelectByPatient,
        ICanInsert,
        ICanUpdate,
        ICanSelect,
        ISelectByName
    {
        /// <summary>
        /// Returns a stored procedure for selecting patients without referrals
        /// </summary>
        /// <returns></returns>
        string sp_GetPatientNoReferral();

        /// <summary>
        /// Returns a stored procedure for selecting patients referral history
        /// </summary>
        /// <returns></returns>
        string sp_GetPatientReferralTimeline();

        /// <summary>
        /// Returns a stored procedure for selecting patients treatment history
        /// </summary>
        /// <returns></returns>
        string sp_GetPatientTreatmentTimeline();

        /// <summary>
        /// Receives input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] GetIDParameter(int id);

        /// <summary>
        /// Receives input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] GetNameParameter(string name);

        /// <summary>
        /// Receives input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] GetInsertParameters(IPatient patient);

        /// <summary>
        /// Receives input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] GetUpdateParameters(IPatient patient);
    }
}
