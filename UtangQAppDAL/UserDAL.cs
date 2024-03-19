using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using UtangQAppBO;
using UtangQAppDAL.Interfaces;

namespace UtangQAppDAL
{
    public class UserDAL : IUser
    {
        private string GetConnectionString()
        {
            return Helper.GetConnectionString();
            //return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }
        public void Create(User entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Users.CreateUser";
                var param = new
                {
                    Username = entity.Username,
                    UserPassword = entity.UserPassword,
                    UserEmail = entity.UserEmail,
                    UserFullName = entity.UserFullName,
                    UserPhoneNumber = entity.UserPhoneNumber
                };

                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Create user data failed..");
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException($"{sqlEx.InnerException.Message} - {sqlEx.Number}");
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Users.DeleteUser";
                var param = new
                {
                    UserID = id
                };

                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Delete user data failed..");
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException($"{sqlEx.InnerException.Message} - {sqlEx.Number}");
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }

        public User Get(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Users.ReadUserbyID";
                var param = new { UserID = id };
                var result = conn.QuerySingleOrDefault<User>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Users.ReadAllUsers";
                var result = conn.Query<User>(strSql, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public User LoginUser(string Username, string UserPassword)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Users.LoginUser";
                var param = new 
                { 
                    Username = Username,
                    UserPassword = UserPassword
                };
                var result = conn.QuerySingleOrDefault<User>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public void Update(User entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Users.UpdateUser";
                var param = new
                {
                    UserID = entity.UserID,
                    Username = entity.Username,
                    UserPassword = entity.UserPassword,
                    UserEmail = entity.UserEmail,
                    UserFullName = entity.UserFullName,
                    UserPhoneNumber = entity.UserPhoneNumber,
                    IsLocked = entity.IsLocked
    };

                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Update user data failed..");
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException($"{sqlEx.InnerException.Message} - {sqlEx.Number}");
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }

        public User GetByUsername(string Username)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "SELECT * FROM Users.Users WHERE Username = @Username";
                var param = new { Username = Username };
                var result = conn.QuerySingleOrDefault<User>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

		public IEnumerable<User> GetFriends(int FriendshipID)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "Users.GetFriends";
                var param = new { FriendshipID = FriendshipID };
				var result = conn.Query<User>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
				return result;
			}
		}

		public IEnumerable<User> GetNonFriends(int FriendshipID)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "Users.GetNonFriends";
				var param = new { FriendshipID = FriendshipID };
				var result = conn.Query<User>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
				return result;
			}
		}
	}
}
