using Microsoft.EntityFrameworkCore;
using UtangQApp_Data.Interfaces.Reports;
using UtangQApp_Domain.Reports;

namespace UtangQApp_Data.DAL.Reports
{
    public class PaymentReceiptReportData : IPaymentReceiptReport
    {
        private readonly AppDbContext _context;
        public PaymentReceiptReportData(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PaymentReceiptReport>> CreateView(int UserId)
        {
            var result = await _context.PaymentReceiptReports.FromSqlRaw("EXEC CreateBillPaymentReport @p0", UserId).ToListAsync();
            return result;
        }
    }
}
