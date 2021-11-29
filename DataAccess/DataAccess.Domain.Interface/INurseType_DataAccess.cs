using DataAccess.Domain.Interface.Component;
using DataAccess.Domain.Interface.Function;
using DataAccess.Domain.Interface.Filter;
using EFCore.Interface;
using System.Data.SqlClient;

namespace DataAccess.Domain.Interface
{
    public interface INurseType_DataAccess :
        ICanSelect
    {
        /// <summary>
        /// Recieves input values and encapsulates them in an SQL Parameter object
        /// </summary>
        SqlParameter[] GetSelectParameters(INurseType nurseType);
    }
}
