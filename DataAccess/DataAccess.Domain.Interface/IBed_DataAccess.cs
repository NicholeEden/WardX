using DataAccess.Domain.Interface.Component;
using DataAccess.Domain.Interface.Filter;
using DataAccess.Domain.Interface.Function;
using EFCore.Interface;
using System.Data.SqlClient;

namespace DataAccess.Domain.Interface
{
    public interface IBed_DataAccess :
        ICanSelect,
        ICanUpdate,
        ISelectAllBeds

    {
        SqlParameter[] GetUpdateParameters(IBed bed);
        SqlParameter[] GetUpdateBedStatusParameters(int Id, bool isAvailable);
        SqlParameter[] SelectByisAvailableParemeter(bool isAvailable);
    }
}
