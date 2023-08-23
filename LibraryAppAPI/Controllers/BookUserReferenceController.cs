using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using Shared.DataTransferObjects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAppAPI.Controllers
{
    [Route("api/bookUserReference")]
    [ApiController]
    public class BookUserReferenceController : ControllerBase
    {
        
        private readonly IServiceManager _service;

        public BookUserReferenceController
            (IServiceManager service)
        {
            _service = service;
        }
        // GET: api/<BookUserReferenceController>
        [HttpGet]
        public async Task<IActionResult> GetBookUserReferences()
        {
            var bookUserReferences = await _service.BookUserReferenceService.GetAllBookUserReferencesAsync(trackChanges: false);
            return Ok(bookUserReferences);
        }

        // GET api/<BookUserReferenceController>/5
        [HttpGet("{id:guid}", Name = "BookUserReferenceById")]
        public async Task<IActionResult> GetBookUserReference(Guid id)
        {
            var bookUserReference = await _service.BookUserReferenceService.GetBookUserReferenceAsync(id, trackChanges: false);
            return Ok(bookUserReference);
        }

        // POST api/<BookUserReferenceController>
        [HttpPost]
        public async Task<IActionResult> CreateBookUserReference([FromBody] BookUserReferenceForCreationDTO bookUserReference)
        {
            if (bookUserReference is null)
                return BadRequest("BookUserReferenceForCreationDto object is null");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            var createdBookUserReference = await _service.BookUserReferenceService.CreateBookUserReferenceAsync(bookUserReference);
            return CreatedAtRoute("BookUserReferenceById", new { id = createdBookUserReference.Id },
            createdBookUserReference);

        }

        // PUT api/<BookUserReferenceController>/5
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateBookUserReference(Guid id, [FromBody] BookUserReferenceForUpdateDTO bookUserReference)
        {
            if (bookUserReference is null)
                return BadRequest("BookUserReferenceForUpdateDto object is null");
            await _service.BookUserReferenceService.UpdateBookUserReferenceAsync(id, bookUserReference, trackChanges: true);
            return NoContent();
        }

        // DELETE api/<BookUserReferenceController>/5
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBookUserReference(Guid id)
        {
            await _service.BookUserReferenceService.DeleteBookUserReferenceAsync(id, trackChanges: false);
            return NoContent();
        }
    }
}
