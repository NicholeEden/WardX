using DataAccess.Domain.Interface.Filter;
using System.Data.SqlClient;

namespace DataAccess.Domain.Interface
{
    public interface IDoctor_DataAccess :
        ISelectByDoctorGP,
        ISelectByDoctorSpecialist,
        ISelectByRequestDoctor
    {
        SqlParameter[] GetDoctorIDParameter(int ID);
    }
}
