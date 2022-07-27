using Microsoft.EntityFrameworkCore;
using TaskTree.Helpers;
using TaskTree.Models;
using TaskTree.Repositories.Abstract;

namespace TaskTree.Repositories.Concrete
{
    public class UserRepository:IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task Add(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var itemToDelete = await _context.Users.FindAsync(id);
            if (itemToDelete == null)
            {
                throw new NullReferenceException();
            }
            _context.Users.Remove(itemToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<User> Get(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task Update(User user)
        {
            var itemToUpdate = await _context.Users.FindAsync(user.Id);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.Username = user.Username;
            itemToUpdate.Email = user.Email;
            itemToUpdate.Password = user.Password;
            await _context.SaveChangesAsync();
        }
    }
}
