using UtangQApp_API_BLL.DTOs.Users;

namespace UtangQApp_API_BLL.Interfaces.User
{
	public interface IFriendshipBLL : IHelperBLL<FriendshipDTO>
	{
		Task<FriendshipDTO> GetByUserID(int userID);
        Task<bool> CreateFriendship(int UserID);
	}
}
