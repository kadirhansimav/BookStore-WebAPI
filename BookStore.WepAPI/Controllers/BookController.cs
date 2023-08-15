
using BookStore.Entities.Models;
using BookStore.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public BookController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _serviceManager.BookService.GetAllBooksAsync(false);
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneBook([FromRoute]int id)
        {
            var book = await _serviceManager.BookService.GetOneBookByIdAsync(id,false);
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOneBook([FromBody]Book book)
        {
            if(book is null)
            {
                return BadRequest();
            }
            await _serviceManager.BookService.CreateOneBookAsync(book);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneBook([FromRoute] int id)
        {
            await _serviceManager.BookService.DeleteOneBookAsync(id,true);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOneBook([FromRoute] int id, [FromBody] Book book)
        {
            if(book is null)
            {
                return BadRequest();
            }
            await _serviceManager.BookService.UpdateOneBookAsync(id, book, true);
            return Ok();
        }
    }
}
