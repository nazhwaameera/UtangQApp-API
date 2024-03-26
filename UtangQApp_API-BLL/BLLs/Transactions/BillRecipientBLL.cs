using AutoMapper;
using UtangQApp_API_BLL.DTOs.Transactions;
using UtangQApp_API_BLL.Interfaces.Transaction;
using UtangQApp_Data.Interfaces.Transactions;
using UtangQApp_Domain.Transactions;

namespace UtangQApp_API_BLL.BLLs.Transactions
{
    public class BillRecipientBLL : IBillRecipientBLL
    {
        private readonly IBillRecipient _billRecipientData;
        private readonly IMapper _mapper;

        public BillRecipientBLL(IBillRecipient billRecipientData, IMapper mapper)
        {
            _billRecipientData = billRecipientData;
            _mapper = mapper;
        }

        public async Task<bool> Create(BillRecipientCreateDTO entity)
        {
            var billRecipientDomain = _mapper.Map<BillRecipientCreate>(entity);
            var result = await _billRecipientData.Create(billRecipientDomain);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _billRecipientData.Delete(id);
            return result;
        }

        public async Task<BillRecipientDTO> Get(int id)
        {
            var billRecipient = await _billRecipientData.Get(id);
            var billRecipientDTO = _mapper.Map<BillRecipientDTO>(billRecipient);
            return billRecipientDTO;
        }

        public async Task<IEnumerable<BillRecipientDTO>> GetAll()
        {
            var billRecipients = await _billRecipientData.GetAll();
            var billRecipientsDTO = _mapper.Map<IEnumerable<BillRecipientDTO>>(billRecipients);
            return billRecipientsDTO;
        }

        public async Task<IEnumerable<BillRecipientDTO>> GetBillRecipientsByBillID(int BillID)
        {
            var billRecipients = await _billRecipientData.GetBillRecipientsByBillID(BillID);
            var billRecipientsDTO = _mapper.Map<IEnumerable<BillRecipientDTO>>(billRecipients);
            return billRecipientsDTO;
        }

        public async Task<bool> HandleIncomingBillRecipient(int BillRecipientID, int NewStatusID)
        {
            var result = await _billRecipientData.HandleIncomingBillRecipient(BillRecipientID, NewStatusID);
            return result;
        }

        public async Task<IEnumerable<BillRecipientDTO>> ReadBillRecipientByRecipientUserID(int RecipientUserID)
        {
            var billRecipients = await _billRecipientData.ReadBillRecipientByRecipientUserID(RecipientUserID);
            var billRecipientsDTO = _mapper.Map<IEnumerable<BillRecipientDTO>>(billRecipients);
            return billRecipientsDTO;
        }

        public async Task<IEnumerable<BillRecipientWithDescDTO>> ReadBillRecipientByRecipientUserIDWithDescription(int RecipientUserID)
        {
            var billRecipients = await _billRecipientData.ReadBillRecipientByRecipientUserIDWithDescription(RecipientUserID);
            var billRecipientsDTO = _mapper.Map<IEnumerable<BillRecipientWithDescDTO>>(billRecipients);
            return billRecipientsDTO;
        }

        public async Task<decimal> TotalBillRecipientAmountByBillID(int BillID)
        {
            var result = await _billRecipientData.TotalBillRecipientAmountByBillID(BillID);
            return result;
        }

        public async Task<bool> Update(BillRecipientDTO entity)
        {
            var billRecipientDomain = _mapper.Map<BillRecipient>(entity);
            var result = await _billRecipientData.Update(billRecipientDomain);
            return result;
        }

        public async Task<bool> UpdateBillRecipientPaymentStatus(int BillRecipientID, int NewStatusID)
        {
            var result = await _billRecipientData.UpdateBillRecipientPaymentStatus(BillRecipientID, NewStatusID);
            return result;
        }
    }
}
