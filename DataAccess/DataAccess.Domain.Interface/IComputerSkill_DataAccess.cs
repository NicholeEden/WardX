using DataAccess.Domain.Interface.Component;
using DataAccess.Domain.Interface.Function;

namespace DataAccess.Domain.Interface
{
    public interface IComputerSkill_DataAccess :
        ICanSelect,
        ICanInsert,
        ICanUpdate,
        ISQLParameter
    {
    }
}
