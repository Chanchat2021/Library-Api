using Microsoft.AspNetCore.Mvc;
using NeuLibrary.Application.DTO;
using NeuLibrary.Application.Services.Interfaces;

namespace NeuLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReserveController : ControllerBase
    {
        private readonly IReserveService reserveService;
        public ReserveController(IReserveService reserveService)
        {
            this.reserveService = reserveService;
        }
        [HttpPost]
        public async Task<IActionResult> ReserveBook(ReserveBookDTO reserve)
        {
            var result = await reserveService.ReserveBook(reserve);
            return StatusCode(201, result);
        }
        [HttpGet]
        public async Task<IActionResult> GetReserveBooks()
        {
            var users = await reserveService.GetReserveBooks();
            return Ok(users);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await reserveService.ReturnBook(id);
            return Ok(response);
        }
    }
}
