using Microsoft.EntityFrameworkCore;
using UtangQApp_Data.Interfaces.Users;
using UtangQApp_Domain.Users;

namespace UtangQApp_Data.DAL.Users
{
    public class FriendshipData : IFriendship
    {
        private readonly AppDbContext _context;
        public FriendshipData(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateFriendship(int UserID)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync("EXEC Users.CreateFriendship @p0", UserID);
                return true;
            }
            catch (DbUpdateException ex)
            {
                // Handle any database-related exceptions
                throw new ArgumentException("Create friendship data failed: " + ex.InnerException?.Message);
            }
            catch (Exception ex)
            {
                // Handle any other exceptions
                throw new ArgumentException("Create friendship data failed: " + ex.Message);
            }
        }

        public async Task<Friendship> Get(int id)
        {
            try
            {
                var result = await _context.Friendships.SingleOrDefaultAsync(f => f.FriendshipId == id);
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error reading friendship data by ID: " + ex.Message);
            }
        }

        public async Task<IEnumerable<Friendship>> GetAll()
        {
            try
            {
                var result = await _context.Friendships.FromSqlRaw("EXEC Users.ReadAllFriendships").ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error reading all friendships data: " + ex.Message);
            }
        }

        public async Task<Friendship> GetByUserID(int userID)
        {
            try
            {
                var result = await _context.Friendships.SingleOrDefaultAsync(f => f.UserId == userID);
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error reading friendship data: " + ex.Message);
            }
        }
    }
}
