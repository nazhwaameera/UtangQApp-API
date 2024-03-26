using UtangQApp_API_BLL.DTOs.Transactions;

namespace UtangQApp_API_BLL.Interfaces.Transaction
{
    public interface ITaxStatusBLL : ICrudBLL<TaxStatusDTO>
    {
        Task<bool> Create(TaxStatusCreateDTO entity);
    }
}
