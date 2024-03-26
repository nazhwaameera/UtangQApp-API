using Microsoft.EntityFrameworkCore;
using UtangQApp_Data.Interfaces.Users;
using UtangQApp_Domain.Users;

namespace UtangQApp_Data.DAL.Users
{
    public class FriendshipListData : IFriendshipList
    {
        private readonly AppDbContext _context;
        public FriendshipListData(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateFriendRequest(int FriendshipID, int SenderUserID, int ReceiverUserID)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync("EXEC Users.CreateFriendRequest @p0, @p1, @p2", FriendshipID, SenderUserID, ReceiverUserID);
                return true;            
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Create friend request failed: " + ex.Message);
            }
        }

        public async Task<FriendshipList> Get(int id)
        {
            try
            {
                var result = await _context.FriendshipLists.SingleOrDefaultAsync(fl => fl.FriendshipListId == id);
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error reading friendship list by ID: " + ex.Message);
            }
        }

        public async Task<IEnumerable<FriendshipList>> GetAll()
        {
            try
            {
                var result = await _context.FriendshipLists.FromSqlRaw("EXEC Users.ReadAllFriendshipLists").ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error reading all friendship lists: " + ex.Message);
            }
        }

        public async Task<IEnumerable<FriendshipList>> GetByUserID(int userID)
        {
            try
            {
                var result = await _context.FriendshipLists.FromSqlRaw("EXEC Users.ReadFriendshipListByUserID @p0", userID).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error reading friendship lists by user ID: " + ex.Message);
            }
        }

        public async Task<IEnumerable<FriendshipList>> GetPendingFriendRequestsByReceiverUserID(int ReceiverUserID)
        {
            try
            {
                var result = await _context.FriendshipLists.FromSqlRaw("EXEC Users.GetPendingFriendRequestsByReceiverUserID @p0", ReceiverUserID).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error getting pending friend requests by receiver user ID: " + ex.Message);
            }
        }

        public async Task<bool> HandleFriendRequest(int FriendshipListID, int FriendshipStatusID)
        {
            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC Users.HandleFriendRequest @p0, @p1", FriendshipListID, FriendshipStatusID);
                if (result != 2)
                {
                    throw new ArgumentException("Handle friend request failed..");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error handling friend request: " + ex.Message);
            }
        }
    }
}
