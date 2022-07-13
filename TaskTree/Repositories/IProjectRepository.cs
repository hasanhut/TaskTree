using TaskTree.Models;

namespace TaskTree.Repositories
{
    public interface IProjectRepository
    {
        Task<Project> Get(int id);
        Task<IEnumerable<Project>> GetAll();
        Task Add(Project project);
        Task Delete(int id);
        Task Update(Project project);

    }
}
