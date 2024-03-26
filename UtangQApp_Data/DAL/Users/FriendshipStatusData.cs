using Microsoft.EntityFrameworkCore;
using UtangQApp_Data.Interfaces.Users;
using UtangQApp_Domain.Users;

namespace UtangQApp_Data.DAL.Users
{
    public class FriendshipStatusData : IFriendshipStatus
    {
        private readonly AppDbContext _context;
        public FriendshipStatusData(AppDbContext context)
        {
            _context = context;
        }

        public async Task<FriendshipStatus> Get(int id)
        {
            try
            {
                var result = await _context.FriendshipStatuses.SingleOrDefaultAsync(fs => fs.FriendshipStatusId == id);
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error reading friendship status by ID: " + ex.Message);
            }
        }

        public async Task<IEnumerable<FriendshipStatus>> GetAll()
        {
            try
            {
                var result = await _context.FriendshipStatuses.FromSqlRaw("EXEC Users.ReadAllFriendshipStatuses").ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error reading all friendship statuses: " + ex.Message);
            }
        }
    }
}
