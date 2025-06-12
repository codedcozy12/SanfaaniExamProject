using Application.Dtos;
using Application.Interfaces.Auth;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        public UsersController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("login")]
        [SwaggerOperation(Description = "Logs in a user using email and password.")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if(ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userService.LoginAsync(dto);
            if(result.Data == null)
            {
                return BadRequest(result);
            }
            return Ok(new { token = _authService.GenerateJwtToken(result.Data), message = result.Message });
        }

        [HttpGet]
        [SwaggerOperation(Description = "Retrieves all active users.")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userService.GetAllUsersAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Description = "Retrieves a user by their unique ID.")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _userService.GetUserByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("search")]
        [SwaggerOperation(Description = "Searches for users by username or email.")]
        public async Task<IActionResult> Search([FromQuery][Required] string keyword)
        {
            var result = await _userService.SearchUsersAsync(keyword);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Description = "Deactivates a user account (soft delete).")]
        public async Task<IActionResult> Deactivate(Guid id)
        {
            var result = await _userService.DeactivateUserAsync(id);
            return Ok(result);
        }
    }

}
