using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Interface
{
    /// <summary>
    /// This helper class will execute the queries provided by the Data Access
    /// Domain classes.
    /// </summary>
    public interface IQueryManager
    {
        /// <summary>
        /// For an INSERT and an UPDATE, the value will be a positive number.
        /// For a DELETE, the value will be negative.
        /// If the query fails, a ZERO will be returned.
        /// </summary>
        /// <param name="storedProcedure"></param>
        /// <returns></returns>
        int ExecuteNonQuery(string storedProcedure);

        /// <summary>
        /// For an INSERT and an UPDATE, the value will be a positive number.
        /// For a DELETE, the value will be negative.
        /// If the query fails, a ZERO will be returned.
        /// </summary>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        int ExecuteNonQuery(string storedProcedure, SqlParameter[] parameters);

        /// <summary>
        /// For an ISERT, the value will the value of returnParameter
        /// </summary>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters"></param>
        /// <param name="returnParameter"></param>
        /// <returns></returns>
        int ExecuteNonQuery(string storedProcedure, SqlParameter[] parameters, string returnParameter);

        /// <summary>
        /// This method returns a DataTable based on the stored procedure used.
        /// </summary>
        /// <param name="storedProcedure"></param>
        /// <returns></returns>
        DataTable ExecuteQuery(string storedProcedure);

        /// <summary>
        /// This method returns a DataTable based on the stored procedure used.
        /// </summary>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        DataTable ExecuteQuery(string storedProcedure, SqlParameter[] parameters);
    }
}
