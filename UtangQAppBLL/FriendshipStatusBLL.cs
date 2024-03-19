using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBLL.DTOs.User;
using UtangQAppBLL.Interfaces.User;
using UtangQAppBO;
using UtangQAppDAL;
using UtangQAppDAL.Interfaces;
using static Dapper.SqlMapper;

namespace UtangQAppBLL
{
	public class FriendshipStatusBLL : IFriendshipStatusBLL
	{
		private readonly IFriendshipStatus _friendshipStatusDAL;
		public FriendshipStatusBLL()
		{
			_friendshipStatusDAL = new FriendshipStatusDAL();
		}

		public FriendshipStatusDTO Get(int id)
		{
			FriendshipStatusDTO friendshipStatusDTO = new FriendshipStatusDTO();
			try
			{
				var friendshipStatus = _friendshipStatusDAL.Get(id);
				friendshipStatusDTO.FriendshipStatusID = friendshipStatus.FriendshipStatusID;
				friendshipStatusDTO.FriendshipStatusDescription = friendshipStatus.FriendshipStatusDescription;
				return friendshipStatusDTO;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public IEnumerable<FriendshipStatusDTO> GetAll()
		{
			List<FriendshipStatusDTO> friendshipStatusDTOs = new List<FriendshipStatusDTO>();
			try
			{
				var friendshipStatuses = _friendshipStatusDAL.GetAll();
				foreach (var friendshipStatus in friendshipStatuses)
				{
					FriendshipStatusDTO friendshipStatusDTO = new FriendshipStatusDTO();
					friendshipStatusDTO.FriendshipStatusID = friendshipStatus.FriendshipStatusID;
					friendshipStatusDTO.FriendshipStatusDescription = friendshipStatus.FriendshipStatusDescription;
					friendshipStatusDTOs.Add(friendshipStatusDTO);
				}
				return friendshipStatusDTOs;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
