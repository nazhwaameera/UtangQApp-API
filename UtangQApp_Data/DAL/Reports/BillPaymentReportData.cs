using UtangQApp_Data.Interfaces.Reports;
using UtangQApp_Domain.Reports;
using Microsoft.EntityFrameworkCore;

namespace UtangQApp_Data.DAL.Reports
{
    public class BillPaymentReportData : IBillPaymentReport
    {
        private readonly AppDbContext _context;
        public BillPaymentReportData(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BillPaymentReport>> CreateView(int UserId)
        {
            var result = await _context.BillPaymentReports.FromSqlRaw("EXEC CreateBillPaymentReport @p0", UserId).ToListAsync();
            return result;
        }
    }
}
