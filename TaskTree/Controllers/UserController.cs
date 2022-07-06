using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskTree.Models;

namespace TaskTree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        List<User> users = new List<User>
        {
            new User{Id = 1,Email="test@mail.com",Name="Hasan",Surname="Hut",Password="1234"},
            new User{Id = 2,Email="test2@mail.com",Name="TEST",Surname="Surname",Password="5678"}
        };

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = users.Find(p => p.Id == id);
            if (user == null)
                return BadRequest("Task Not Found");
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(User user)
        {
            users.Add(user);
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject(User request)
        {
            var user = users.Find(p => p.Id == request.Id);
            if (user == null)
                return BadRequest("Task Not Found");
            
            user.Surname = request.Surname;
            user.Name = request.Name;
            user.Email = request.Email;
            user.Password = request.Password;
            return Ok(users);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = users.Find(p => p.Id == id);
            if (user == null)
                return BadRequest("Task Not Found");
            users.Remove(user);
            return Ok(user);
        }

    }
}
