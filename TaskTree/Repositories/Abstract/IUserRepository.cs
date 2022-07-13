using TaskTree.Models;

namespace TaskTree.Repositories.Abstract
{
    public interface IUserRepository
    {
        Task<User> Get(int id);
        Task<IEnumerable<User>> GetAll();
        Task Add(User user);
        Task Delete(int id);
        Task Update(User user);
    }
}
