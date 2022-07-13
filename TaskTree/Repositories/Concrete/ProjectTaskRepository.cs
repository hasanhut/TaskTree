using Microsoft.EntityFrameworkCore;
using TaskTree.Helpers;
using TaskTree.Models;
using TaskTree.Repositories.Abstract;

namespace TaskTree.Repositories.Concrete
{
    public class ProjectTaskRepository : IProjectTaskRepository
    {
        private readonly DataContext _context;
        public ProjectTaskRepository(DataContext context)
        {
            _context = context;
        }
        public async Task Add(ProjectTask projectTask)
        {
            _context.ProjectTasks.Add(projectTask);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var itemToDelete = await _context.ProjectTasks.FindAsync(id);
            if (itemToDelete == null)
            {
                throw new NullReferenceException();
            }
            _context.ProjectTasks.Remove(itemToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<ProjectTask> Get(int id)
        {
            return await _context.ProjectTasks.FindAsync(id);
        }

        public async Task<IEnumerable<ProjectTask>> GetAll()
        {
            return await _context.ProjectTasks.ToListAsync();
        }

        public async Task Update(ProjectTask projectTask)
        {
            var itemToUpdate = await _context.ProjectTasks.FindAsync(projectTask.Id);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.StartDate = projectTask.StartDate;
            itemToUpdate.EndDate = projectTask.EndDate;
            itemToUpdate.Reporter = projectTask.Reporter;
            itemToUpdate.Assignee = projectTask.Assignee;
            await _context.SaveChangesAsync();
        }
    }
}
