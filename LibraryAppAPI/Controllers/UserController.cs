using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using ServiceContracts;
using Shared.DataTransferObjects;

namespace LibraryAppAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _service;

        public UserController
            ( IServiceManager service)
        {
            _service = service;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _service.UserService.GetAllUsersAsync(trackChanges: false);
            return Ok(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{id:guid}", Name = "UserById")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _service.UserService.GetUserAsync(id, trackChanges: false);
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserForCreationDTO user)
        {
            if (user is null)
                return BadRequest("UserForCreationDto object is null");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            var createdUser = await _service.UserService.CreateUserAsync(user);
            return CreatedAtRoute("UserById", new { id = createdUser.Id },
            createdUser);

        }

        // PUT api/<UserController>/5
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserForUpdateDTO user)
        {
            if (user is null)
                return BadRequest("UserForUpdateDto object is null");
            await _service.UserService.UpdateUserAsync(id, user, trackChanges: true);
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _service.UserService.DeleteUserAsync(id, trackChanges: false);
            return NoContent();
        }
    }
}
