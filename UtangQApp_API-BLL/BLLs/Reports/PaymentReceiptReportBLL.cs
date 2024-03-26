using AutoMapper;
using UtangQApp_API_BLL.DTOs.Reports;
using UtangQApp_API_BLL.Interfaces.Report;
using UtangQApp_Data.Interfaces.Reports;

namespace UtangQApp_API_BLL.BLLs.Reports
{
    public class PaymentReceiptReportBLL : IView_PaymentReceiptReportBLL
    {
        private readonly IPaymentReceiptReport _paymentReceiptReportData;
        private readonly IMapper _mapper;

        public PaymentReceiptReportBLL(IPaymentReceiptReport paymentReceiptReportData, IMapper mapper)
        {
            _paymentReceiptReportData = paymentReceiptReportData;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentReceiptReportDTO>> CreateView(int UserId)
        {
            var reports = await _paymentReceiptReportData.CreateView(UserId);
            var reportsDTO = _mapper.Map<IEnumerable<PaymentReceiptReportDTO>>(reports);
            return reportsDTO;
        }
    }
}
