using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UtangQApp_API_BLL.DTOs.Users;
using UtangQApp_API_BLL.Interfaces.User;

namespace UtangQApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletsController : ControllerBase
    {
        private readonly IWalletBLL _walletBLL;
        public WalletsController(IWalletBLL walletBLL)
        {
            _walletBLL = walletBLL;
        }

        [HttpPost]
        public async Task<IActionResult> Create(WalletCreateDTO entity)
        {
            try
            {
                var result = await _walletBLL.Create(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error creating wallet: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _walletBLL.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error deleting wallet: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var wallet = await _walletBLL.Get(id);
                if (wallet == null)
                {
                    return NotFound();
                }
                return Ok(wallet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error getting wallet: " + ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var wallets = await _walletBLL.GetAll();
                return Ok(wallets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error getting all wallets: " + ex.Message);
            }
        }

        [HttpGet("user/{userID}")]
        public async Task<IActionResult> ReadWalletByUserID(int userID)
        {
            try
            {
                var wallet = await _walletBLL.ReadWalletbyUserID(userID);
                if (wallet == null)
                {
                    return NotFound();
                }
                return Ok(wallet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error reading wallet by user ID: " + ex.Message);
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateWallet(WalletDTO entity)
        {
            try
            { 
                var result = await _walletBLL.Update(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error updating wallet: " + ex.Message);
            }
        }

        [HttpPut("balance")]
        public async Task<IActionResult> UpdateWalletBalance(WalletBalanceDTO entity)
        {
            try
            {
                var result = await _walletBLL.UpdateWalletBalance(entity.UserID, entity.Amount, entity.OperationFlag);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error updating wallet balance: " + ex.Message);
            }
        }



    }
}
