using AutoMapper;
using UtangQApp_API_BLL.DTOs.Reports;
using UtangQApp_API_BLL.Interfaces.Report;
using UtangQApp_Data.Interfaces.Reports;

namespace UtangQApp_API_BLL.BLLs.Reports
{
    public class BillPaymentReportBLL : IView_BillPaymentReportBLL
    {
        private readonly IBillPaymentReport _billPaymentReportData;
        private readonly IMapper _mapper;

        public BillPaymentReportBLL(IBillPaymentReport billPaymentReportData, IMapper mapper)
        {
            _billPaymentReportData = billPaymentReportData;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BillPaymentReportDTO>> CreateView(int UserId)
        {
            var reports = await _billPaymentReportData.CreateView(UserId);
            var reportsDTO = _mapper.Map<IEnumerable<BillPaymentReportDTO>>(reports);
            return reportsDTO;
        }
    }
}
