using AutoMapper;
using UtangQApp_API_BLL.DTOs.Users;
using UtangQApp_API_BLL.Interfaces.User;
using UtangQApp_Data.Interfaces.Users;

namespace UtangQApp_API_BLL.BLLs.Users
{
    public class FriendshipBLL : IFriendshipBLL
    {
        private readonly IFriendship _friendshipData;
        private readonly IMapper _mapper;

        public FriendshipBLL(IFriendship friendshipData, IMapper mapper)
        {
            _friendshipData = friendshipData;
            _mapper = mapper;
        }

        public async Task<bool> CreateFriendship(int UserID)
        {
            var result = await _friendshipData.CreateFriendship(UserID);
            return result;
        }

        public async Task<FriendshipDTO> Get(int id)
        {
            var friendship = await _friendshipData.Get(id);
            var friendshipDTO = _mapper.Map<FriendshipDTO>(friendship);
            return friendshipDTO;
        }

        public async Task<IEnumerable<FriendshipDTO>> GetAll()
        {
            var friendships = await _friendshipData.GetAll();
            var friendshipsDTO = _mapper.Map<IEnumerable<FriendshipDTO>>(friendships);  
            return friendshipsDTO;
        }

        public async Task<FriendshipDTO> GetByUserID(int userID)
        {
            var friendship = await _friendshipData.GetByUserID(userID);
            var friendshipDTO = _mapper.Map<FriendshipDTO>(friendship);
            return friendshipDTO;
        }
    }
}
