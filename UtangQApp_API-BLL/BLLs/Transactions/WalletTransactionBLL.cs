using AutoMapper;
using UtangQApp_API_BLL.DTOs.Transactions;
using UtangQApp_API_BLL.Interfaces.Transaction;
using UtangQApp_Data.Interfaces.Transactions;
using UtangQApp_Domain.Transactions;

namespace UtangQApp_API_BLL.BLLs.Transactions
{
    public class WalletTransactionBLL : IWalletTransactionBLL
    {
        private readonly IWalletTransaction _walletTransactionData;
        private readonly IMapper _mapper;

        public WalletTransactionBLL(IWalletTransaction walletTransactionData, IMapper mapper)
        {
            _walletTransactionData = walletTransactionData;
            _mapper = mapper;
        }

        public async Task<bool> Create(WalletTransactionCreateDTO entity)
        {
            var walletTransactionDomain = _mapper.Map<WalletTransaction>(entity);
            var result = await _walletTransactionData.Create(walletTransactionDomain);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _walletTransactionData.Delete(id);
            return result;
        }

        public async Task<WalletTransactionDTO> Get(int id)
        {
            var walletTransaction = await _walletTransactionData.Get(id);
            var walletTransactionDTO = _mapper.Map<WalletTransactionDTO>(walletTransaction);
            return walletTransactionDTO;
        }

        public async Task<IEnumerable<WalletTransactionDTO>> GetAll()
        {
            var walletTransactions = await _walletTransactionData.GetAll();
            var walletTransactionsDTO = _mapper.Map<IEnumerable<WalletTransactionDTO>>(walletTransactions);
            return walletTransactionsDTO;
        }

        public async Task<IEnumerable<WalletTransactionDTO>> ReadWalletTransactionbyUserID(int UserID)
        {
            var walletTransactions = await _walletTransactionData.ReadWalletTransactionbyUserID(UserID);
            var walletTransactionsDTO = _mapper.Map<IEnumerable<WalletTransactionDTO>>(walletTransactions);
            return walletTransactionsDTO;
        }

        public async Task<bool> Update(WalletTransactionDTO entity)
        {
            var walletTransactionDomain = _mapper.Map<WalletTransaction>(entity);
            var result = await _walletTransactionData.Update(walletTransactionDomain);
            return result;
        }
    }
}
