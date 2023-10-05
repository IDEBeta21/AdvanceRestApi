using AdvanceRestApi.Interfaces;
using AdvanceRestApi.Models;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _userService.GetAllUsers();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<User> Get(Guid id)
        {
            return await _userService.GetUserById(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task Post([FromBody] User user)
        {
            await _userService.AddUser(user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task Put(Guid id, [FromBody] User user)
        {
            await _userService.UpdateUser(id, user);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _userService.DeleteUser(id);
        }
    }
}
