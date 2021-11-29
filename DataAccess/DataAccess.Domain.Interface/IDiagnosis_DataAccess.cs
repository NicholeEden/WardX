using DataAccess.Domain.Interface.Filter;
using DataAccess.Domain.Interface.Function;
using EFCore.Interface;
using System.Data.SqlClient;

namespace DataAccess.Domain.Interface
{
    public interface IDiagnosis_DataAccess :
        ICanInsert,
        ISelectBySelf
    {
        /// <summary>
        /// Recieves input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] GetIDParameter(int id);

        /// <summary>
        /// Recieves input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] GetInsertParameters(IDiagnosis diagnosis);
    }
}
