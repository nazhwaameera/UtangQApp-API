using UtangQApp_Domain.Users;


namespace UtangQApp_Data.Interfaces.Users
{
    public interface IFriendshipList : IHelper<FriendshipList>
    {
        Task<IEnumerable<FriendshipList>> GetByUserID(int userID);
        Task<IEnumerable<FriendshipList>> GetPendingFriendRequestsByReceiverUserID(int ReceiverUserID);
        Task<bool> CreateFriendRequest(int FriendshipID, int SenderUserID, int ReceiverUserID);
        Task<bool> HandleFriendRequest(int FriendshipListID, int FriendshipStatusID);
    }
}
