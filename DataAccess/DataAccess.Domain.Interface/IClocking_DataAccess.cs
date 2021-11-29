using DataAccess.Domain.Interface.Component;
using DataAccess.Domain.Interface.Function;
using DataAccess.Domain.Interface.Filter;
using EFCore.Interface;
using System.Data.SqlClient;

namespace DataAccess.Domain.Interface
{
    public interface IClocking_DataAccess :
        ICanInsert,
        ISQLParameter,
        ICanSelect,
        ICanUpdate
    {
        /// <summary>
        /// Receives input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] GetInsertParameters(IClocking clocking);

        /// <summary>
        /// Receives input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] SqlParameters(IClocking clocking);

        /// <summary>
        /// Receives input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] GetSelectParameters(IClocking clocking);

        /// <summary>
        /// Receives input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] GetUpdateParameters(IClocking clocking);

        SqlParameter[] GetNurseIDParameter(int NurseID);

        string sp_Get_Clocking();

    }
}
