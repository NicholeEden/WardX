using System.Data.SqlClient;

namespace DataAccess.Domain.Interface.Component
{
    public interface ISQLParameter
    {
        /// <summary>
        /// Recieves input values in the constructor and make them accessable via this property
        /// </summary>
        SqlParameter[] Parameters { get; }
    }
}
