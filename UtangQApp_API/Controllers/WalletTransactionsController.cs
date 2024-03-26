using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UtangQApp_API_BLL.DTOs.Transactions;
using UtangQApp_API_BLL.Interfaces.Transaction;

namespace UtangQApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletTransactionsController : ControllerBase
    {
        private readonly IWalletTransactionBLL _walletTransactionBLL;

        public WalletTransactionsController(IWalletTransactionBLL walletTransactionBLL)
        {
            _walletTransactionBLL = walletTransactionBLL;
        }

        [HttpPost]
        public async Task<IActionResult> Create(WalletTransactionCreateDTO entity)
        {
            var result = await _walletTransactionBLL.Create(entity);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _walletTransactionBLL.Delete(id);    
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _walletTransactionBLL.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var results = await _walletTransactionBLL.GetAll();
            return Ok(results);
        }

        [HttpGet("wallet-transaction/{userId}")]
        public async Task<IActionResult> ReadWalletTransactionbyUserID(int userId)
        {
            var results = await _walletTransactionBLL.ReadWalletTransactionbyUserID(userId);
            if(results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(WalletTransactionDTO entity)
        {
            var result = await _walletTransactionBLL.Update(entity);
            return Ok(result);
        }
    }
}
