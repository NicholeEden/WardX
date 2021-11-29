using DataAccess.Domain.Interface.Component;
using DataAccess.Domain.Interface.Filter;
using DataAccess.Domain.Interface.Function;
using EFCore.Interface;
using System.Data.SqlClient;

namespace DataAccess.Domain.Interface
{
    public interface IAdmissionFile_DataAccess :
        ICanSelect,
        ICanUpdate,
        ICanInsert,
        ISelectByPatient,
        ISelectByAdmissionFile,
        IUpdateByDischarge
    
    {
        SqlParameter[] GetSelectAdmissionFile(int Id);

        SqlParameter[] GetInsertParameters(IAdmissionFile admission);

        SqlParameter[] GetUpdateParameters(IAdmissionFile admission);

        SqlParameter[] GetUpdateDischargeParameters(IAdmissionFile admission);

        SqlParameter[] GetSelectByPatientParameters(int id);
    }
}
