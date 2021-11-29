using DataAccess.Domain.Interface.Component;
using DataAccess.Domain.Interface.Function;

namespace DataAccess.Domain.Interface
{
    public interface IUserRole_DataAccess :
        ICanSelect,
        ICanInsert,
        ISQLParameter,
        ICanUpdate
    {
    }
}
