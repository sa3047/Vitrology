namespace VitrologyWebApp_V1.Controllers
{
    using System.Configuration;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.Web.Http;
    using DataLayer;
    using DomainClasses;
    using VitrologyWebApp_V1.Helpers;
    using System;

    /// <summary>
    /// Handles http requests for User
    /// </summary>
    public class UserController : ApiController
    {
        /// <summary>
        /// Registers a User
        /// </summary>
        /// <param name="user">A User </param>
        /// <returns>Serialized User object</returns>
        [HttpPost]
        public string RegisterUser([FromBody] User user)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["UserDBConnection"].ConnectionString;
                UserDAL userDAL = new UserDAL()
                {
                    ConnectionString = connStr,
                    StoreProcName = "Sp_RegisterUser"
                };

                var result = userDAL.RegisterUser(user);
                if(result > 0)
                {
                    return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new ApiResult() { Success = true, Message = "User Registerd." });
                }
                else
                {
                    return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new ApiResult() { Success = true, Message = "User not Registerd." });
                }
                
            }
            catch (System.Exception ex)
            {
                // Todo : Handle proper Httpstatus code and return it.
                Debug.Write(ex.Message);
                return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new ApiResult() { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Authenticates a User
        /// </summary>
        /// <param name="user">A User</param>
        /// <returns>A serialized Result</returns>
        [HttpPost]
        public string AuthenticateUser([FromBody] User user)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["UserDBConnection"].ConnectionString;
                UserDAL userDAL = new UserDAL()
                {
                    ConnectionString = connStr,
                    StoreProcName = "Sp_GetUser"
                };

                var result = userDAL.GetUser(user.Email, user.Password);

                if(result.Tables[0].Rows.Count > 0)
                {
                    var userResponse = result.Tables[0].AsEnumerable().Select(r =>
                                            new User()
                                            {
                                                Id = r.Field<int>("Id"),
                                                FirstName = r.Field<string>("FirstName"),
                                                LastName = r.Field<string>("LastName"),
                                                Email = r.Field<string>("Email"),
                                                Password = r.Field<string>("LastName"),
                                            }).ToList().First();

                    return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(userResponse);
                }
                else
                {
                    throw new Exception("User not Register OR Please enter correct login credentials.");
                }
                
            }
            catch (System.Exception ex)
            {
                // Todo : Handle proper Httpstatus code and return it.
                Debug.Write(ex.Message);
                return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new ApiResult() { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Get all users.
        /// </summary>
        /// <returns>A serialized collection user</returns>
        [HttpGet]
        public string GetAllUser()
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["UserDBConnection"].ConnectionString;
                UserDAL userDAL = new UserDAL()
                {
                    ConnectionString = connStr,
                    StoreProcName = "Sp_GetUsers"
                };
                var result = userDAL.GetUsers();

                var userResponse = result.Tables[0].AsEnumerable().Select(r =>
                                            new User()
                                            {
                                                Id = r.Field<int>("Id"),
                                                FirstName = r.Field<string>("FirstName"),
                                                LastName = r.Field<string>("LastName"),
                                                Email = r.Field<string>("Email"),
                                                Password = r.Field<string>("LastName"),
                                            }).ToList();

                return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(userResponse);
            }
            catch (System.Exception ex)
            {
                // Todo : Handle proper Httpstatus code and return it.
                Debug.Write(ex.Message);
                return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new ApiResult() { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Deletes a User
        /// </summary>
        /// <param name="id">A user Id</param>
        /// <returns>A serialized result</returns>
        [HttpDelete]
        public string DeleteUser(int id)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["UserDBConnection"].ConnectionString;
                UserDAL userDAL = new UserDAL()
                {
                    ConnectionString = connStr,
                    StoreProcName = "Sp_DeleteUsers"
                };

                var result = userDAL.DeleteUser(id);

                if (result > 0)
                {
                    return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new ApiResult() { Success = true, Message = "User deleted." });
                }

                return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new ApiResult() { Success = false, Message = "User not deleted." });
            }
            catch (System.Exception ex)
            {
                // Todo : Handle proper Httpstatus code and return it.
                Debug.Write(ex.Message);
                return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new ApiResult() { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Adds a address
        /// </summary>
        /// <param name="address">A address object.</param>
        /// <returns>A serialized result</returns>
        [HttpPost]
        public string AddAddress(Address address)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["UserDBConnection"].ConnectionString;
                UserDAL userDAL = new UserDAL()
                {
                    ConnectionString = connStr,
                    StoreProcName = "Sp_AddUserAddress"
                };

                var result = userDAL.AddAddress(address);

                return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new ApiResult() { Success = true, Message = "Address saved." });
            }
            catch (System.Exception ex)
            {
                // Todo : Handle proper Httpstatus code and return it.
                Debug.Write(ex.Message);
                return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new ApiResult() { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets a address
        /// </summary>
        /// <param name="id">A user id.</param>
        /// <returns>A serialized Address</returns>
        [HttpGet]
        public string GetAddress(int id)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["UserDBConnection"].ConnectionString;
                UserDAL userDAL = new UserDAL()
                {
                    ConnectionString = connStr,
                    StoreProcName = "Sp_GetUserAddress"
                };

                var result = userDAL.GetAddress(id);

                var userResponse = result.Tables[0].AsEnumerable().Select(r =>
                                            new Address()
                                            {
                                                Id = r.Field<int>("Id"),
                                                Street = r.Field<string>("Street"),
                                                State = r.Field<string>("State"),
                                                PinCode = r.Field<string>("PinCode"),
                                                Country = r.Field<string>("Country"),
                                                UserId = r.Field<int>("UserId")
                                            }).ToList().First();

                return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(userResponse);
            }
            catch (System.Exception ex)
            {
                // Todo : Handle proper Httpstatus code and return it.
                Debug.Write(ex.Message);
                return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new ApiResult() { Success = false, Message = ex.Message });
            }
        }
    }
}
