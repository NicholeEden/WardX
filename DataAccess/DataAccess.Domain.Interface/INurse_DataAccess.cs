using DataAccess.Domain.Interface.Component;
using DataAccess.Domain.Interface.Function;
using DataAccess.Domain.Interface.Filter;
using EFCore.Interface;
using System.Data.SqlClient;

namespace DataAccess.Domain.Interface
{
    public interface INurse_DataAccess :
        ICanInsert,
        ISQLParameter,
        ICanUpdate,
        ICanSelect
    {
        /// <summary>
        /// Recieves input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] GetInsertParameters(INurse nurse);

        /// <summary>
        /// Recieves input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] SqlParameters(INurse nurse);

        /// <summary>
        /// Recieves input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] GetUpdateParameters(INurse nurse);

        /// <summary>
        /// Recieves input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] GetSelectParameters(INurse nurse);
        string sp_Get_Nurse();
        SqlParameter[] GetNurseID(int nurseID);
    }
}
