using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UtangQApp_API_BLL.DTOs.Users;
using UtangQApp_API_BLL.Interfaces.User;

namespace UtangQApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendshipListsController : ControllerBase
    {
        private readonly IFriendshipListBLL _friendshipListBLL;

        public FriendshipListsController(IFriendshipListBLL friendshipListBLL)
        {
            _friendshipListBLL = friendshipListBLL;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFriendRequest(FriendRequestDTO entity)
        {
            var result = await _friendshipListBLL.CreateFriendRequest(entity.FriendshipID, entity.SenderUserID, entity.ReceiverUserID);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _friendshipListBLL.Get(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IEnumerable<FriendshipListDTO>> GetAll()
        {
            var results = await _friendshipListBLL.GetAll();
            return results;
        }

        [HttpGet("userId/{userId}")]
        public async Task<IActionResult> GetByUserID(int userId)
        {
            var result = await _friendshipListBLL.GetByUserID(userId);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("pending-friend-requests/{receiverUserId}")]
        public async Task<IActionResult> GetPendingFriendRequests(int receiverUserId)
        {
            try
            {
                var pendingFriendRequests = await _friendshipListBLL.GetPendingFriendRequestsByReceiverUserID(receiverUserId);
                return Ok(pendingFriendRequests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error getting pending friend requests: " + ex.Message);
            }
        }

        [HttpPost("handle-friend-request")]
        public async Task<IActionResult> HandleFriendRequest(HandleFriendRequestDTO entity)
        {
            try
            {
                bool success = await _friendshipListBLL.HandleFriendRequest(entity.FriendshipListID, entity.FriendshipStatusID);
                if (success)
                {
                    return Ok("Friend request handled successfully.");
                }
                else
                {
                    return BadRequest("Failed to handle friend request.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error handling friend request: " + ex.Message);
            }
        }


    }
}
