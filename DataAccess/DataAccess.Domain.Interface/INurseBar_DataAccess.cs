using DataAccess.Domain.Interface.Component;
using DataAccess.Domain.Interface.Function;

namespace DataAccess.Domain.Interface
{
    public interface INurseBar_DataAccess :
        ICanInsert,
        ISQLParameter,
        ICanUpdate,
        ICanSelect
    {
    }
}
