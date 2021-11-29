using DataAccess.Domain.Interface.Function;
using DataAccess.Domain.Interface.Filter;
using EFCore.Interface;
using System.Data.SqlClient;

namespace DataAccess.Domain.Interface
{
    public interface IMonth_DataAccess :
        ICanSelect
        

    {
        string sp_GetMonth();
        /// <summary>
        /// Recieves input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] GetSelectParameters(IMonth month);
        SqlParameter[] GetMonthID(int monthID);
    }
}
