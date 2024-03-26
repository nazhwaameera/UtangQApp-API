using UtangQApp_Domain.Users;

namespace UtangQApp_Data.Interfaces.Users
{
    public interface IFriendship : IHelper<Friendship>
    {
        Task<Friendship> GetByUserID(int userID);
        Task<bool> CreateFriendship(int UserID);
    }
}
