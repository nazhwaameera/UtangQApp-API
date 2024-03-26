using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UtangQApp_API_BLL.DTOs.Transactions;
using UtangQApp_API_BLL.Interfaces.Transaction;

namespace UtangQApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillStatusesController : ControllerBase
    {
        private readonly IBillStatusBLL _billStatusBLL;

        public BillStatusesController(IBillStatusBLL billStatusBLL)
        {
            _billStatusBLL = billStatusBLL;
        }

        [HttpPost]
        public async Task<IActionResult> Create(BillStatusCreateDTO entity)
        {
            var result = await _billStatusBLL.Create(entity);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _billStatusBLL.Delete(id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _billStatusBLL.Get(id);  
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var results = await _billStatusBLL.GetAll();
            return Ok(results);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(BillStatusDTO entity)
        {
            var result = await _billStatusBLL.Update(entity);
            return Ok(result);
        }
    }
}
