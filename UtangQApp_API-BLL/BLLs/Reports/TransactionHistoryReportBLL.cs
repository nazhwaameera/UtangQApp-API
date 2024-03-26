using AutoMapper;
using UtangQApp_API_BLL.DTOs.Reports;
using UtangQApp_API_BLL.Interfaces.Report;
using UtangQApp_Data.Interfaces.Reports;

namespace UtangQApp_API_BLL.BLLs.Reports
{
    public class TransactionHistoryReportBLL : IView_TransactionHistoryReportBLL
    {
        private readonly ITransactionHistoryReport _transactionHistoryReportData;
        private readonly IMapper _mapper;

        public TransactionHistoryReportBLL(ITransactionHistoryReport transactionHistoryReportData, IMapper mapper)
        {
            _transactionHistoryReportData = transactionHistoryReportData;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TransactionHistoryReportDTO>> CreateView(int UserId)
        {
            var reports = await _transactionHistoryReportData.CreateView(UserId);
            var reportsDTO = _mapper.Map<IEnumerable<TransactionHistoryReportDTO>>(reports);
            return reportsDTO;
        }
    }
}
