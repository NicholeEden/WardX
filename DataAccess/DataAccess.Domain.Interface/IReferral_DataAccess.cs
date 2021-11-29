using DataAccess.Domain.Interface.Filter;
using DataAccess.Domain.Interface.Function;
using EFCore.Interface;
using System.Data.SqlClient;

namespace DataAccess.Domain.Interface
{
    public interface IReferral_DataAccess :
        ISelectByPatient,
        ICanInsert,
        ICanSelect,
        ICanUpdate,
        IUpdateReferralStatus
    {
        /// <summary>
        /// Receives input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] GetPatientIDParameter(int id);

        /// <summary>
        /// Receives input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] GetInsertParameters(IReferral referral);

        SqlParameter[] GetUpdateParameters(IReferral referral);

        SqlParameter[] GetReferralByisAdmittedParameter(bool isAdmitted);

        SqlParameter[] GetUpdateReferralStatus(int Id, bool isAdmitted);
        string sp_SelectPending();
    }
}
