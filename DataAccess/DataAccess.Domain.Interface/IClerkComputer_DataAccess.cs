using DataAccess.Domain.Interface.Component;
using DataAccess.Domain.Interface.Function;

namespace DataAccess.Domain.Interface
{
    public interface IClerkComputer_DataAccess :
        ICanInsert,
        ICanUpdate,
        ISQLParameter,
        ICanSelect
    {


    }
}
