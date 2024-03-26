using AutoMapper;
using UtangQApp_API_BLL.DTOs.Transactions;
using UtangQApp_API_BLL.Interfaces.Transaction;
using UtangQApp_Data.Interfaces.Transactions;
using UtangQApp_Domain.Transactions;

namespace UtangQApp_API_BLL.BLLs.Transactions
{
    public class TaxStatusBLL : ITaxStatusBLL
    {
        private readonly ITaxStatus _taxStatusData;
        private readonly IMapper _mapper;

        public TaxStatusBLL(ITaxStatus taxStatusData, IMapper mapper)
        {
            _taxStatusData = taxStatusData;
            _mapper = mapper;
        }

        public async Task<bool> Create(TaxStatusCreateDTO entity)
        {
            var taxStatusDomain = _mapper.Map<TaxStatus>(entity);
            var result = await _taxStatusData.Create(taxStatusDomain);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _taxStatusData.Delete(id);
            return result;
        }

        public async Task<TaxStatusDTO> Get(int id)
        {
            var taxStatus = await _taxStatusData.Get(id);
            var taxStatusDTO = _mapper.Map<TaxStatusDTO>(taxStatus);
            return taxStatusDTO;
        }

        public async Task<IEnumerable<TaxStatusDTO>> GetAll()
        {
            var taxStatuses = await _taxStatusData.GetAll();
            var taxStatusesDTO = _mapper.Map<IEnumerable<TaxStatusDTO>>(taxStatuses);
            return taxStatusesDTO;
        }

        public async Task<bool> Update(TaxStatusDTO entity)
        {
            var taxStatusDomain = _mapper.Map<TaxStatus>(entity);
            var result = await _taxStatusData.Update(taxStatusDomain);
            return result;
        }
    }
}
