using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UtangQApp_API_BLL.Interfaces.User;

namespace UtangQApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendshipStatusController : ControllerBase
    {
        private readonly IFriendshipStatusBLL _friendshipStatusBLL;
        public FriendshipStatusController(IFriendshipStatusBLL friendshipStatusBLL)
        {
            _friendshipStatusBLL = friendshipStatusBLL;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var friendshipStatus = await _friendshipStatusBLL.Get(id);
                if (friendshipStatus == null)
                {
                    return NotFound();
                }
                return Ok(friendshipStatus);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error getting friendship status: " + ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var friendshipStatuses = await _friendshipStatusBLL.GetAll();
                return Ok(friendshipStatuses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error getting all friendship statuses: " + ex.Message);
            }
        }
    }
}
