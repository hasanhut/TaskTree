﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskTree.Models;
using TaskTree.Repositories.Abstract;

namespace TaskTree.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var projects = await _projectRepository.GetAll();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var project = await _projectRepository.Get(id);
            if(project == null)
                return BadRequest("Project Not Found");
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(Project project)
        {
            Project newProject = new()
            {
                Name = project.Name,
                Explanation = project.Explanation,
                StartDate = project.StartDate,
                EndDate = project.EndDate
            };
            await _projectRepository.Add(newProject);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject(Project request)
        {
            Project project = new()
            {
                Id = request.Id,
                Name = request.Name,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Explanation = request.Explanation,
            };
            await _projectRepository.Update(project);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _projectRepository.Delete(id);
            return Ok();
        }

    }
}
