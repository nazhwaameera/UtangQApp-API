using AutoMapper;
using UtangQApp_API_BLL.DTOs.Users;
using UtangQApp_API_BLL.Interfaces.User;
using UtangQApp_Data.Interfaces.Users;

namespace UtangQApp_API_BLL.BLLs.Users
{
    public class FriendshipStatusBLL : IFriendshipStatusBLL
    {
        private readonly IFriendshipStatus _friendshipStatusData;
        private readonly IMapper _mapper;

        public FriendshipStatusBLL(IFriendshipStatus friendshipStatusData, IMapper mapper)
        {
            _friendshipStatusData = friendshipStatusData;
            _mapper = mapper;
        }

        public async Task<FriendshipStatusDTO> Get(int id)
        {
            var friendshipStatus = await _friendshipStatusData.Get(id);
            var friendshipStatusDTO = _mapper.Map<FriendshipStatusDTO>(friendshipStatus);
            return friendshipStatusDTO;
        }

        public async Task<IEnumerable<FriendshipStatusDTO>> GetAll()
        {
           var friendshipStatuses = await _friendshipStatusData.GetAll();
            var friendshipStatusesDTO = _mapper.Map<IEnumerable<FriendshipStatusDTO>>(friendshipStatuses);
            return friendshipStatusesDTO;
        }
    }
}
