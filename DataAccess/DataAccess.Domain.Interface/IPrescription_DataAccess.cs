using DataAccess.Domain.Interface.Component;
using DataAccess.Domain.Interface.Filter;
using DataAccess.Domain.Interface.Function;
using EFCore.Interface;
using System.Data.SqlClient;

namespace DataAccess.Domain.Interface
{
    public interface IPrescription_DataAccess :
        ICanInsert,
        ISQLParameter,
        ICanSelect,
        ICanUpdate,
        ISelectByPatient
    {
        SqlParameter[] GetSelectByPatientParameters(int id);

        SqlParameter[] GetSelectByAdmissionFileParameters(int id);
        SqlParameter[] GetInsertParameters(IPrescription prescription);

        SqlParameter[] GetUpdateParameters(IPrescription prescription);
    }
}
