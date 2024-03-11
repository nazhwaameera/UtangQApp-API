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
    public class View_TransactionHistoryReportBLL : IView_TransactionHistoryReportBLL
    {
        private readonly ITransactionHistoryReport _view_TransactionHistoryReportDAL;
        public View_TransactionHistoryReportBLL()
        {
            _view_TransactionHistoryReportDAL = new View_TransactionHistoryReportDAL();
        }

        public IEnumerable<TransactionHistoryReportDTO> CreateView(int UserId)
        {
            try
            {
                List<TransactionHistoryReportDTO> transactionHistoryReportDTOs = new List<TransactionHistoryReportDTO>();
                var transactionHistory = _view_TransactionHistoryReportDAL.CreateView(UserId);
                foreach (var item in transactionHistory)
                {
                    TransactionHistoryReportDTO transactionHistoryReportDTO = new TransactionHistoryReportDTO
                    {
                        TransactionDate = item.TransactionDate,
                        TransactionAmount = item.TransactionAmount,
                        TransactionDescription = item.TransactionDescription
                    };
                    transactionHistoryReportDTOs.Add(transactionHistoryReportDTO);
                }
                return transactionHistoryReportDTOs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
