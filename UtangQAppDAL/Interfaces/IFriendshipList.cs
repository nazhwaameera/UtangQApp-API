using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBO;

namespace UtangQAppDAL.Interfaces
{
	public interface IFriendshipList : IHelper<FriendshipList>
	{
		IEnumerable<FriendshipList> GetByUserID(int userID);
		IEnumerable<FriendshipList> GetPendingFriendRequestsByReceiverUserID(int ReceiverUserID);
		void CreateFriendRequest(int FriendshipID, int SenderUserID, int ReceiverUserID);
		void HandleFriendRequest(int FriendshipListID, int FriendshipStatusID);
	}
}
