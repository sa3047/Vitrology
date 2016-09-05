namespace DataLayer
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using DataLayer.DatabaseHelper;
    using DomainClasses;

    /// <summary>
    /// Manages a user data access.
    /// </summary>
    public class UserDAL : BaseDAL
    {
        /// <summary>
        /// Registers a user 
        /// </summary>
        /// <param name="user">A reference to <see cref="User"/>class. </param>
        /// <returns>Affected rows.</returns>
        public int RegisterUser(User user)
        {
            int rc = 0;

            Dictionary<string, DbParameter> cmdParameters = new Dictionary<string, DbParameter>();
            cmdParameters["FirstName"] = new SqlParameter("@FirstName", user.FirstName) { Direction = ParameterDirection.Input };
            cmdParameters["LastName"] = new SqlParameter("@LastName", user.LastName) { Direction = ParameterDirection.Input };
            cmdParameters["Email"] = new SqlParameter("@Email", user.Email) { Direction = ParameterDirection.Input };
            cmdParameters["Password"] = new SqlParameter("@Password", user.Password) { Direction = ParameterDirection.Input };
            cmdParameters["RecordCount"] = new SqlParameter("@RecordCount", 0) { Direction = ParameterDirection.Output };

            IDbHelper sqlDbHelper = new SqlDbHelper();
            rc = sqlDbHelper.ExecuteCommand(this.ConnectionString, this.StoreProcName, cmdParameters);
            return rc;
        }

        /// <summary>
        /// Gets a user
        /// </summary>
        /// <param name="email">Email address of user</param>
        /// <param name="password">Users Password </param>
        /// <returns>A user.</returns>
        public DataSet GetUser(string email, string password)
        {
            DataSet ds = null;
            Dictionary<string, DbParameter> cmdParameters = new Dictionary<string, DbParameter>();
            cmdParameters["Email"] = new SqlParameter("@Email", email) { Direction = ParameterDirection.Input };
            cmdParameters["Password"] = new SqlParameter("@Password", password) { Direction = ParameterDirection.Input };
            cmdParameters["RecordCount"] = new SqlParameter("@RecordCount", 0) { Direction = ParameterDirection.Output };

            IDbHelper sqlDbHelper = new SqlDbHelper();
            ds = sqlDbHelper.ExecuteQuery(this.ConnectionString, this.StoreProcName, cmdParameters);
            return ds;
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>A collection of users.</returns>
        public DataSet GetUsers()
        {
            DataSet ds = null;
            Dictionary<string, DbParameter> cmdParameters = new Dictionary<string, DbParameter>();
            cmdParameters["RecordCount"] = new SqlParameter("@RecordCount", 0) { Direction = ParameterDirection.Output };

            IDbHelper sqlDbHelper = new SqlDbHelper();
            ds = sqlDbHelper.ExecuteQuery(this.ConnectionString, this.StoreProcName, cmdParameters);
            return ds;
        }

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <param name="id">User id.</param>
        /// <returns>Affected rows.</returns>
        public int DeleteUser(int id)
        {
            int rc = 0;

            Dictionary<string, DbParameter> cmdParameters = new Dictionary<string, DbParameter>();
            cmdParameters["Id"] = new SqlParameter("@Id", id) { Direction = ParameterDirection.Input };
            cmdParameters["RecordCount"] = new SqlParameter("@RecordCount", 0) { Direction = ParameterDirection.Output };

            IDbHelper sqlDbHelper = new SqlDbHelper();
            rc = sqlDbHelper.ExecuteCommand(this.ConnectionString, this.StoreProcName, cmdParameters);
            return rc;
        }

        /// <summary>
        /// Adds a address 
        /// </summary>
        /// <param name="address">A address reference</param>
        /// <returns>Affected rows.</returns>
        public int AddAddress(Address address)
        {
            int rc = 0;

            Dictionary<string, DbParameter> cmdParameters = new Dictionary<string, DbParameter>();
            cmdParameters["Street"] = new SqlParameter("@Street", address.Street) { Direction = ParameterDirection.Input };
            cmdParameters["State"] = new SqlParameter("@State", address.State) { Direction = ParameterDirection.Input };
            cmdParameters["PinCode"] = new SqlParameter("@PinCode", address.PinCode) { Direction = ParameterDirection.Input };
            cmdParameters["Country"] = new SqlParameter("@Country", address.Country) { Direction = ParameterDirection.Input };
            cmdParameters["UserId"] = new SqlParameter("@UserId", address.UserId) { Direction = ParameterDirection.Input };
            cmdParameters["RecordCount"] = new SqlParameter("@RecordCount", 0) { Direction = ParameterDirection.Output };

            IDbHelper sqlDbHelper = new SqlDbHelper();
            rc = sqlDbHelper.ExecuteCommand(this.ConnectionString, this.StoreProcName, cmdParameters);
            return rc;
        }

        /// <summary>
        /// Gets a user address
        /// </summary>
        /// <param name="id">User id.</param>
        /// <returns>A Address dataset.</returns>
        public DataSet GetAddress(int id)
        {
            DataSet ds = null;
            Dictionary<string, DbParameter> cmdParameters = new Dictionary<string, DbParameter>();
            cmdParameters["UserId"] = new SqlParameter("@UserId", id) { Direction = ParameterDirection.Input };
            cmdParameters["RecordCount"] = new SqlParameter("@RecordCount", 0) { Direction = ParameterDirection.Output };

            IDbHelper sqlDbHelper = new SqlDbHelper();
            ds = sqlDbHelper.ExecuteQuery(this.ConnectionString, this.StoreProcName, cmdParameters);
            return ds;
        }
    }
}
