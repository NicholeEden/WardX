using DataAccess.Domain.Interface.Component;
using DataAccess.Domain.Interface.Function;
using DataAccess.Domain.Interface.Filter;
using System.Data.SqlClient;
using EFCore.Interface;

namespace DataAccess.Domain.Interface
{
    public interface IVitalSign_DataAccess :
        ICanSelect,
        ISQLParameter,
        ICanInsert,
        ICanUpdate,
        ISelectByAdmissionFile
    {
        SqlParameter[] GetSelectByAdmissionFileParameters(int id);
        SqlParameter[] GetInsertParameters(IVitalSign vitalSign);
    }
}
