
using Microsoft.EntityFrameworkCore;
using UtangQApp_Data.Interfaces.Reports;
using UtangQApp_Domain.Reports;

namespace UtangQApp_Data.DAL.Reports
{
    public class BillRecipientStatusReportData : IBillRecipientStatusReport
    {
        private readonly AppDbContext _context;
        public BillRecipientStatusReportData(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BillRecipientStatusReport>> CreateView(int UserId)
        {
            var result = await _context.BillRecipientStatusReports.FromSqlRaw("EXEC CreateBillPaymentReport @p0", UserId).ToListAsync();
            return result;
        }
    }
}
