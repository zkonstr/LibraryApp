using Contracts;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        //public IActionResult GetBooks()
        //{
        //    var books = _service.BookService.GetAllBooks(trackChanges: false);
        //    return Ok(books);
        //}

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
