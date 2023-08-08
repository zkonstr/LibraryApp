using Contracts;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using Shared.DataTransferObjects;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LibraryAppAPI.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly IRepositoryManager _repository;

        public BookController
            (IRepositoryManager repository, IServiceManager service)
        {
            _repository = repository;
            _service = service;
        }
        // GET: api/<BookController>
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _service.BookService.GetAllBooksAsync(trackChanges: false);
            return Ok(books);
        }

        // GET api/<BookController>/5
        [HttpGet("{id:guid}", Name = "BookById")]
        public async Task<IActionResult> GetBook(Guid id)
        {
            var book = await _service.BookService.GetBookAsync(id,trackChanges: false);
            return Ok(book);
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookForCreationDTO book)
        {
            if (book is null)
                return BadRequest("BookForCreationDto object is null");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            var createdBook = await _service.BookService.CreateBookAsync(book);
            return CreatedAtRoute("BookById", new { id = createdBook.Id },
            createdBook);

        }

        // PUT api/<BookController>/5
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateBook(Guid id, [FromBody] BookForUpdateDTO book)
        {
            if (book is null)
                return BadRequest("BookForUpdateDto object is null");
            await _service.BookService.UpdateBookAsync(id, book, trackChanges:true);
            return NoContent();
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            await _service.BookService.DeleteBookAsync(id, trackChanges: false);
            return NoContent();
        }
    }
}
