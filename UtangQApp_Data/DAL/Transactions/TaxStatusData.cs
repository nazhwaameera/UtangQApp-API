using Microsoft.EntityFrameworkCore;
using UtangQApp_Data.Interfaces.Transactions;
using UtangQApp_Domain.Transactions;

namespace UtangQApp_Data.DAL.Transactions
{
    public class TaxStatusData : ITaxStatus
    {
        private readonly AppDbContext _context;
        public TaxStatusData(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(TaxStatus entity)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync("EXEC Transactions.CreateTaxStatus {0}",entity.TaxStatusDescription);
                return true;
            }
            catch (DbUpdateException ex)
            {
                throw new ArgumentException("Insert tax status data failed.", ex);
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
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC Transactions.DeleteTaxStatus @p0", id);

                if (result != 1)
                {
                    throw new ArgumentException("Delete tax status data failed.");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<TaxStatus> Get(int id)
        {
            try
            {
                var result = await _context.TaxStatuses.SingleOrDefaultAsync(ts => ts.TaxStatusId == id);

                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<TaxStatus>> GetAll()
        {
            try
            {
                var results = await _context.TaxStatuses.FromSqlRaw("EXEC Transactions.ReadAllTaxStatus").ToListAsync();

                return results;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> Update(TaxStatus entity)
        {
            try
            {
                var result = _context.Database.ExecuteSqlRaw("EXEC Transactions.UpdateTaxStatus @p0, @p1",entity.TaxStatusId,entity.TaxStatusDescription);

                if (result != 1)
                {
                    throw new ArgumentException("Update tax status data failed..");
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
