using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBO;
using UtangQAppDAL.Interfaces;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using static Dapper.SqlMapper;
using System.Configuration;

namespace UtangQAppDAL
{
	public class FriendshipDAL : IFriendship
	{
		private string GetConnectionString()
		{
			return Helper.GetConnectionString();
			//return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
		}
		public Friendship Get(int id)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "Users.ReadFriendshipByID";
				var param = new
				{
					FriendshipListID = id
				};

				try
				{
					var result = conn.QuerySingleOrDefault<Friendship>(strSql, param, commandType: CommandType.StoredProcedure);
					return result;
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

		public IEnumerable<Friendship> GetAll()
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "Users.ReadAllFriendships";

				try
				{
					var result = conn.Query<Friendship>(strSql, commandType: CommandType.StoredProcedure);
					return result;
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

		public Friendship GetByUserID(int userID)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "Users.ReadFriendshipByUserID";
				var param = new
				{
					UserID = userID
				};

				try
				{
					var result = conn.QuerySingleOrDefault<Friendship>(strSql, param, commandType: CommandType.StoredProcedure);
					return result;
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

		public void CreateFriendship(int UserID)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "Users.CreateFriendship";
				var param = new
				{
					UserID = UserID,
				};

				try
				{
					int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
					if (result != 1)
					{
						throw new ArgumentException("Create friendship data failed..");
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
	}
}
