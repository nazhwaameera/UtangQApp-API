using UtangQApp_API_BLL.DTOs.Transactions;

namespace UtangQApp_API_BLL.Interfaces.Transaction
{
    public interface IBillStatusBLL : ICrudBLL<BillStatusDTO>
    {
        Task<bool> Create(BillStatusCreateDTO entity); 
    }
}
