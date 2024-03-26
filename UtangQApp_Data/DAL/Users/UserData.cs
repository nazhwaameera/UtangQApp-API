using Microsoft.EntityFrameworkCore;
using UtangQApp_Data.Interfaces.Users;
using UtangQApp_Domain.Users;

namespace UtangQApp_Data.DAL.Users
{
    public class UserData : IUser
    {
        private readonly AppDbContext _context;
        public UserData(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(User entity)
        {
            try
            {
                // Execute the stored procedure with parameters
                await _context.Database.ExecuteSqlRawAsync("EXEC Users.CreateUser @p0, @p1, @p2, @p3, @p4",
                    entity.Username, entity.UserPassword, entity.UserEmail, entity.UserFullName, entity.UserPhoneNumber);

                return true; // Return true if the creation is successful
            }
            catch (Exception ex)
            {
                // Throw an ArgumentException with an error message if an exception occurs
                throw new ArgumentException("Error creating user data: " + ex.Message);
            }
        }


        public async Task<bool> Delete(int id)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync("EXEC Users.DeleteUser {0}", id);
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error deleting user data: " + ex.Message);
            }
        }

        public async Task<User> Get(int id)
        {
            try
            {
                var result = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error reading user data by ID: " + ex.Message);
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                var result = await _context.Users.FromSqlRaw("EXEC Users.ReadAllUsers").ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error reading all user data: " + ex.Message);
            }
        }

        public async Task<User> GetByUsername(string Username)
        {
            try
            {
                var result = await _context.Users.FromSqlRaw("SELECT * FROM Users.Users WHERE Username = {0}", Username).SingleOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error reading user data by username: " + ex.Message);
            }
        }

        public async Task<IEnumerable<User>> GetFriends(int FriendshipID)
        {
            try
            {
                var result = await _context.Users.FromSqlRaw("EXEC Users.GetFriends {0}", FriendshipID).ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error getting friends: " + ex.Message);
            }
        }

        public async Task<IEnumerable<User>> GetNonFriends(int FriendshipID)
        {
            try
            {
                var result = await _context.Users.FromSqlRaw("EXEC Users.GetNonFriends {0}", FriendshipID).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error getting non-friends: " + ex.Message);
            }
        }

        public async Task<User> LoginUser(string Username, string UserPassword)
        {
            try
            {
                var result = await _context.Users
                    .FromSqlRaw("EXEC Users.LoginUser {0}, {1}", Username, UserPassword)
                    .ToListAsync();

                // If the result is a single user, return it, otherwise return null
                return result.SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error logging in user: " + ex.Message);
            }
        }


        public async Task<bool> Update(User entity)
        {
            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC Users.UpdateUser {0}, {1}, {2}, {3}, {4}, {5}, {6}",
                    entity.UserId, entity.Username, entity.UserPassword, entity.UserEmail, entity.UserFullName, entity.UserPhoneNumber, entity.IsLocked);

                if (result != 1)
                {
                    throw new ArgumentException("Update user data failed..");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error updating user data: " + ex.Message);
            }
        }
    }
}
