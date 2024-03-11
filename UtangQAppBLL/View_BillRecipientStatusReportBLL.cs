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
    public class View_BillRecipientStatusReportBLL : IView_BillRecipientStatusReportBLL
    {
        private readonly IBillRecipientStatusReport _view_BillRecipientStatusReportDAL;
        public View_BillRecipientStatusReportBLL()
        {
            _view_BillRecipientStatusReportDAL = new View_BillRecipientStatusReportDAL();
        }

        public IEnumerable<BillRecipientStatusReportDTO> CreateView(int UserId)
        {
            try
            {
                List<BillRecipientStatusReportDTO> billRecipientStatusReportDTOs = new List<BillRecipientStatusReportDTO>();
                var billRecipientStatusReport = _view_BillRecipientStatusReportDAL.CreateView(UserId);
                foreach (var item in billRecipientStatusReport)
                {
                    BillRecipientStatusReportDTO billRecipientStatusReportDTO = new BillRecipientStatusReportDTO
                    {
                        BillRecipientID = item.BillRecipientID,
                        BillID = item.BillID,
                        SentDate = item.SentDate,
                        Status = item.Status
                    };
                    billRecipientStatusReportDTOs.Add(billRecipientStatusReportDTO);
                }
                return billRecipientStatusReportDTOs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
