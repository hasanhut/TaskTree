using Microsoft.EntityFrameworkCore;
using TaskTree.Helpers;
using TaskTree.Models;
using TaskTree.Repositories.Abstract;

namespace TaskTree.Repositories.Concrete
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _context;
        public ProjectRepository(DataContext context)
        {
            _context = context;
        }
        public async Task Add(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var itemToDelete = await _context.Projects.FindAsync(id);
            if (itemToDelete == null)
            {
                throw new NullReferenceException();
            }
            _context.Projects.Remove(itemToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Project> Get(int id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task Update(Project project)
        {
            var itemToUpdate = await _context.Projects.FindAsync(project.Id);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.Name = project.Name;
            itemToUpdate.StartDate = project.StartDate;
            itemToUpdate.EndDate = project.EndDate;
            itemToUpdate.Explanation = project.Explanation;
            await _context.SaveChangesAsync();
        }
    }
}
