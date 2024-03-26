using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UtangQApp_API_BLL.DTOs.Transactions;
using UtangQApp_API_BLL.Interfaces.Transaction;

namespace UtangQApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillRecipientsController : ControllerBase
    {
        private readonly IBillRecipientBLL _billRecipientBLL;
        public BillRecipientsController(IBillRecipientBLL billRecipientBLL)
        {
            _billRecipientBLL = billRecipientBLL;
        }

        [HttpPost]
        public async Task<IActionResult> Create(BillRecipientCreateDTO entity)
        {
            var result = await _billRecipientBLL.Create(entity);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _billRecipientBLL.Delete(id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _billRecipientBLL.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var results = await _billRecipientBLL.GetAll();
            return Ok(results);
        }

        [HttpGet("bill/{billId}/recipients")]
        public async Task<IActionResult> GetBillRecipientsByBillID(int billId)
        {
            var results = await _billRecipientBLL.GetBillRecipientsByBillID(billId);
            if(results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpPost("bill/recipients/handle")]
        public async Task<IActionResult> HandleIncomingBillRecipient(BillRecipientRequestDTO entity)
        {
            var result = await _billRecipientBLL.HandleIncomingBillRecipient(entity.BillRecipientID, entity.NewStatusID);
            return Ok(result);
        }

        [HttpGet("bill/recipients/user/{recipientUserID}")]
        public async Task<IActionResult> ReadBillRecipientByRecipientUserID(int recipientUserID)
        {
            var results = await _billRecipientBLL.ReadBillRecipientByRecipientUserID(recipientUserID);
            if(results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpGet("bill/recipients-desc/user/{recipientUserID}")]
        public async Task<IActionResult> ReadBillRecipientByRecipientUserIDWithDescription(int recipientUserID)
        {
            var results = await _billRecipientBLL.ReadBillRecipientByRecipientUserIDWithDescription(recipientUserID);
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpGet("total-bill-recipient-amount/{billID}")]
        public async Task<IActionResult> TotalBillRecipientAmountByBillID(int billID)
        {
            var result = await _billRecipientBLL.TotalBillRecipientAmountByBillID(billID);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(BillRecipientDTO entity)
        {
            var result = await _billRecipientBLL.Update(entity);
            return Ok(result);
        }

        [HttpPut("update-payment-status")]
        public async Task<IActionResult> UpdateBillRecipientPaymentStatus(BillRecipientPaymentDTO entity)
        {
            var result = await _billRecipientBLL.UpdateBillRecipientPaymentStatus(entity.BillRecipientID, entity.NewStatusID);
            return Ok(result);
        }
    }
}
