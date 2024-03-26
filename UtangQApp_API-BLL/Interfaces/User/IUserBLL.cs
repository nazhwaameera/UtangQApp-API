using UtangQApp_API_BLL.DTOs.Users;

namespace UtangQApp_API_BLL.Interfaces.User
{
    public interface IUserBLL : ICrudBLL<UserDTO>
    {
        Task<bool> Create(UserCreateDTO entity);
        Task<UserDTO> LoginUser(string Username, string UserPassword);
        Task<UserDTO> GetByUsername(string Username);
		Task<IEnumerable<UserDTO>> GetFriends(int FriendshipID);
		Task<IEnumerable<UserDTO>> GetNonFriends(int FriendshipID);
	}
}
