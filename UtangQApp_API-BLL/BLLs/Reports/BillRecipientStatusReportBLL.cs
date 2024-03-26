using AutoMapper;
using UtangQApp_API_BLL.DTOs.Reports;
using UtangQApp_API_BLL.Interfaces.Report;
using UtangQApp_Data.Interfaces.Reports;

namespace UtangQApp_API_BLL.BLLs.Reports
{
    public class BillRecipientStatusReportBLL : IView_BillRecipientStatusReportBLL
    {
        private readonly IBillRecipientStatusReport _billRecipientStatusReportData;
        private readonly IMapper _mapper;

        public BillRecipientStatusReportBLL(IBillRecipientStatusReport billRecipientStatusReportData, IMapper mapper)
        {
            _billRecipientStatusReportData = billRecipientStatusReportData;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BillRecipientStatusReportDTO>> CreateView(int UserId)
        {
            var reports = await _billRecipientStatusReportData.CreateView(UserId);
            var reportsDTO = _mapper.Map<IEnumerable<BillRecipientStatusReportDTO>>(reports);
            return reportsDTO;
        }
    }
}
