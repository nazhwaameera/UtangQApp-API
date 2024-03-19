using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBLL.DTOs.User;
using UtangQAppBO;

namespace UtangQAppBLL.Interfaces.User
{
	public interface IFriendshipListBLL : IHelperBLL<FriendshipListDTO>
	{
		IEnumerable<FriendshipListDTO> GetByUserID(int userID);
		IEnumerable<FriendshipListDTO> GetPendingFriendRequestsByReceiverUserID(int ReceiverUserID);
		void CreateFriendRequest(int FriendshipID, int SenderUserID, int ReceiverUserID);
		void HandleFriendRequest(int FriendshipListID, int FriendshipStatusID);	
	}
}
