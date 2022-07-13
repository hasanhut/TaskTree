using TaskTree.Models;

namespace TaskTree.Repositories.Abstract
{
    public interface IProjectTaskRepository
    {
        Task<ProjectTask> Get(int id);
        Task<IEnumerable<ProjectTask>> GetAll();
        Task Add(ProjectTask projectTask);
        Task Delete(int id);
        Task Update(ProjectTask projectTask);
    }
}
