using DataAccess.Domain.Interface.Filter;
using DataAccess.Domain.Interface.Function;
using EFCore.Interface;
using System;
using System.Data.SqlClient;

namespace DataAccess.Domain.Interface
{
    public interface IPatientMovement_DataAccess :
        ICanSelect,
        ICanInsert,
        ICanUpdate,
        ISelectByPatient,
        ISelectByStatus,
        ISelectByReason,
        ISelectByDateRange,
        ISelectBySelf,ISelectByByNotification
    {
        /// <summary>
        /// Recieves input values and encapsulates them in an SQL Parameter object
        /// </summary>
        /// <param name="patientMovement"></param>
        /// <returns></returns>
        SqlParameter[] GetInsertParameters(IPatientMovement patientMovement);


     

        /// <summary>
        ///  Recieves input values and encapsulates them in an SQL Parameter object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SqlParameter[] GetSelectByPatientIDParameter(int id);

        /// <summary>
        ///  Recieves input values and encapsulates them in an SQL Parameter object
        /// </summary>
        /// <param name="isCheckOut"></param>
        /// <returns></returns>
        SqlParameter[] GetSelectByStatusParameter(bool isCheckOut);

        /// <summary>
        /// Recieves input values and encapsulates them in an SQL Parameter object
        /// </summary>
        /// <param name="patientMovement"></param>
        /// <returns></returns>

        SqlParameter[] GetUpdateParameters(IPatientMovement patientMovement);


        /// <summary>
        /// Recieves input values and encapsulates them in an SQL Parameter object
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        SqlParameter[] GetSelectByDateRangeParameters(IPatient patient, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Recieves input values and encapsulates them in an SQL Parameter object
        /// </summary>
        /// <param name="reason"></param>
        /// <returns></returns>
        SqlParameter[] GetSelectByReasonParameter(int reason);

        SqlParameter[] GetSelectByMoveIDParameter(int moveid);

        SqlParameter[] GetSelectByNotificationParameters(DateTime latetime, bool isCheckedOut);
    }
}
