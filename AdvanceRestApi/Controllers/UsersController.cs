using AdvanceRestApi.DTO_s;
using AdvanceRestApi.Interfaces;
using AdvanceRestApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvanceRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private IUser _userService;
        public UsersController(IUser userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet("get-all-users")]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            var result = await _userService.GetAllUsers();
            if(result.IsSuccess)
            {
                return Ok(result.User);
            }
            return NotFound(result.ErrorMessage);
        }

        // GET api/<UsersController>/5
        [HttpGet("get-user-by-id/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _userService.GetUserById(id);
            if(result.IsSuccess) 
            {
                return Ok(result.User);
            }
            return NotFound(result.ErrorMessage);
        }

        // POST api/<UsersController>
        [HttpPost("add-user")]
        public async Task<IActionResult> Post([FromBody] AddUserDto user)
        {
            var result = await _userService.AddUser(user);
            if(result.IsSuccess)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            return BadRequest(result.ErrorMessage);
        }

        // PUT api/<UsersController>/5
        [HttpPut("update-user-by-id/{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UserDTO user)
        {
            var result = await _userService.UpdateUser(id, user);
            if(result.IsSuccess)
            {
                return NoContent();
            }
            return BadRequest(result.ErrorMessage);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("delete-user-by-id/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userService.DeleteUser(id);
            if (result.IsSuccess)
            {
                return NoContent();
            }
            return BadRequest(result.ErrorMessage);
        }
    }
}
