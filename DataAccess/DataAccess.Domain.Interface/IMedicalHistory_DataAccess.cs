using DataAccess.Domain.Interface.Component;
using DataAccess.Domain.Interface.Function;

namespace DataAccess.Domain.Interface
{
    public interface IMedicalHistory_DataAccess :
        ICanSelect,
        ICanUpdate,
        ISQLParameter,
        ICanInsert
    {
    }
}
