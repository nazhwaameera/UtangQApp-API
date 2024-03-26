using AutoMapper;
using UtangQApp_API_BLL.DTOs.Reports;
using UtangQApp_API_BLL.Interfaces.Report;
using UtangQApp_Data.Interfaces.Reports;

namespace UtangQApp_API_BLL.BLLs.Reports
{
    public class WalletBalanceReportBLL : IView_WalletBalanceReportBLL
    {
        private readonly IWalletBalanceReport _walletBalanceReportData;
        private readonly IMapper _mapper;

        public WalletBalanceReportBLL(IWalletBalanceReport walletBalanceReportData, IMapper mapper)
        {
            _walletBalanceReportData = walletBalanceReportData;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WalletBalanceReportDTO>> CreateView(int UserId)
        {
            var reports = await _walletBalanceReportData.CreateView(UserId);
            var reportsDTO = _mapper.Map<IEnumerable<WalletBalanceReportDTO>>(reports);
            return reportsDTO;
        }
    }
}
