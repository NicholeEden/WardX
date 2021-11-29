using DataAccess.Interface;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Manager
{
    public class QueryManager : IQueryManager
    {
        private readonly IConnectionManager connectionManager;

        public QueryManager(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }

        public int ExecuteNonQuery(string storedProcedure)
        {
            // get open connection
            using (var connection = connectionManager.GetConnection())
            {
                // create a command object
                using (var command = new SqlCommand(storedProcedure, connection))
                {
                    // specify the command type
                    command.CommandType = CommandType.StoredProcedure;

                    // execute the command
                    var result = command.ExecuteNonQuery();

                    // return execute value
                    return result;
                }
            }
        }

        public int ExecuteNonQuery(string storedProcedure, SqlParameter[] parameters)
        {
            // get open connection
            using (var connection = connectionManager.GetConnection())
            {
                // create a command object
                using (var command = new SqlCommand(storedProcedure, connection))
                {
                    // specify the command type
                    command.CommandType = CommandType.StoredProcedure;

                    // add the paramemeters
                    command.Parameters.AddRange(parameters);

                    // execute the command
                    var result = command.ExecuteNonQuery();

                    // return execute value
                    return result;
                }
            }
        }

        public int ExecuteNonQuery(string storedProcedure, SqlParameter[] parameters, string returnParameter)
        {
            // get open connection
            using (var connection = connectionManager.GetConnection())
            {
                // create a command object
                using (var command = new SqlCommand(storedProcedure, connection))
                {
                    // specify the command type
                    command.CommandType = CommandType.StoredProcedure;

                    // add the paramemeters
                    command.Parameters.AddRange(parameters);

                    command.Parameters[returnParameter].Direction = ParameterDirection.Output;

                    // execute the command
                    command.ExecuteNonQuery();

                    // read the return parameter
                    var result = int.Parse(command.Parameters[returnParameter].Value.ToString());

                    // return execute value
                    return result;
                }
            }
        }

        public DataTable ExecuteQuery(string storedProcedure)
        {
            // get open connection
            using (var connection = connectionManager.GetConnection())
            {
                // create a command object
                var command = new SqlCommand(storedProcedure, connection);

                using (command)
                {
                    // specify the command type
                    command.CommandType = CommandType.StoredProcedure;

                    // create a data adapter
                    var adapter = new SqlDataAdapter(command);

                    // create a data table object
                    var table = new DataTable();

                    // fill the data table
                    adapter.Fill(table);

                    // return the table
                    return table;
                }
            }
        }

        public DataTable ExecuteQuery(string storedProcedure, SqlParameter[] parameters)
        {
            // get open connection
            using (var connection = connectionManager.GetConnection())
            {
                // create a command object
                var command = new SqlCommand(storedProcedure, connection);

                using (command)
                {
                    // specify the command type
                    command.CommandType = CommandType.StoredProcedure;

                    // add the parameters
                    command.Parameters.AddRange(parameters);

                    // create a data adapter
                    var adapter = new SqlDataAdapter(command);

                    // create a data table object
                    var table = new DataTable();

                    // fill the data table
                    adapter.Fill(table);

                    // return the table
                    return table;
                }
            }
        }
    }
}
