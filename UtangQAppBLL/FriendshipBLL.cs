using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBLL.DTOs.User;
using UtangQAppBLL.Interfaces.User;
using UtangQAppDAL;
using UtangQAppDAL.Interfaces;

namespace UtangQAppBLL
{
	public class FriendshipBLL : IFriendshipBLL
	{
		private readonly IFriendship _friendshipDAL;
		public FriendshipBLL()
		{
			_friendshipDAL = new FriendshipDAL();
		}

		public void CreateFriendship(int UserID)
		{
			try
			{
				_friendshipDAL.CreateFriendship(UserID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public FriendshipDTO Get(int id)
		{
			FriendshipDTO friendshipDTO = new FriendshipDTO();
			try
			{
				var friendship = _friendshipDAL.Get(id);
				friendshipDTO.FriendshipID = friendship.FriendshipID;
				friendshipDTO.UserID = friendship.UserID;
				return friendshipDTO;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public IEnumerable<FriendshipDTO> GetAll()
		{
			List<FriendshipDTO> friendshipDTOs = new List<FriendshipDTO>();
			try
			{
				var friendships = _friendshipDAL.GetAll();
				foreach (var friendship in friendships)
				{
					FriendshipDTO friendshipDTO = new FriendshipDTO();
					friendshipDTO.FriendshipID = friendship.FriendshipID;
					friendshipDTO.UserID = friendship.UserID;
					friendshipDTOs.Add(friendshipDTO);
				}
				return friendshipDTOs;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public FriendshipDTO GetByUserID(int userID)
		{
			FriendshipDTO friendshipDTO = new FriendshipDTO();
			try
			{
				var friendship = _friendshipDAL.GetByUserID(userID);
				friendshipDTO.FriendshipID = friendship.FriendshipID;
				friendshipDTO.UserID = friendship.UserID;
				return friendshipDTO;
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}
