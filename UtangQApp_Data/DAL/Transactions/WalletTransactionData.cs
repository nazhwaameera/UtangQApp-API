using Microsoft.EntityFrameworkCore;
using UtangQApp_Data.Interfaces.Transactions;
using UtangQApp_Domain.Transactions;

namespace UtangQApp_Data.DAL.Transactions
{
    public class WalletTransactionData : IWalletTransaction
    {
        private readonly AppDbContext _context;
        public WalletTransactionData(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(WalletTransaction entity)
        {
            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC Transactions.CreateWalletTransaction @p0, @p1, @p2",entity.WalletId,entity.WalletTransactionAmount,entity.TransactionDescription);

                if (result != 1)
                {
                    throw new ArgumentException("Insert wallet transaction data failed..");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync(
                    "EXEC Transactions.DeleteWalletTransaction @p0",id);

                if (result != 1)
                {
                    throw new ArgumentException("Delete wallet transaction data failed..");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<WalletTransaction> Get(int id)
        {
            try
            {
                var result = await _context.WalletTransactions.SingleOrDefaultAsync(wt => wt.WalletTransactionId == id);

                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<WalletTransaction>> GetAll()
        {
            try
            {
                var result = await _context.WalletTransactions.FromSqlRaw("EXEC Transactions.ReadAllWalletTransactions").ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<WalletTransaction>> ReadWalletTransactionbyUserID(int UserID)
        {
            try
            {
                var result = await _context.WalletTransactions.FromSqlRaw("EXEC Transactions.ReadWalletTransactionbyUserID @p0", UserID).ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> Update(WalletTransaction entity)
        {
            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC Transactions.UpdateWalletTransaction " + "@p0, @p1, @p2, @p3, @p4", entity.WalletTransactionId, entity.WalletId, entity.WalletTransactionAmount, entity.TransactionDate, entity.TransactionDescription);

                if (result != 1)
                {
                    throw new ArgumentException("Update wallet transaction data failed..");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
