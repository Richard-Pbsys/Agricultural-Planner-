using Auth0.ManagementApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VHS.Services.Auth;
using VHS.Services.Auth.DTO;

namespace VHS.WebAPI.Controllers.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous] // Temp allow
    public class UserController : ControllerBase
    {
        private readonly IManagementApiClient _managementApiClient;
        private readonly IUserService _userService;

        public UserController(IManagementApiClient managementApiClient, IUserService userService)
        {
            _managementApiClient = managementApiClient;
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO userDto)
        {
            try
            {
                var createdUser = await _userService.CreateUserAsync(userDto);
                return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDTO userDto)
        {
            try
            {
                var updatedUser = await _userService.UpdateUserAsync(userDto);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
