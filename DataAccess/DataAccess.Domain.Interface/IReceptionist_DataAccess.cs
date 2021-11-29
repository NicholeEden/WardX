using DataAccess.Domain.Interface.Component;
using DataAccess.Domain.Interface.Function;

namespace DataAccess.Domain.Interface
{
    public interface IReceptionist_DataAccess :
        ICanInsert,
        ISQLParameter,
        ICanUpdate,
        ICanSelect
    {
    }
}
