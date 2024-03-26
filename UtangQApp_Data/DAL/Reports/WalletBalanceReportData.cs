using Microsoft.EntityFrameworkCore;
using UtangQApp_Data.Interfaces.Reports;
using UtangQApp_Domain.Reports;

namespace UtangQApp_Data.DAL.Reports
{
    public class WalletBalanceReportData : IWalletBalanceReport
    {
        private readonly AppDbContext _context;
        public WalletBalanceReportData(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WalletBalanceReport>> CreateView(int UserId)
        {
            var result = await _context.WalletBalanceReports.FromSqlRaw("EXEC CreateBillPaymentReport @p0", UserId).ToListAsync();
            return result;
        }
    }
}
