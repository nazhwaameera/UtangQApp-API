using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UtangQApp_API_BLL.Interfaces.User;

namespace UtangQApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendshipsController : ControllerBase
    {
        private readonly IFriendshipBLL _friendshipBLL;

        public FriendshipsController(IFriendshipBLL friendshipBLL)
        {
            _friendshipBLL = friendshipBLL;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFriendship(int userId)
        {
            try
            {
                bool result = await _friendshipBLL.CreateFriendship(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var friendshipDTO = await _friendshipBLL.Get(id);
                if (friendshipDTO == null)
                {
                    return NotFound();
                }
                return Ok(friendshipDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var results = await _friendshipBLL.GetAll();
            return Ok(results);
        }

        [HttpGet("user/{userID}")]
        public async Task<IActionResult> GetByUserID(int userID)
        {
            try
            {
                var result = await _friendshipBLL.GetByUserID(userID);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
