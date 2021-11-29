using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DataAccess.Interface
{
    /// <summary>
    /// This helper class manages the application's default database connection set
    /// in the 'appsettings.json' file.
    /// </summary>
    public interface IConnectionManager
    {
        /// <summary>
        /// The IConfiguration interface allows us to access key value pairs 
        /// inside the 'appsettings.json' file.
        /// </summary>
        IConfiguration Configuration { get; set; }

        /// <summary>
        /// This method returns an open SQL connection object.
        /// Otherwise an exception is thrown when unable to open the connection.
        /// </summary>
        /// <returns></returns>
        SqlConnection GetConnection();

        /// <summary>
        /// This method returns the connection string that is defined in
        /// the 'appsettings.json' file.
        /// </summary>
        /// <returns></returns>
        string GetConnectionString();
    }
}
