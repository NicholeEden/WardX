using DataAccess.Domain.Interface.Component;
using DataAccess.Domain.Interface.Function;

namespace DataAccess.Domain.Interface
{
    public interface IDoctorSchedule_DataAccess :
        ICanInsert,
        ISQLParameter,
        ICanSelect,
        ICanUpdate
    {
    }
}
