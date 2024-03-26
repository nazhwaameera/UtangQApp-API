using AutoMapper;
using UtangQApp_API_BLL.DTOs.Users;
using UtangQApp_API_BLL.Interfaces.User;
using UtangQApp_Data.Interfaces.Users;
using UtangQApp_Domain.Users;

namespace UtangQApp_API_BLL.BLLs.Users
{
    public class UserBLL : IUserBLL
    {
        private readonly IUser _userData;
        private readonly IMapper _mapper;

        public UserBLL(IUser userData, IMapper mapper)
        {
            _userData = userData;
            _mapper = mapper;
        }

        public async Task<bool> Create(UserCreateDTO entity)
        {
            var userDomain = _mapper.Map<User>(entity);
            var result = await _userData.Create(userDomain);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _userData.Delete(id);
            return result;
        }

        public async Task<UserDTO> Get(int id)
        {
            var user = await _userData.Get(id);
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var users = await _userData.GetAll();
            var usersDTO = _mapper.Map<IEnumerable<UserDTO>>(users);
            return usersDTO;
        }

        public async Task<UserDTO> GetByUsername(string Username)
        {
            var user = await _userData.GetByUsername(Username);
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public async Task<IEnumerable<UserDTO>> GetFriends(int FriendshipID)
        {
            var friends = await _userData.GetFriends(FriendshipID);
            var friendsDTO = _mapper.Map<IEnumerable<UserDTO>>(friends);
            return friendsDTO;
        }

        public async Task<IEnumerable<UserDTO>> GetNonFriends(int FriendshipID)
        {
            var nonFriends = await _userData.GetNonFriends(FriendshipID);
            var nonFriendsDTO = _mapper.Map<IEnumerable<UserDTO>>(nonFriends);
            return nonFriendsDTO;
        }

        public async Task<UserDTO> LoginUser(string Username, string UserPassword)
        {
            var userLogin = await _userData.LoginUser(Username, UserPassword);
            var userDTO = _mapper.Map<UserDTO>(userLogin);
            return userDTO;
        }

        public Task<bool> Update(UserDTO entity)
        {
            var userDomain = _mapper.Map<User>(entity);
            var result = _userData.Update(userDomain);
            return result;
        }
    }
}
