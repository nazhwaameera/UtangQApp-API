using AutoMapper;
using UtangQApp_API_BLL.DTOs.Transactions;
using UtangQApp_API_BLL.Interfaces.Transaction;
using UtangQApp_Data.Interfaces.Transactions;
using UtangQApp_Domain.Transactions;

namespace UtangQApp_API_BLL.BLLs.Transactions
{
    public class BillStatusBLL : IBillStatusBLL
    {
        private readonly IBillStatus _billStatusData;
        private readonly IMapper _mapper;

        public BillStatusBLL(IBillStatus billStatusData, IMapper mapper)
        {
            _billStatusData = billStatusData;
            _mapper = mapper;
        }

        public async Task<bool> Create(BillStatusCreateDTO entity)
        {
            var billStatusDomain = _mapper.Map<BillStatus>(entity);
            var result = await _billStatusData.Create(billStatusDomain);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _billStatusData.Delete(id);
            return result;
        }

        public async Task<BillStatusDTO> Get(int id)
        {
           var billStatus = await _billStatusData.Get(id);
            var billStatusDTO = _mapper.Map<BillStatusDTO>(billStatus);
            return billStatusDTO;
        }

        public async Task<IEnumerable<BillStatusDTO>> GetAll()
        {
            var billStatuses = await _billStatusData.GetAll();
            var billStatusesDTO = _mapper.Map<IEnumerable<BillStatusDTO>>(billStatuses);
            return billStatusesDTO;
        }

        public async Task<bool> Update(BillStatusDTO entity)
        {
            var billStatusDomain = _mapper.Map<BillStatus>(entity);
            var result = await _billStatusData.Update(billStatusDomain);
            return result;
        }
    }
}
