using AutoMapper;
using UtangQApp_API_BLL.DTOs.Users;
using UtangQApp_API_BLL.Interfaces.User;
using UtangQApp_Data.Interfaces.Users;
using UtangQApp_Domain.Users;

namespace UtangQApp_API_BLL.BLLs.Users
{
    public class BillBLL : IBillBLL
    {
        private readonly IBill _billData;
        private readonly IMapper _mapper;

        public BillBLL(IBill billData, IMapper mapper)
        {
            _billData = billData;
            _mapper = mapper;
        }

        public async Task<decimal> CalculateTotalUnassignedBillAmount(int UserId)
        {
            var result = await _billData.CalculateTotalUnassignedBillAmount(UserId);
            return result;
        }

        public async Task<bool> Create(BillCreateDTO entity)
        {
            var billDomain = _mapper.Map<Bill>(entity);
            var result = await _billData.Create(billDomain);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _billData.Delete(id);
            return result;
        }

        public async Task<BillDTO> Get(int id)
        {
            var bill = await _billData.Get(id);
            var billDTO = _mapper.Map<BillDTO>(bill);
            return billDTO;
        }

        public async Task<IEnumerable<BillDTO>> GetAll()
        {
            var bills = await _billData.GetAll();
            var billsDTO = _mapper.Map<IEnumerable<BillDTO>>(bills);
            return billsDTO;
        }

        public async Task<decimal> GetTotalBillAmountAcceptedProcedure(int RecipientUserID)
        {
            var result = await _billData.GetTotalBillAmountAcceptedProcedure(RecipientUserID);
            return result;
        }

        public async Task<decimal> GetTotalBillAmountAwaitingProcedure(int RecipientUserID)
        {
            var result = await _billData.GetTotalBillAmountAwaitingProcedure(RecipientUserID);
            return result;
        }

        public async Task<decimal> GetTotalBillAmountCreatedAcceptedProcedure(int UserId)
        {
            var result = await _billData.GetTotalBillAmountCreatedAcceptedProcedure(UserId);
            return result;
        }

        public async Task<decimal> GetTotalBillAmountCreatedAwaitingProcedure(int UserId)
        {
            var result = await _billData.GetTotalBillAmountCreatedAwaitingProcedure(UserId);
            return result;
        }

        public async Task<decimal> GetTotalBillAmountCreatedPaidProcedure(int UserId)
        {
            var result = await _billData.GetTotalBillAmountCreatedPaidProcedure(UserId);
            return result;
        }

        public async Task<decimal> GetTotalBillAmountCreatedPendingProcedure(int UserId)
        {
            var result = await _billData.GetTotalBillAmountCreatedPendingProcedure(UserId);
            return result;
        }

        public async Task<decimal> GetTotalBillAmountCreatedProcedure(int UserId)
        {
            var result = await _billData.GetTotalBillAmountCreatedProcedure(UserId);
            return result;
        }

        public async Task<decimal> GetTotalBillAmountCreatedRejectedProcedure(int UserId)
        {
            var result = await _billData.GetTotalBillAmountCreatedRejectedProcedure(UserId);
            return result;
        }

        public async Task<decimal> GetTotalBillAmountPaidProcedure(int RecipientUserID)
        {
            var result = await _billData.GetTotalBillAmountPaidProcedure(RecipientUserID);
            return result;
        }

        public async Task<decimal> GetTotalPendingAmountOwedProcedure(int RecipientUserID)
        {
            var result = await _billData.GetTotalPendingAmountOwedProcedure(RecipientUserID);
            return result;
        }

        public async Task<IEnumerable<BillDTO>> ReadUserBills(int UserId)
        {
            var bills = await _billData.ReadUserBills(UserId);
            var billsDTO = _mapper.Map<IEnumerable<BillDTO>>(bills);
            return billsDTO;
        }

        public Task<bool> Update(BillDTO entity)
        {
            var billDomain = _mapper.Map<Bill>(entity);
            var result = _billData.Update(billDomain);
            return result;
        }
    }
}
