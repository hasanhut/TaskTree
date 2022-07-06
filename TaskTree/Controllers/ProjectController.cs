using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskTree.Models;

namespace TaskTree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        List<Project> projects = new List<Project>
        {
            new Project{Id = 1,Name="TestProject",StartDate=DateTime.Now,EndDate=new DateTime(2050,01,01),Explanation="TEST PROJECT"},
            new Project{Id = 2,Name="THYProject",StartDate=DateTime.Now,EndDate=new DateTime(2050,01,01),Explanation="THY TEST PROJECT"}
        };

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var project = projects.Find(p => p.Id == id);
            if(project == null)
                return BadRequest("Project Not Found");
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(Project project)
        {
            projects.Add(project);
            return Ok(projects);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject(Project request)
        {
            var project = projects.Find(p => p.Id == request.Id);
            if (project == null)
                return BadRequest("Project Not Found");
            project.Name = request.Name;
            project.StartDate = request.StartDate;
            project.EndDate = request.EndDate;
            project.Explanation = request.Explanation;

            return Ok(projects);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var project = projects.Find(p => p.Id == id);
            if (project == null)
                return BadRequest("Project Not Found");
            projects.Remove(project);
            return Ok(project);
        }
    }
}
