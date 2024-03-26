using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using UtangQApp_Data.Interfaces.Users;
using UtangQApp_Domain.Users;

namespace UtangQApp_Data.DAL.Users
{
    public class WalletData : IWallet
    {
        private readonly AppDbContext _context;
        public WalletData(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Wallet entity)
        {
            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync(
                    "EXEC Users.CreateWallet {0}, {1}",
                    entity.UserId, entity.WalletBalance);

                if (result != 1)
                {
                    throw new ArgumentException("Create wallet data failed..");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error creating wallet: " + ex.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync(
                    "EXEC Users.DeleteWallet {0}}", id);

                if (result != 1)
                {
                    throw new ArgumentException("Delete wallet data failed..");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error deleting wallet: " + ex.Message);
            }
        }

        public async Task<Wallet> Get(int id)
        {
            try
            {
                var result = await _context.Wallets.SingleOrDefaultAsync(w => w.WalletId == id);

                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error reading wallet: " + ex.Message);
            }
        }

        public  async Task<IEnumerable<Wallet>> GetAll()
        {
            try
            {
                var result = await _context.Wallets.FromSqlRaw("EXEC Users.ReadAllWallets").ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error reading all wallets: " + ex.Message);
            }
        }

        public async Task<Wallet> ReadWalletbyUserID(int UserID)
        {
            try
            {
                var result = await _context.Wallets.SingleOrDefaultAsync(w => w.UserId == UserID);

                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error reading wallet by user ID: " + ex.Message);
            }
        }

        public async Task<bool> Update(Wallet entity)
        {
            try
            {
                // Build the SQL command manually to execute the stored procedure
                var sql = $"EXEC Users.UpdateWallet @WalletID={entity.WalletId}, @UserID={entity.UserId}, @WalletBalance={entity.WalletBalance}";

                // Execute the stored procedure
                var result = await _context.Database.ExecuteSqlRawAsync(sql);

                // Check if the result indicates successful execution
                if (result != 1)
                {
                    throw new ArgumentException("Update wallet data failed..");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error updating wallet: " + ex.Message);
            }
        }

        public async Task<bool> UpdateWalletBalance(int UserID, decimal Amount, char OperationFlag)
        {
            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync(
                    "EXEC Transactions.UpdateWalletBalance {0}, {1}, {2}", UserID, Amount, OperationFlag);

                if (result != 2)
                {
                    throw new ArgumentException("Update wallet balance data failed..");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error updating wallet balance: " + ex.Message);
            }
        }
    }
}
