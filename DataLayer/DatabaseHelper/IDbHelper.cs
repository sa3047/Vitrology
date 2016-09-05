namespace DataLayer.DatabaseHelper
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;

    /// <summary>
    /// Interface for helper method to execute relational database commands.
    /// </summary>
    public interface IDbHelper
    {
        /// <summary>
        /// Gets the database connection
        /// </summary>
        /// <param name="connectionName">Connection string</param>
        /// <returns>A <see cref="DbConnection"/> instance.</returns>
        DbConnection GetConnection(string connectionName);

        /// <summary>
        /// Executes the Store procedure 
        /// </summary>
        /// <param name="connectionStr">Connection string</param>
        /// <param name="storedProcName">Store procedure name</param>
        /// <param name="procParameters">Parameters to store procedure</param>
        /// <returns>Returns dataset.</returns>
        DataSet ExecuteQuery(string connectionStr, string storedProcName, IDictionary<string, DbParameter> procParameters = null);

        /// <summary>
        /// Executes insert/update/delete commands
        /// </summary>
        /// <param name="connectionStr">Connection string</param>
        /// <param name="storedProcName">Store procedure name</param>
        /// <param name="procParameters">Parameters to store procedure</param>
        /// <returns>Number of affected rows as integer.</returns>
        int ExecuteCommand(string connectionStr, string storedProcName, IDictionary<string, DbParameter> procParameters = null);
    }
}
