using AutoMapper;
using UtangQApp_API_BLL.DTOs.Users;
using UtangQApp_API_BLL.Interfaces.User;
using UtangQApp_Data.DAL.Users;
using UtangQApp_Data.Interfaces.Users;

namespace UtangQApp_API_BLL.BLLs.Users
{
    public class FriendshipListBLL : IFriendshipListBLL
    {
        private readonly IFriendshipList _friendshipListData;
        private readonly IMapper _mapper;

        public FriendshipListBLL(IFriendshipList friendshipListData, IMapper mapper)
        {
            _friendshipListData = friendshipListData;
            _mapper = mapper;
        }

        public async Task<bool> CreateFriendRequest(int FriendshipID, int SenderUserID, int ReceiverUserID)
        {
            var result = await _friendshipListData.CreateFriendRequest(FriendshipID, SenderUserID, ReceiverUserID);
            return result;
        }

        public async Task<FriendshipListDTO> Get(int id)
        {
            var friendshipList = await _friendshipListData.Get(id);
            var friendshipListDTO = _mapper.Map<FriendshipListDTO>(friendshipList);
            return friendshipListDTO;
        }

        public async Task<IEnumerable<FriendshipListDTO>> GetAll()
        {
            var friendshipsList = await _friendshipListData.GetAll();
            var friendshipsListDTO = _mapper.Map<IEnumerable<FriendshipListDTO>>(friendshipsList);
            return friendshipsListDTO;
        }

        public async Task<IEnumerable<FriendshipListDTO>> GetByUserID(int userID)
        {
            var friendshipsList = await _friendshipListData.GetByUserID(userID);
            var friendshipsListDTO = _mapper.Map<IEnumerable<FriendshipListDTO>>(friendshipsList);
            return friendshipsListDTO;
        }

        public async Task<IEnumerable<FriendshipListDTO>> GetPendingFriendRequestsByReceiverUserID(int ReceiverUserID)
        {
            var pendingRequests = await _friendshipListData.GetPendingFriendRequestsByReceiverUserID(ReceiverUserID);
            var pendingRequestsDTO = _mapper.Map<IEnumerable<FriendshipListDTO>>(pendingRequests);
            return pendingRequestsDTO;
        }

        public async Task<bool> HandleFriendRequest(int FriendshipListID, int FriendshipStatusID)
        {
            var result = await _friendshipListData.HandleFriendRequest(FriendshipListID, FriendshipStatusID);
            return result;
        }
    }
}
