using DnDRoom.Models;
using DnDRoom.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DnDRoom.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountControllers : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountControllers(
            IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet("test")]
        public string Test()
        {
            return "test";
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _userService.Create(register);
        }

        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _userService.Login(loginRequest);
        }
    }
}