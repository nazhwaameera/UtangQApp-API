using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UtangQApp_Data.Interfaces.Reports;
using UtangQApp_Domain.Reports;

namespace UtangQApp_Data.DAL.Reports
{
    public class TransactionHistoryReportData : ITransactionHistoryReport
    {
        private readonly AppDbContext _context;
        public TransactionHistoryReportData(AppDbContext context)
        {
            _context = context;
        }

        public  async Task<IEnumerable<TransactionHistoryReport>> CreateView(int UserId)
        {
            var result = await _context.TransactionHistoryReports.FromSqlRaw("EXEC CreateBillPaymentReport @p0", UserId).ToListAsync();
            return result;
        }
    }
}
