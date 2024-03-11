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
    public class View_WalletBalanceReportBLL : IView_WalletBalanceReportBLL
    {
        private readonly IWalletBalanceReport _view_WalletBalanceReportDAL;
        public View_WalletBalanceReportBLL()
        {
            _view_WalletBalanceReportDAL = new View_WalletBalanceReportDAL();
        }

        public IEnumerable<WalletBalanceReportDTO> CreateView(int UserId)
        {
            try
            {
                List<WalletBalanceReportDTO> walletBalanceReportDTOs = new List<WalletBalanceReportDTO>();
                var walletBalanceReport = _view_WalletBalanceReportDAL.CreateView(UserId);
                foreach (var item in walletBalanceReport)
                {
                    WalletBalanceReportDTO walletBalanceReportDTO = new WalletBalanceReportDTO
                    {
                        UserID = item.UserID,
                        WalletBalance = item.WalletBalance,
                        TransactionDate = item.TransactionDate,
                        WalletTransactionAmount = item.WalletTransactionAmount,
                        TransactionDescription = item.TransactionDescription
                    };
                    walletBalanceReportDTOs.Add(walletBalanceReportDTO);
                }
                return walletBalanceReportDTOs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
