using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBLL.DTOs.Report;
using UtangQAppBLL.Interfaces.Report;
using UtangQAppDAL;
using UtangQAppDAL.Interfaces;

namespace UtangQAppBLL
{
    public class View_PaymentReceiptReportBLL : IView_PaymentReceiptReportBLL
    {
        private readonly IPaymentReceiptReport _view_PaymentReceiptReportDAL;
        public View_PaymentReceiptReportBLL()
        {
            _view_PaymentReceiptReportDAL = new View_PaymentReceiptReportDAL();
        }

        public IEnumerable<PaymentReceiptReportDTO> CreateView(int UserId)
        {
            try
            {
                List<PaymentReceiptReportDTO> paymentReceiptReportDTOs = new List<PaymentReceiptReportDTO>();
                var paymentReceiptReport = _view_PaymentReceiptReportDAL.CreateView(UserId);
                foreach (var item in paymentReceiptReport)
                {
                    PaymentReceiptReportDTO paymentReceiptReportDTO = new PaymentReceiptReportDTO
                    {
                        PaymentReceiptID = item.PaymentReceiptID,
                        BillRecipientID = item.BillRecipientID,
                        ReceiptSentDate = item.ReceiptSentDate,
                        ConfirmationDate = item.ConfirmationDate,
                        PaymentReceiptURL = item.PaymentReceiptURL,
                    };
                    paymentReceiptReportDTOs.Add(paymentReceiptReportDTO);
                }
                return paymentReceiptReportDTOs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
