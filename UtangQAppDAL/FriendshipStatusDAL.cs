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
	public class FriendshipStatusDAL : IFriendshipStatus
	{
		private string GetConnectionString()
		{
			return Helper.GetConnectionString();
			//return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
		}
		public FriendshipStatus Get(int id)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "Users.ReadFriendshipStatusByID";
				var param = new
				{
					FriendshipStatusID = id
				};

				try
				{
					var result = conn.QuerySingleOrDefault<FriendshipStatus>(strSql, param, commandType: CommandType.StoredProcedure);
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

		public IEnumerable<FriendshipStatus> GetAll()
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "Users.ReadAllFriendshipStatuses";

				try
				{
					var result = conn.Query<FriendshipStatus>(strSql, commandType: CommandType.StoredProcedure);
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
	}
}
