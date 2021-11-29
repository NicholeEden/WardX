using DataAccess.Domain.Interface.Component;
using DataAccess.Domain.Interface.Function;

namespace DataAccess.Domain.Interface
{
    public interface IProcedureHistory_DataAccess :
        ICanInsert,
        ISQLParameter,
        ICanSelect
    {
    }
}
