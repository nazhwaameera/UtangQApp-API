using AutoMapper;
using UtangQApp_API_BLL.DTOs.Transactions;
using UtangQApp_API_BLL.Interfaces.Transaction;
using UtangQApp_Data.Interfaces.Transactions;
using UtangQApp_Domain.Transactions;

namespace UtangQApp_API_BLL.BLLs.Transactions
{
    public class PaymentReceiptBLL : IPaymentReceiptBLL
    {
        private readonly IPaymentReceipt _paymentReceiptData;
        private readonly IMapper _mapper;

        public PaymentReceiptBLL(IPaymentReceipt paymentReceiptData, IMapper mapper)
        {
            _paymentReceiptData = paymentReceiptData;
            _mapper = mapper;
        }

        public async Task<bool> Create(PaymentReceiptCreateDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreatePaymentReceiptAndUpdateStatus(int BillRecipientID, string PaymentReceiptURL)
        {
            var result = await _paymentReceiptData.CreatePaymentReceiptAndUpdateStatus(BillRecipientID, PaymentReceiptURL);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _paymentReceiptData.Delete(id);
            return result;
        }

        public async Task<PaymentReceiptDTO> Get(int id)
        {
            var paymentReceipt = await _paymentReceiptData.Get(id);
            var paymentReceiptDTO = _mapper.Map<PaymentReceiptDTO>(paymentReceipt);
            return paymentReceiptDTO;
        }

        public async Task<IEnumerable<PaymentReceiptDTO>> GetAll()
        {
            var paymentReceipts = await _paymentReceiptData.GetAll();
            var paymentReceiptsDTO = _mapper.Map<IEnumerable<PaymentReceiptDTO>>(paymentReceipts);
            return paymentReceiptsDTO;
        }

        public async Task<PaymentReceiptDTO> ReadPaymentReceiptbyBillRecipientID(int BillRecipientID)
        {
            var paymentReceipt = await _paymentReceiptData.ReadPaymentReceiptbyBillRecipientID(BillRecipientID);
            var paymentReceiptDTO = _mapper.Map<PaymentReceiptDTO>(paymentReceipt);
            return paymentReceiptDTO;
        }

        public async Task<IEnumerable<PaymentReceiptDTO>> ReadPaymentReceiptsByBillCreator(int CreatorUserID)
        {
            var paymentReceipts = await _paymentReceiptData.ReadPaymentReceiptsByBillCreator(CreatorUserID);
            var paymentReceiptsDTO = _mapper.Map<IEnumerable<PaymentReceiptDTO>>(paymentReceipts);
            return paymentReceiptsDTO;
        }

        public async Task<bool> Update(PaymentReceiptDTO entity)
        {
            var paymentReceiptDomain = _mapper.Map<PaymentReceipt>(entity);
            var result = await _paymentReceiptData.Update(paymentReceiptDomain);
            return result;
        }

        public async Task<bool> UpdateBillRecipientPaymentStatus(int BillRecipientID, int NewStatusID)
        {
            var result = await _paymentReceiptData.UpdateBillRecipientPaymentStatus(BillRecipientID, NewStatusID);
            return result;
        }
    }
}
