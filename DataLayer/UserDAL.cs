namespace DataLayer
{
    using DataLayer.DatabaseHelper;
    using DomainClasses;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;

    public class UserDAL : BaseDAL
    {
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

        public DataSet GetUsers()
        {
            DataSet ds = null;
            Dictionary<string, DbParameter> cmdParameters = new Dictionary<string, DbParameter>();
            cmdParameters["RecordCount"] = new SqlParameter("@RecordCount", 0) { Direction = ParameterDirection.Output };

            IDbHelper sqlDbHelper = new SqlDbHelper();
            ds = sqlDbHelper.ExecuteQuery(this.ConnectionString, this.StoreProcName, cmdParameters);
            return ds;
        }

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
