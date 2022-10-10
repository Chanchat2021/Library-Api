using Microsoft.AspNetCore.Mvc;
using NeuLibrary.Application.DTO;
using NeuLibrary.Application.Services.Interfaces;

namespace NeuLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolePermissionController : ControllerBase
    {
        private readonly IUserRolePermissionService userRolePermissionService;
        public UserRolePermissionController(IUserRolePermissionService userRolePermissionService)
        {
            this.userRolePermissionService = userRolePermissionService;
        }
        [HttpPost]
        public async Task<IActionResult> AddAdmin(int userId)
        {
            var result = await userRolePermissionService.AddAdmin(userId);
            return StatusCode(201, result);
        }
        [Route("verify/{userId}")]
        [HttpGet]
        public async Task<IActionResult> VerifyAdmin(int userId)
        {
            var result = await userRolePermissionService.VerifyAdmin(userId);
            return StatusCode(201, result);
        }

        [HttpGet("Admins")]
        public async Task<IActionResult> GetAllAdmins()
        {
            var result = await userRolePermissionService.GetAllAdmins();
            return StatusCode(201, result);
        }

        [HttpGet("NonAdmins")]
        public async Task<IActionResult> GetAllNonAdmins()
        {
            var result = await userRolePermissionService.GetAllNonAdmins();
            return StatusCode(201, result);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAdmin(int id)
        {
            var response = await userRolePermissionService.RemoveAdmin(id);
            return Ok(response);
        }
    }
}
