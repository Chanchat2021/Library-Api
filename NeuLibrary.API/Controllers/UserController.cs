using Microsoft.AspNetCore.Mvc;
using NeuLibrary.Application.DTO;
using NeuLibrary.Application.Services.Interfaces;

namespace NeuLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDTO user)
        {
            var result = await userService.CreateUser(user);
            return StatusCode(201, result);
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await userService.GetUsers();
            return Ok(users);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginCheck(UserDTO loginInfo)
        {
            var result = await userService.LoginCheck(loginInfo.Email, loginInfo.Password);
            return Ok(result);
        }
    }
}
