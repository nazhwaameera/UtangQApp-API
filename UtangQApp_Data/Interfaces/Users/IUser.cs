using UtangQApp_Domain.Users;


namespace UtangQApp_Data.Interfaces.Users
{
    public interface IUser : ICrud<User>
    {
        Task<User> LoginUser(string Username, string UserPassword);
        Task<User> GetByUsername(string Username);
        Task<IEnumerable<User>> GetFriends(int FriendshipID);
        Task<IEnumerable<User>> GetNonFriends(int FriendshipID);
    }
}
