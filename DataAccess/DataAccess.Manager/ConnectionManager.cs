using DataAccess.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.IO;

namespace DataAccess.Manager
{
    public class ConnectionManager : IConnectionManager
    {
        public IConfiguration Configuration { get; set; }

        public SqlConnection GetConnection()
        {
            // an SqlConnection object is created
            SqlConnection connection = new SqlConnection(GetConnectionString());
            try
            {
                // attempt to open the connection
                connection.Open();
            }
            catch (Exception ex)
            {
                // if it fails, throw the exception details with a message
                throw new ArgumentException("Unable to open a connection to the database", ex);
            }

            // return the open connection
            return connection;
        }

        public string GetConnectionString()
        {
            // a ConfigurationBuilder object is created
            var builder = new ConfigurationBuilder()
                // get the current folder path of the application and
                // set it as the base path
                .SetBasePath(Directory.GetCurrentDirectory())
                // append the JSON file to be used to the base path
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true);

            // configure the IConfiguration interface to use the
            // setting applied in the ConfigurationBuilder
            Configuration = builder.Build();

            // get the value from the key 'ConnectionStrings:DefaultConnection' found 
            // in the 'appsettings.json' file
            string value = Configuration["ConnectionStrings:DefaultConnection"];

            // return the value
            return value;
        }
    }
}
