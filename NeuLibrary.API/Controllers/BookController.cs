using Microsoft.AspNetCore.Mvc;
using NeuLibrary.Application.DTO;
using NeuLibrary.Application.Services.Interfaces;
using NeuLibrary.Domain.Entity;

namespace NeuLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(CreateBookDTO addBook)
        {
            var result = await bookService.AddBook(addBook);
            return StatusCode(201, result);
        }
        [HttpPost("Enlist")]
        public async Task<IActionResult> Update(EnlistBookDTO enlistBookDTO)
        {
            var result = await bookService.EnlistBook(enlistBookDTO.Id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetBook()
        {
            var books = await bookService.GetBook();
            return Ok(books);
        }

        [HttpGet("AvailableBooks")]
        public async Task<IActionResult> GetAllAvailableBooks()
        {
            var books = await bookService.GetAllAvailableBooks();
            return Ok(books);
        }

        [HttpGet("ReservedBooks")]
        public async Task<IActionResult> GetAllReservedBooks()
        {
            var books = await bookService.GetAllReservedBooks();
            return Ok(books);
        }

        [HttpGet("NewBooks")]
        public async Task<IActionResult> GetAllNewBooks()
        {
            var books = await bookService.GetAllNewBooks();
            return Ok(books);
        }
        [HttpGet("Search")]
        public async Task<IEnumerable<Book>> SearchBooks(string search)
        {
            var result = await bookService.SearchBooks( search);
            return result;
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBook(UpdateBookDTO updateBook)
        {
            var result = await bookService.UpdateBook(updateBook);
            return StatusCode(200, result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await bookService.DelistBook(id);
            return Ok(response);
        }
    }
}
