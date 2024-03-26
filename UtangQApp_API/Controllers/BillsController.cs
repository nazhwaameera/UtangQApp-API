using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UtangQApp_API_BLL.DTOs.Users;
using UtangQApp_API_BLL.Interfaces.User;

namespace UtangQApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly IBillBLL _billBLL;
        public BillsController(IBillBLL billBLL)
        {
            _billBLL = billBLL;
        }

        [HttpGet("totalUnassignedBillAmount/{UserId}")]
        public async Task<ActionResult<decimal>> CalculateTotalUnassignedBillAmount(int UserId)
        {
            var totalAmount = await _billBLL.CalculateTotalUnassignedBillAmount(UserId);
            return Ok(totalAmount);
        }

        [HttpPost]
        public async Task<ActionResult> Create(BillCreateDTO billCreateDTO)
        {
            var result = await _billBLL.Create(billCreateDTO);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _billBLL.Delete(id);
            if (result)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BillDTO>> Get(int id)
        {
            var bill = await _billBLL.Get(id);
            if (bill == null)
            {
                return NotFound();
            }
            return bill;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillDTO>>> GetAll()
        {
            var bills = await _billBLL.GetAll();
            return Ok(bills);
        }

        [HttpGet("totalBillAmountAccepted/{RecipientUserID}")]
        public async Task<ActionResult<decimal>> GetTotalBillAmountAcceptedProcedure(int RecipientUserID)
        {
            var totalAmount = await _billBLL.GetTotalBillAmountAcceptedProcedure(RecipientUserID);
            return Ok(totalAmount);
        }

        [HttpGet("totalBillAmountAwaiting/{RecipientUserID}")]
        public async Task<ActionResult<decimal>> GetTotalBillAmountAwaitingProcedure(int RecipientUserID)
        {
            var totalAmount = await _billBLL.GetTotalBillAmountAwaitingProcedure(RecipientUserID);
            return Ok(totalAmount);
        }

        [HttpGet("totalBillAmountCreatedAccepted/{UserId}")]
        public async Task<ActionResult<decimal>> GetTotalBillAmountCreatedAcceptedProcedure(int UserId)
        {
            var totalAmount = await _billBLL.GetTotalBillAmountCreatedAcceptedProcedure(UserId);
            return Ok(totalAmount);
        }

        [HttpGet("totalBillAmountCreatedAwaiting/{UserId}")]
        public async Task<ActionResult<decimal>> GetTotalBillAmountCreatedAwaitingProcedure(int UserId)
        {
            var totalAmount = await _billBLL.GetTotalBillAmountCreatedAwaitingProcedure(UserId);
            return Ok(totalAmount);
        }

        [HttpGet("totalBillAmountCreatedPaid/{UserId}")]
        public async Task<ActionResult<decimal>> GetTotalBillAmountCreatedPaidProcedure(int UserId)
        {
            var totalAmount = await _billBLL.GetTotalBillAmountCreatedPaidProcedure(UserId);
            return Ok(totalAmount);
        }

        [HttpGet("totalBillAmountCreatedPending/{UserId}")]
        public async Task<ActionResult<decimal>> GetTotalBillAmountCreatedPendingProcedure(int UserId)
        {
            var totalAmount = await _billBLL.GetTotalBillAmountCreatedPendingProcedure(UserId);
            return Ok(totalAmount);
        }

        [HttpGet("totalBillAmountCreated/{UserId}")]
        public async Task<ActionResult<decimal>> GetTotalBillAmountCreatedProcedure(int UserId)
        {
            var totalAmount = await _billBLL.GetTotalBillAmountCreatedProcedure(UserId);
            return Ok(totalAmount);
        }

        [HttpGet("totalBillAmountCreatedRejected/{UserId}")]
        public async Task<ActionResult<decimal>> GetTotalBillAmountCreatedRejectedProcedure(int UserId)
        {
            var totalAmount = await _billBLL.GetTotalBillAmountCreatedRejectedProcedure(UserId);
            return Ok(totalAmount);
        }

        [HttpGet("totalBillAmountPaid/{RecipientUserID}")]
        public async Task<ActionResult<decimal>> GetTotalBillAmountPaidProcedure(int RecipientUserID)
        {
            var totalAmount = await _billBLL.GetTotalBillAmountPaidProcedure(RecipientUserID);
            return Ok(totalAmount);
        }

        [HttpGet("totalBillAmountPending/{RecipientUserID}")]
        public async Task<ActionResult<decimal>> GetTotalPendingAmountOwedProcedure(int RecipientUserID)
        {
            var totalAmount = await _billBLL.GetTotalPendingAmountOwedProcedure(RecipientUserID);
            return Ok(totalAmount);
        }

        [HttpGet("bills/{userId}")]
        public async Task<ActionResult<IEnumerable<BillDTO>>> ReadUserBills(int userId)
        {
            var bills = await _billBLL.ReadUserBills(userId);
            return Ok(bills);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(BillDTO billDTO)
        {
            var result = await _billBLL.Update(billDTO);
            if (result)
            {
                return Ok(result); // Update successful
            }
            return BadRequest(); // Update failed
        }

    }
}
