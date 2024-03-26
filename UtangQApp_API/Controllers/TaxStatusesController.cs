using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UtangQApp_API_BLL.DTOs.Transactions;
using UtangQApp_API_BLL.Interfaces.Transaction;

namespace UtangQApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxStatusesController : ControllerBase
    {
        private readonly ITaxStatusBLL _taxStatusBLL;
        public TaxStatusesController(ITaxStatusBLL taxStatusBLL)
        {
            _taxStatusBLL = taxStatusBLL;
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaxStatusCreateDTO entity)
        {
            var result = await _taxStatusBLL.Create(entity);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _taxStatusBLL.Delete(id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _taxStatusBLL.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var results = await _taxStatusBLL.GetAll();
            return Ok(results);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(TaxStatusDTO entity)
        {
            var result = await _taxStatusBLL.Update(entity);
            return Ok(result);
        }
    }
}
