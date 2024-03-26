using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using UtangQApp_Data.Interfaces.Transactions;
using UtangQApp_Domain.Transactions;

namespace UtangQApp_Data.DAL.Transactions
{
    public class BillStatusData : IBillStatus
    {
        private readonly AppDbContext _context;
        public BillStatusData(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(BillStatus entity)
        {
            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC Transactions.CreateBillStatus {0}", entity.BillStatusDescription);

                if (result != 1)
                {
                    throw new ArgumentException("Insert bill status data failed..");
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
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC Transactions.DeleteBillStatus {0}", id);

                if (result != 1)
                {
                    throw new ArgumentException("Delete bill status data failed..");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<BillStatus> Get(int id)
        {
            try
            {
                var result = await _context.BillStatuses.SingleOrDefaultAsync(bs => bs.BillStatusId == id);
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<BillStatus>> GetAll()
        {
            try
            {
                var result = await _context.BillStatuses.FromSqlRaw("EXEC Transactions.ReadAllBillStatus").ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> Update(BillStatus entity)
        {
            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC Transactions.UpdateBillStatus {0}, {1}", entity.BillStatusId, entity.BillStatusDescription);

                if (result != 1)
                {
                    throw new ArgumentException("Update bill status data failed..");
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
    }
}
