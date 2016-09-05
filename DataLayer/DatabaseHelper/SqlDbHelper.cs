namespace DataLayer.DatabaseHelper
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;

    /// <summary>
    /// Manages SQL database operations.
    /// </summary>
    public class SqlDbHelper : IDbHelper
    {
        /// <summary>
        /// Gets a connection string for relational database.
        /// </summary>
        /// <param name="connectionStr"> Connection string</param>
        /// <returns>A Connection instance.</returns>
        public DbConnection GetConnection(string connectionStr)
        {
            string cnstr = connectionStr;
            SqlConnection cn = new SqlConnection(cnstr);
            cn.Open();
            return cn;
        }

        /// <summary>
        /// Executes the Store procedure 
        /// </summary>
        /// <param name="connectionStr">Connection string</param>
        /// <param name="storedProcName">Store procedure name</param>
        /// <param name="procParameters">Parameters to store procedure</param>
        /// <returns>Returns dataset.</returns>
        public DataSet ExecuteQuery(string connectionStr, string storedProcName, IDictionary<string, DbParameter> procParameters = null)
        {
            this.CheckConnectionSettingsParameter(connectionStr, storedProcName);

            DataSet ds = new DataSet();
            using (SqlConnection cn = this.GetConnection(connectionStr) as SqlConnection)
            {
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcName;
                    //// assign parameters passed in to the command
                    if (procParameters != null)
                    {
                        foreach (var procParameter in procParameters)
                        {
                            cmd.Parameters.Add(procParameter.Value);
                        }
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }
            }

            return ds;
        }

        /// <summary>
        /// Executes insert/update/delete commands
        /// </summary>
        /// <param name="connectionStr">Connection string</param>
        /// <param name="storedProcName">Store procedure name</param>
        /// <param name="procParameters">Parameters to store procedure</param>
        /// <returns>Number of affected rows as integer.</returns>
        public int ExecuteCommand(string connectionStr, string storedProcName, IDictionary<string, DbParameter> procParameters = null)
        {
            this.CheckConnectionSettingsParameter(connectionStr, storedProcName);

            int rc = 0;
            using (SqlConnection cn = this.GetConnection(connectionStr) as SqlConnection)
            {
                SqlTransaction transaction;

                // Start a local transaction.
                transaction = cn.BeginTransaction(IsolationLevel.ReadCommitted);

                //// create a SQL command to execute the stored procedure
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcName;
                    cmd.Transaction = transaction;

                    //// assign parameters passed in to the command
                    if (procParameters != null)
                    {
                        foreach (var procParameter in procParameters)
                        {
                            cmd.Parameters.Add(procParameter.Value);
                        }
                    }

                    try
                    {
                        rc = cmd.ExecuteNonQuery();
                        //// Commits the transaction
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("  Message: {0}", ex.Message);

                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception ex2)
                        {
                            // This catch block will handle any errors that may have occurred
                            // on the server that would cause the rollback to fail, such as
                            // a closed connection.
                            // TODO : Log into file
                            Console.WriteLine("  Message: {0}", ex2.Message);
                        }
                    }
                }
            }

            return rc;
        }

        /// <summary>
        /// Checks connection and store procedure names are not null
        /// </summary>
        /// <param name="connectionStr">Connection string</param>
        /// <param name="storedProcName">Store procedure name</param>
        private void CheckConnectionSettingsParameter(string connectionStr, string storedProcName)
        {
            if (string.IsNullOrEmpty(connectionStr))
            {
                throw new ArgumentNullException("Connection string can not be null or empty");
            }

            if (string.IsNullOrEmpty(storedProcName))
            {
                throw new ArgumentNullException("Store procedure name can not be null or empty");
            }
        }
    }
}
