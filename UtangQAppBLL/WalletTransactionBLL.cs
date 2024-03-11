using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBLL.DTOs.Transaction;
using UtangQAppBLL.DTOs.User;
using UtangQAppBLL.Interfaces.Transaction;
using UtangQAppBO;
using UtangQAppDAL;
using UtangQAppDAL.Interfaces;
using static Dapper.SqlMapper;

namespace UtangQAppBLL
{
    public class WalletTransactionBLL : IWalletTransactionBLL
    {
        private readonly IWalletTransaction _walletTransactionDAL;

        public WalletTransactionBLL()
        {
            _walletTransactionDAL = new WalletTransactionDAL();
        }
        public void Create(WalletTransactionCreateDTO entity)
        {
            try
            {
                var walletTransaction = new WalletTransaction
                {
                    WalletID = entity.WalletID,
                    WalletTransactionAmount = entity.WalletTransactionAmount,
                    TransactionDate = entity.TransactionDate,
                    TransactionDescription = entity.TransactionDescription
                };
                _walletTransactionDAL.Create(walletTransaction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _walletTransactionDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public WalletTransactionDTO Get(int id)
        {
            WalletTransactionDTO walletTransactionDTO = new WalletTransactionDTO();
            try
            {
                var walletTransaction = _walletTransactionDAL.Get(id);
                walletTransactionDTO.WalletTransactionID = walletTransaction.WalletTransactionID;
                walletTransactionDTO.WalletID = walletTransaction.WalletID;
                walletTransactionDTO.WalletTransactionAmount = walletTransaction.WalletTransactionAmount;
                walletTransactionDTO.TransactionDate = walletTransaction.TransactionDate;
                walletTransactionDTO.TransactionDescription = walletTransaction.TransactionDescription;
                return walletTransactionDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<WalletTransactionDTO> GetAll()
        {
            List<WalletTransactionDTO> walletTransactionDTOs = new List<WalletTransactionDTO>();
            var walletTransactionsDAL = _walletTransactionDAL.GetAll();
            foreach (var walletTransactions in walletTransactionsDAL)
            {
                WalletTransactionDTO walletTransactionDTO = new WalletTransactionDTO
                {
                    WalletTransactionID = walletTransactions.WalletTransactionID,
                    WalletID = walletTransactions.WalletID,
                    WalletTransactionAmount = walletTransactions.WalletTransactionAmount,
                    TransactionDate = walletTransactions.TransactionDate,
                    TransactionDescription = walletTransactions.TransactionDescription
                };
                walletTransactionDTOs.Add(walletTransactionDTO);
            }
            return walletTransactionDTOs;
        }

        public IEnumerable<WalletTransactionDTO> ReadWalletTransactionbyUserID(int UserID)
        {
            List<WalletTransactionDTO> walletTransactionDTOs = new List<WalletTransactionDTO>();
            var walletTransactionsDAL = _walletTransactionDAL.ReadWalletTransactionbyUserID(UserID);
            foreach (var walletTransactions in walletTransactionsDAL)
            {
                WalletTransactionDTO walletTransactionDTO = new WalletTransactionDTO
                {
                    WalletTransactionID = walletTransactions.WalletTransactionID,
                    WalletID = walletTransactions.WalletID,
                    WalletTransactionAmount = walletTransactions.WalletTransactionAmount,
                    TransactionDate = walletTransactions.TransactionDate,
                    TransactionDescription = walletTransactions.TransactionDescription
                };
                walletTransactionDTOs.Add(walletTransactionDTO);
            }
            return walletTransactionDTOs;
        }

        public void Update(WalletTransactionDTO entity)
        {
            try
            {
                var walletTransaction = new WalletTransaction
                {
                    WalletTransactionID = entity.WalletTransactionID,
                    WalletID = entity.WalletID,
                    WalletTransactionAmount = entity.WalletTransactionAmount,
                    TransactionDate = entity.TransactionDate,
                    TransactionDescription = entity.TransactionDescription
                };
                _walletTransactionDAL.Update(walletTransaction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
