using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskTree.Models;
using TaskTree.Repositories.Abstract;

namespace TaskTree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userRepository.Get(id);
            if (user == null)
                return BadRequest("User Not Found");
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            User newUser = new()
            {
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
            };
            await _userRepository.Add(newUser);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(User request)
        {
            User User = new()
            {
                Id = request.Id,
                Username = request.Username,
                Password = request.Password,
                Email = request.Email,
            };
            await _userRepository.Update(User);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userRepository.Delete(id);
            return Ok();
        }

    }
}
