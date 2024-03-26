using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using UtangQApp_Data.Interfaces.Transactions;
using UtangQApp_Domain.Transactions;

namespace UtangQApp_Data.DAL.Transactions
{
    public class PaymentReceiptData : IPaymentReceipt
    {
        private readonly AppDbContext _context;
        public PaymentReceiptData(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(PaymentReceipt entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreatePaymentReceiptAndUpdateStatus(int BillRecipientID, string PaymentReceiptURL)
        {
            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC Transactions.CreatePaymentReceiptAndUpdateStatus {0}, {1}", BillRecipientID, PaymentReceiptURL);
                return true;
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException($"{sqlEx.InnerException.Message} - {sqlEx.Number}");
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
                int result = await _context.Database.ExecuteSqlRawAsync("EXEC Transactions.DeletePaymentReceipt {0}", id);

                if (result != 1)
                {
                    throw new ArgumentException("Delete payment receipt data failed..");
                }
                return true;
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException($"{sqlEx.InnerException.Message} - {sqlEx.Number}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<PaymentReceipt> Get(int id)
        {
            try
            {
                var result = await _context.PaymentReceipts.SingleOrDefaultAsync(pr => pr.PaymentReceiptId == id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<PaymentReceipt>> GetAll()
        {
            try
            {
                var results = await _context.PaymentReceipts.FromSqlRaw("EXEC Transactions.ReadAllPaymentReceipts").ToListAsync();

                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PaymentReceipt> ReadPaymentReceiptbyBillRecipientID(int BillRecipientID)
        {
            try
            {
                var result = await _context.PaymentReceipts.SingleOrDefaultAsync(pr => pr.BillRecipientId == BillRecipientID);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<PaymentReceipt>> ReadPaymentReceiptsByBillCreator(int CreatorUserID)
        {
            try
            {
                var result = await _context.PaymentReceipts.FromSqlRaw("EXEC Transactions.ReadPaymentReceiptsByBillCreator {0}", CreatorUserID).ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(PaymentReceipt entity)
        {
            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync(
                    "EXEC Transactions.UpdatePaymentReceipt @PaymentReceiptID, @BillRecipientID, @SentDate, @ConfirmationDate, @PaymentReceiptURL",
                    entity.PaymentReceiptId, entity.BillRecipientId, entity.SentDate, entity.ConfirmationDate, entity.PaymentReceiptUrl);

                if (result != 1)
                {
                    throw new ArgumentException("Update payment receipt data failed..");
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
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC Transactions.UpdateBillRecipientPaymentStatus {0}, {1}",BillRecipientID, NewStatusID);

                if (result != 4)
                {
                    throw new ArgumentException("Update bill recipient payment status data failed..");
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
