using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskTree.Models;
using TaskTree.Repositories.Abstract;

namespace TaskTree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTaskController : ControllerBase
    {
        private readonly IProjectTaskRepository _projectTaskRepository;
        public ProjectTaskController(IProjectTaskRepository projectTaskRepository)
        {
            _projectTaskRepository = projectTaskRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var projects = await _projectTaskRepository.GetAll();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var project = await _projectTaskRepository.Get(id);
            if (project == null)
                return BadRequest("Project Not Found");
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> AddProjectTask(ProjectTask projectTask)
        {
            ProjectTask newProjectTask = new()
            {
                TaskName = projectTask.TaskName,
                StartDate = projectTask.StartDate,
                EndDate = projectTask.EndDate,
                AssigneeId = projectTask.AssigneeId,
                ReporterId = projectTask.ReporterId,
                ProjectId = projectTask.ProjectId
            };
            await _projectTaskRepository.Add(newProjectTask);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProjectTask(ProjectTask request)
        {
            ProjectTask projectTask = new()
            {
                Id = request.Id,
                TaskName = request.TaskName,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                AssigneeId = request.AssigneeId,
                ReporterId = request.ReporterId,
                ProjectId = request.ProjectId
            };
            await _projectTaskRepository.Update(projectTask);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _projectTaskRepository.Delete(id);
            return Ok();
        }

    }
}

