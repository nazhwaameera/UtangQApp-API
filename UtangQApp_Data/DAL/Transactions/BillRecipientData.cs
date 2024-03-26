using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using UtangQApp_Data.Interfaces.Transactions;
using UtangQApp_Domain.Transactions;

namespace UtangQApp_Data.DAL.Transactions
{
    public class BillRecipientData : IBillRecipient
    {
        private readonly AppDbContext _context;
        public BillRecipientData(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(BillRecipientCreate entity)
        {
            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync(
                    "EXEC Transactions.CreateBillRecipient {0}, {1}, {2}, {3}, {4}, {5}",
                    entity.BillID, entity.RecipientUserID, entity.TotalUsers,
                    entity.IsSplitEvenly, entity.TaxStatusDescription, entity.TaxCharged);

                if (result != 1)
                {
                    throw new ArgumentException("Insert bill recipient data failed..");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error creating bill recipient: " + ex.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC Transactions.DeleteBillRecipient @BillRecipientID", new SqlParameter("@BillRecipientID", id));

                if (result != 1)
                {
                    throw new ArgumentException("Delete bill recipient data failed..");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<BillRecipient> Get(int id)
        {
            try
            {
                var result = await _context.BillRecipients.SingleOrDefaultAsync(br => br.BillRecipientId == id);
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<BillRecipient>> GetAll()
        {
            try
            {
                var result = await _context.BillRecipients.FromSqlRaw("EXEC Transactions.ReadAllBillRecipients").ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<BillRecipient>> GetBillRecipientsByBillID(int BillID)
        {
            try
            {
                var results = await _context.BillRecipients.FromSqlRaw("EXEC Transactions.GetBillRecipientsByBillID {0}", BillID).ToListAsync();
                return results;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> HandleIncomingBillRecipient(int BillRecipientID, int NewStatusID)
        {
            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC Transactions.HandleIncomingBillRecipient {0}, {1}", BillRecipientID, NewStatusID);
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<BillRecipient>> ReadBillRecipientByRecipientUserID(int RecipientUserID)
        {
            try
            {
                var results = await _context.BillRecipients.FromSqlRaw("EXEC Transactions.ReadBillRecipientByRecipientUserID {0}", RecipientUserID).ToListAsync();
                return results;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<BillRecipientWithDesc>> ReadBillRecipientByRecipientUserIDWithDescription(int RecipientUserID)
        {
            try
            {
                var results = await _context.Set<BillRecipientWithDesc>().FromSqlRaw("EXEC Transactions.ReadBillRecipientByRecipientUserIDWithDescription {0}", RecipientUserID).ToListAsync();
                return results;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<decimal> TotalBillRecipientAmountByBillID(int BillID)
        {
            try
            {
                var billInfo = await _context.Bills
                    .Where(b => b.BillId == BillID)
                    .Select(b => new
                    {
                        BillAmount = b.BillAmount,
                        OwnerContribution = b.OwnerContribution
                    })
                    .FirstOrDefaultAsync();

                if (billInfo == null)
                {
                    throw new Exception($"Bill with ID {BillID} not found.");
                }

                decimal billAmount = billInfo.BillAmount;
                decimal ownerContribution = billInfo.OwnerContribution;

                // Calculate the total bill recipient amount for the specified bill ID
                var totalBillRecipientAmount = await _context.BillRecipients
                    .Where(br => br.BillId == BillID)
                    .Select(br => (decimal?)br.BillRecipientAmount)
                    .SumAsync() ?? 0;

                // Subtract the total bill amount (including the owner contribution) from the total bill recipient amount
                decimal totalAmount = (totalBillRecipientAmount + ownerContribution) - billAmount;

                return totalAmount;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> Update(BillRecipient entity)
        {
            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync(
                    "EXEC Transactions.UpdateBillRecipient " +
                    "{0}, {1}, {2}, {3}, {4}, {5}",
                    entity.BillRecipientId,
                    entity.BillId,
                    entity.RecipientUserId,
                    entity.SentDate,
                    entity.BillRecipientStatusId,
                    entity.BillRecipientTaxStatusId
                );

                if (result != 1)
                {
                    throw new ArgumentException("Update bill recipient data failed..");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> UpdateBillRecipientPaymentStatus(int BillRecipientID, int NewStatusID)
        {
            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC Transactions.UpdateBillRecipientPaymentStatus {0}, {1}", BillRecipientID, NewStatusID);
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
