using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskTree.Models;

namespace TaskTree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTaskController : ControllerBase
    {
        List<ProjectTask> tasks = new List<ProjectTask>
        {
            new ProjectTask{Id = 1,Reporter=null,Assignee=null,StartDate=new DateTime(2020,03,03),EndDate=DateTime.Now},
            new ProjectTask{Id = 2,Reporter=null,Assignee=null,StartDate=new DateTime(2019,01,01),EndDate=DateTime.Now},
        };

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var task = tasks.Find(p => p.Id == id);
            if (task == null)
                return BadRequest("Task Not Found");
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(ProjectTask task)
        {
            tasks.Add(task);
            return Ok(task);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject(ProjectTask request)
        {
            var task = tasks.Find(p => p.Id == request.Id);
            if (task == null)
                return BadRequest("Task Not Found");
            task.Reporter = request.Reporter;
            task.StartDate = request.StartDate;
            task.EndDate = request.EndDate;
            task.Assignee = request.Assignee;
            task.Reporter = request.Reporter;

            return Ok(tasks);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var task = tasks.Find(p => p.Id == id);
            if (task == null)
                return BadRequest("Task Not Found");
            tasks.Remove(task);
            return Ok(task);
        }
    }
}
