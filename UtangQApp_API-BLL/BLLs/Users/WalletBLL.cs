using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using UtangQApp_API_BLL.DTOs.Users;
using UtangQApp_API_BLL.Interfaces.User;
using UtangQApp_Data.Interfaces.Users;
using UtangQApp_Domain.Users;

namespace UtangQApp_API_BLL.BLLs.Users
{
    public class WalletBLL : IWalletBLL
    {
        private readonly IWallet _walletData;
        private readonly IMapper _mapper;

        public WalletBLL(IWallet walletData, IMapper mapper)
        {
            _walletData = walletData;
            _mapper = mapper;
        }

        public async Task<bool> Create(WalletCreateDTO entity)
        {
            var walletDomain = _mapper.Map<Wallet>(entity);
            var result = await _walletData.Create(walletDomain);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _walletData.Delete(id); 
            return result;
        }

        public async Task<WalletDTO> Get(int id)
        {
            var wallet = await _walletData.Get(id);
            var walletDTO = _mapper.Map<WalletDTO>(wallet);
            return walletDTO;
        }

        public async Task<IEnumerable<WalletDTO>> GetAll()
        {
            var wallets = await _walletData.GetAll();
            var walletsDTO = _mapper.Map<IEnumerable<WalletDTO>>(wallets);
            return walletsDTO;
        }

        public async Task<WalletDTO> ReadWalletbyUserID(int UserID)
        {
            var wallet = await _walletData.ReadWalletbyUserID(UserID);
            var walletDTO = _mapper.Map<WalletDTO>(wallet);
            return walletDTO;
        }

        public async Task<bool> Update(WalletDTO entity)
        {
            var walletDomain = _mapper.Map<Wallet>(entity);
            var result = await _walletData.Update(walletDomain);
            return result;
        }

        public async Task<bool> UpdateWalletBalance(int UserID, decimal Amount, char OperationFlag)
        {
            var result = await _walletData.UpdateWalletBalance(UserID, Amount, OperationFlag);
            return result;
        }
    }
}
