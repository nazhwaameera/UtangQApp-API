using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBLL.DTOs.Report;
using UtangQAppBLL.DTOs.User;
using UtangQAppBLL.Interfaces.Report;
using UtangQAppBO;
using UtangQAppDAL;
using UtangQAppDAL.Interfaces;

namespace UtangQAppBLL
{
    public class View_BillPaymentReportBLL : IView_BillPaymentReportBLL
    {
        private readonly IBillPaymentReport _view_BillPaymentReportDAL;
        public View_BillPaymentReportBLL()
        {
            _view_BillPaymentReportDAL = new View_BillPaymentReportDAL();
        }

        public IEnumerable<BillPaymentReportDTO> CreateView(int UserId)
        {
            try
            {
               List<BillPaymentReportDTO> billPaymentReportDTOs = new List<BillPaymentReportDTO>();
                var billPaymentReport = _view_BillPaymentReportDAL.CreateView(UserId);
                foreach (var item in billPaymentReport)
                {
                    BillPaymentReportDTO billPaymentReportDTO = new BillPaymentReportDTO
                    {
                        BillAmount = item.BillAmount,
                        BillDate = item.BillDate,
                        BillDescription = item.BillDescription,
                        PaymentStatus = item.PaymentStatus
                    };
                    billPaymentReportDTOs.Add(billPaymentReportDTO);
                }
                return billPaymentReportDTOs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
