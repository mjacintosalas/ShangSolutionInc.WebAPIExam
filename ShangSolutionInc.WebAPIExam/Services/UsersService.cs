using ShangSolutionInc.WebAPIExam.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ShangSolutionInc.WebAPIExam.Services
{
    public class UsersService
    {
        private string _client = string.Empty;
        private string _connectionStr = string.Empty;
        private const string SP_GetUsers = "GetUsers_sp";
        private const string SP_AddUser = "AddUser_sp";
        private const string SP_UpdateUser = "UpdateUser_sp";
        private const string SP_DeleteUser = "DeleteUser_sp";

        public UsersService(string client)
        {
            _client = client;
            //Data Source="localhost, 1433";Initial Catalog=ClientA;User ID=sa
            _connectionStr = string.Format(@"Data Source=""ms-sql-server, 1433"";Initial Catalog=ClientA;User ID=sa;Password=yourStrong(!)Password", _client);
            //_connectionStr = string.Format("Data Source=DESKTOP-JEPEC86;Initial Catalog={0};Integrated Security=True", _client);
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            try
            {
                using (SqlConnection sc = new SqlConnection(_connectionStr))
                {
                    SqlCommand sqlCommand = new SqlCommand(SP_GetUsers, sc);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sc.Open();

                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            User user = new User()
                            {
                                UserId = sdr.GetInt32(0),
                                Username = sdr.GetString(1),
                                Firstname = sdr.GetString(2),
                                Lastname = sdr.GetString(3),
                                State = sdr.GetString(4)
                            };
                            users.Add(user);
                        }
                    }
                }

                return users;
            }
            catch (Exception)
            {

                return users;
            }
            
        }
        public string GetUserss()
        {
            List<User> users = new List<User>();
            try
            {
                using (SqlConnection sc = new SqlConnection(_connectionStr))
                {
                    SqlCommand sqlCommand = new SqlCommand(SP_GetUsers, sc);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sc.Open();

                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            User user = new User()
                            {
                                UserId = sdr.GetInt32(0),
                                Username = sdr.GetString(1),
                                Firstname = sdr.GetString(2),
                                Lastname = sdr.GetString(3),
                                State = sdr.GetString(4)
                            };
                            users.Add(user);
                        }
                    }
                }

                return users.Count.ToString() + " connstr: " + _connectionStr;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
        public bool AddUser(int userId, string username, string firstname, string lastname, string state)
        {
            try
            {
                bool result = false;

                using (SqlConnection sc = new SqlConnection(_connectionStr))
                {
                    SqlCommand sqlCommand = new SqlCommand(SP_AddUser, sc);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sc.Open();

                    SqlParameter sqlParameterUserId = sqlCommand.Parameters.Add("@UserId", SqlDbType.Int);
                    sqlParameterUserId.Direction = ParameterDirection.Input;
                    sqlParameterUserId.Value = userId;

                    SqlParameter sqlParameterUsername = sqlCommand.Parameters.Add("@Username", SqlDbType.NVarChar);
                    sqlParameterUsername.Direction = ParameterDirection.Input;
                    sqlParameterUsername.Value = username;

                    SqlParameter sqlParameterFirstname = sqlCommand.Parameters.Add("@Firstname", SqlDbType.NVarChar);
                    sqlParameterFirstname.Direction = ParameterDirection.Input;
                    sqlParameterFirstname.Value = firstname;

                    SqlParameter sqlParameterLastname = sqlCommand.Parameters.Add("@Lastname", SqlDbType.NVarChar);
                    sqlParameterLastname.Direction = ParameterDirection.Input;
                    sqlParameterLastname.Value = lastname;

                    SqlParameter sqlParameterState = sqlCommand.Parameters.Add("@State", SqlDbType.NVarChar);
                    sqlParameterState.Direction = ParameterDirection.Input;
                    sqlParameterState.Value = state;
                    ;
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {

                        while (sdr.Read())
                        {
                            result = Convert.ToBoolean(sdr.GetInt32(0));
                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {

                return false;
            }
            
        }

        public bool UpdateUser(int userId, string username, string firstname, string lastname, string state)
        {
            try
            {
                bool result = false;

                using (SqlConnection sc = new SqlConnection(_connectionStr))
                {
                    SqlCommand sqlCommand = new SqlCommand(SP_UpdateUser, sc);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sc.Open();

                    SqlParameter sqlParameterUserId = sqlCommand.Parameters.Add("@UserId", SqlDbType.Int);
                    sqlParameterUserId.Direction = ParameterDirection.Input;
                    sqlParameterUserId.Value = userId;

                    SqlParameter sqlParameterUsername = sqlCommand.Parameters.Add("@Username", SqlDbType.NVarChar);
                    sqlParameterUsername.Direction = ParameterDirection.Input;
                    sqlParameterUsername.Value = username;

                    SqlParameter sqlParameterFirstname = sqlCommand.Parameters.Add("@Firstname", SqlDbType.NVarChar);
                    sqlParameterFirstname.Direction = ParameterDirection.Input;
                    sqlParameterFirstname.Value = firstname;

                    SqlParameter sqlParameterLastname = sqlCommand.Parameters.Add("@Lastname", SqlDbType.NVarChar);
                    sqlParameterLastname.Direction = ParameterDirection.Input;
                    sqlParameterLastname.Value = lastname;

                    SqlParameter sqlParameterState = sqlCommand.Parameters.Add("@State", SqlDbType.NVarChar);
                    sqlParameterState.Direction = ParameterDirection.Input;
                    sqlParameterState.Value = state;
                    ;
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {

                        while (sdr.Read())
                        {
                            result = Convert.ToBoolean(sdr.GetInt32(0));
                        }
                    }
                }

                return result;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public bool DeleteUser(int userId)
        {
            bool result = false;

            using (SqlConnection sc = new SqlConnection(_connectionStr))
            {
                SqlCommand sqlCommand = new SqlCommand(SP_DeleteUser, sc);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sc.Open();

                SqlParameter sqlParameterUserId = sqlCommand.Parameters.Add("@UserId", SqlDbType.Int);
                sqlParameterUserId.Direction = ParameterDirection.Input;
                sqlParameterUserId.Value = userId;

                using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                {

                    while (sdr.Read())
                    {
                        result = Convert.ToBoolean(sdr.GetInt32(0));
                    }
                }
            }

            return result;
        }
    }
}
