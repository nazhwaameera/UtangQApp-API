using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBLL.DTOs.User;
using UtangQAppBLL.Interfaces.User;
using UtangQAppBO;
using UtangQAppDAL;
using UtangQAppDAL.Interfaces;

namespace UtangQAppBLL
{
    public class WalletBLL : IWalletBLL
    {
        private readonly IWallet _walletDAL;
        public WalletBLL()
        {
            _walletDAL = new WalletDAL();
        }
        public void Create(WalletCreateDTO entity)
        {
            try
            {
                var wallet = new Wallet
                {
                    UserID = entity.UserID,
                    WalletBalance = entity.WalletBalance
                };
                _walletDAL.Create(wallet);
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
                _walletDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public WalletDTO Get(int id)
        {
            WalletDTO walletDTO = new WalletDTO();
            try
            {
                var wallet = _walletDAL.Get(id);
                walletDTO.WalletID = wallet.WalletID;
                walletDTO.UserID = wallet.UserID;
                walletDTO.WalletBalance = wallet.WalletBalance;
                return walletDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<WalletDTO> GetAll()
        {
            List<WalletDTO> walletDTOs = new List<WalletDTO>();
            var walletsDAL = _walletDAL.GetAll();
            foreach (var wallet in walletsDAL)
            {
                WalletDTO walletDTO = new WalletDTO();
                walletDTO.WalletID = wallet.WalletID;
                walletDTO.UserID = wallet.UserID;
                walletDTO.WalletBalance = wallet.WalletBalance;
                walletDTOs.Add(walletDTO);
            }
            return walletDTOs;
        }

        public WalletDTO ReadWalletbyUserID(int UserID)
        {
            WalletDTO walletDTO = new WalletDTO();
            try
            {
                var wallet = _walletDAL.ReadWalletbyUserID(UserID);
                walletDTO.WalletID = wallet.WalletID;
                walletDTO.UserID = wallet.UserID;
                walletDTO.WalletBalance = wallet.WalletBalance;
                return walletDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(WalletDTO entity)
        {
            try
            {
                var wallet = new Wallet
                {
                    WalletID = entity.WalletID,
                    UserID = entity.UserID,
                    WalletBalance = entity.WalletBalance
                };
                _walletDAL.Update(wallet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateWalletBalance(int UserID, decimal Amount, char OperationFlag)
        {
            try
            {
                _walletDAL.UpdateWalletBalance(UserID, Amount, OperationFlag);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
