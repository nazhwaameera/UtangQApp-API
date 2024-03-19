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
	public class FriendshipListDAL : IFriendshipList
	{
		private string GetConnectionString()
		{
			return Helper.GetConnectionString();
			//return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
		}

		public FriendshipList Get(int id)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "Users.ReadFriendshipListByID";
				var param = new
				{
					FriendshipListID = id
				};

				try
				{
					var result = conn.QuerySingleOrDefault<FriendshipList>(strSql, param, commandType: CommandType.StoredProcedure);
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

		public IEnumerable<FriendshipList> GetAll()
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "Users.ReadAllFriendshipList";

				try
				{
					var result = conn.Query<FriendshipList>(strSql, commandType: CommandType.StoredProcedure);
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

		public IEnumerable<FriendshipList> GetByUserID(int userID)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "Users.ReadFriendshipListByUserID";
				var param = new
				{
					UserID = userID
				};

				try
				{
					var result = conn.Query<FriendshipList>(strSql, param, commandType: CommandType.StoredProcedure);
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

		public void HandleFriendRequest(int FriendshipListID, int FriendshipStatusID)
		{
			using(SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "Users.HandleFriendRequest";
				var param = new
				{
					FriendshipListID = FriendshipListID,
					FriendshipStatusID = FriendshipStatusID
				};

				try
				{
					int result = conn.Execute(strSql, param, commandType: CommandType.StoredProcedure);
					if (result != 2)
					{
						throw new ArgumentException("Handle friend request failed..");
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

		public void CreateFriendRequest(int FriendshipID, int SenderUserID, int ReceiverUserID)
		{
			using(SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "Users.CreateFriendRequest";
				var param = new
				{
					FriendshipID = FriendshipID,
					SenderUserID = SenderUserID,
					ReceiverUserID = ReceiverUserID
				};

				try
				{
					int result = conn.Execute(strSql, param, commandType: CommandType.StoredProcedure);
					if (result != 1)
					{
						throw new ArgumentException("Create friend request failed..");
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

		public IEnumerable<FriendshipList> GetPendingFriendRequestsByReceiverUserID(int ReceiverUserID)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "Users.GetPendingFriendRequestsByReceiverUserID";
				var param = new
				{
					ReceiverUserID = ReceiverUserID
				};

				try
				{
					var result = conn.Query<FriendshipList>(strSql, param, commandType: CommandType.StoredProcedure);
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
