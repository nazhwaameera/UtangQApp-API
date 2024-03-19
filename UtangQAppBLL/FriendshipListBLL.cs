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
	public class FriendshipListBLL : IFriendshipListBLL
	{
		private readonly IFriendshipList _friendshipListDAL;
		public FriendshipListBLL()
		{
			_friendshipListDAL = new FriendshipListDAL();
		}

		public void CreateFriendRequest(int FriendshipID, int SenderUserID, int ReceiverUserID)
		{
			try
			{
				_friendshipListDAL.CreateFriendRequest(FriendshipID, SenderUserID, ReceiverUserID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public FriendshipListDTO Get(int id)
		{
			FriendshipListDTO friendshipListDTO = new FriendshipListDTO();
			try
			{
				var friendshipList = _friendshipListDAL.Get(id);
				friendshipListDTO.FriendshipListID = friendshipList.FriendshipListID;
				friendshipListDTO.FriendshipID = friendshipList.FriendshipID;
				friendshipListDTO.SenderUserID = friendshipList.SenderUserID;
				friendshipListDTO.ReceiverUserID = friendshipList.ReceiverUserID;
				friendshipListDTO.FriendshipStatusID = friendshipList.FriendshipStatusID;
				return friendshipListDTO;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public IEnumerable<FriendshipListDTO> GetAll()
		{
			List<FriendshipListDTO> friendshipListDTOs = new List<FriendshipListDTO>();
			try
			{
				var friendshipLists = _friendshipListDAL.GetAll();
				foreach (var friendshipList in friendshipLists)
				{
					FriendshipListDTO friendshipListDTO = new FriendshipListDTO();
					friendshipListDTO.FriendshipListID = friendshipList.FriendshipListID;
					friendshipListDTO.FriendshipID = friendshipList.FriendshipID;
					friendshipListDTO.SenderUserID = friendshipList.SenderUserID;
					friendshipListDTO.ReceiverUserID = friendshipList.ReceiverUserID;
					friendshipListDTO.FriendshipStatusID = friendshipList.FriendshipStatusID;
					friendshipListDTOs.Add(friendshipListDTO);
				}
				return friendshipListDTOs;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public IEnumerable<FriendshipListDTO> GetByUserID(int userID)
		{
			List<FriendshipListDTO> friendshipListDTOs = new List<FriendshipListDTO>();
			try
			{
				var friendshipLists = _friendshipListDAL.GetByUserID(userID);
				foreach (var friendshipList in friendshipLists)
				{
					FriendshipListDTO friendshipListDTO = new FriendshipListDTO();
					friendshipListDTO.FriendshipListID = friendshipList.FriendshipListID;
					friendshipListDTO.FriendshipID = friendshipList.FriendshipID;
					friendshipListDTO.SenderUserID = friendshipList.SenderUserID;
					friendshipListDTO.ReceiverUserID = friendshipList.ReceiverUserID;
					friendshipListDTO.FriendshipStatusID = friendshipList.FriendshipStatusID;
					friendshipListDTOs.Add(friendshipListDTO);
				}
				return friendshipListDTOs;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public IEnumerable<FriendshipListDTO> GetPendingFriendRequestsByReceiverUserID(int ReceiverUserID)
		{

			List<FriendshipListDTO> friendshipListDTOs = new List<FriendshipListDTO>();
			try
			{
				var friendshipLists = _friendshipListDAL.GetPendingFriendRequestsByReceiverUserID(ReceiverUserID);
				foreach (var friendshipList in friendshipLists)
				{
					FriendshipListDTO friendshipListDTO = new FriendshipListDTO();
					friendshipListDTO.FriendshipListID = friendshipList.FriendshipListID;
					friendshipListDTO.FriendshipID = friendshipList.FriendshipID;
					friendshipListDTO.SenderUserID = friendshipList.SenderUserID;
					friendshipListDTO.ReceiverUserID = friendshipList.ReceiverUserID;
					friendshipListDTO.FriendshipStatusID = friendshipList.FriendshipStatusID;
					friendshipListDTOs.Add(friendshipListDTO);
				}
				return friendshipListDTOs;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public void HandleFriendRequest(int FriendshipListID, int FriendshipStatusID)
		{
			try
			{
				_friendshipListDAL.HandleFriendRequest(FriendshipListID, FriendshipStatusID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
