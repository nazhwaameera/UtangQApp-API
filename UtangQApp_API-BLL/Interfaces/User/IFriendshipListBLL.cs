using UtangQApp_API_BLL.DTOs.Users;

namespace UtangQApp_API_BLL.Interfaces.User
{
	public interface IFriendshipListBLL : IHelperBLL<FriendshipListDTO>
	{
		Task<IEnumerable<FriendshipListDTO>> GetByUserID(int userID);
		Task<IEnumerable<FriendshipListDTO>> GetPendingFriendRequestsByReceiverUserID(int ReceiverUserID);
		Task<bool> CreateFriendRequest(int FriendshipID, int SenderUserID, int ReceiverUserID);
		Task<bool> HandleFriendRequest(int FriendshipListID, int FriendshipStatusID);	
	}
}
