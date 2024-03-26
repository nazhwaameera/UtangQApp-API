using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UtangQApp_API.Helpers;
using UtangQApp_API_BLL.DTOs.Users;
using UtangQApp_API_BLL.Interfaces.User;

namespace UtangQApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserBLL _userBLL;
        private readonly AppSettings _appSettings;

        public UsersController(IUserBLL userBLL, IOptions<AppSettings> appSettings)
        {
            _userBLL = userBLL;
            _appSettings = appSettings.Value;
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDTO entity)
        {
            var result = await _userBLL.Create(entity);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userBLL.Delete(id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userBLL.Get(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var results = await _userBLL.GetAll();
            return results;
        }

        [HttpGet("username/{username}")]
        public async Task<IActionResult> GetByUsername(string username)
        {
            var user = await _userBLL.GetByUsername(username);
            return Ok(user);
        }

        [HttpGet("friends/{friendshipId}")]
        public async Task<IActionResult> GetFriends(int friendshipId)
        {
            var friends = await _userBLL.GetFriends(friendshipId);
            return Ok(friends);
        }

        [HttpGet("nonfriends/{friendshipId}")]
        public async Task<IActionResult> GetNonFriends(int friendshipId)
        {
            var nonFriends = await _userBLL.GetNonFriends(friendshipId);
            return Ok(nonFriends);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(UserLoginDTO entity)
        {
            try
            {
                var user = await _userBLL.LoginUser(entity.Username, entity.UserPassword);
                if (user == null)
                {
                    return Unauthorized();
                }
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, entity.Username));
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials =
                        new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                var tokenDTO = new LoginTokenDTO
                {
                    UserID = user.UserID,
                    Username = entity.Username,
                    Token = tokenHandler.WriteToken(token)
                };
                return Ok(tokenDTO);

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UserDTO userDTO)
        {
            var result = await _userBLL.Update(userDTO);
            return Ok(result);
        }
    }
}
