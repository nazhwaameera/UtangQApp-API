using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using UtangQApp_API_BLL.DTOs.Transactions;
using UtangQApp_API_BLL.Interfaces.Transaction;
using UtangQApp_Data.DAL.Transactions;

namespace UtangQApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentReceiptsController : ControllerBase
    {
        private readonly IPaymentReceiptBLL _paymentReceiptBLL;
        public PaymentReceiptsController(IPaymentReceiptBLL paymentReceiptBLL)
        {
            _paymentReceiptBLL = paymentReceiptBLL;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePaymentReceiptAndUpdateStatus(PaymentReceiptCreateDTO entity)
        {
            var result = await _paymentReceiptBLL.CreatePaymentReceiptAndUpdateStatus(entity.BillRecipientID, entity.PaymentReceiptURL);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _paymentReceiptBLL.Delete(id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _paymentReceiptBLL.Get(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var results = await _paymentReceiptBLL.GetAll();
            return Ok(results);
        }

        [HttpGet("payment-receipt/{BillRecipientID}")]
        public async Task<IActionResult> ReadPaymentReceiptbyBillRecipientID(int BillRecipientID)
        {
            try
            {
                var paymentReceipt = await _paymentReceiptBLL.ReadPaymentReceiptbyBillRecipientID(BillRecipientID);
                return Ok(paymentReceipt);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error reading payment receipt by BillRecipientID: {ex.Message}");
            }
        }

        [HttpGet("recipient/payment-receipt/{CreatorUserID}")]
        public async Task<IActionResult> ReadPaymentReceiptsByBillCreator(int CreatorUserID)
        {
            try
            {
                var paymentReceipts = await _paymentReceiptBLL.ReadPaymentReceiptsByBillCreator(CreatorUserID);
                return Ok(paymentReceipts);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error reading payment receipts by BillCreator: {ex.Message}");
            }
        }

        [HttpPut("update-status/")]
        public async Task<IActionResult> UpdateBillRecipientPaymentStatus(BillRecipientPaymentDTO entity)
        {
            try
            {
                var result = await _paymentReceiptBLL.UpdateBillRecipientPaymentStatus(entity.BillRecipientID, entity.NewStatusID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating bill recipient payment status: {ex.Message}");
            }
        }
    }
}
