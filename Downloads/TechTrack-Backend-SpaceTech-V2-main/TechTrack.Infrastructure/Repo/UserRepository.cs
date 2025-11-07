using TechTrack.Domain.Models;
using TechTrack.Domain.Interfaces.IRepo;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechTrack.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new();

        public async Task AddAsync(User user)
        {
            user.UserId = _users.Count + 1;
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(User user)
        {
            _users.Remove(user);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await Task.FromResult(_users);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await Task.FromResult(_users.FirstOrDefault(u => u.UserId == id));
        }

        public async Task UpdateAsync(User user)
        {
            var existing = _users.FirstOrDefault(u => u.UserId == user.UserId);
            if (existing != null)
            {
                existing.UserName = user.UserName;
                existing.Email = user.Email;
                if (!string.IsNullOrWhiteSpace(user.PasswordHash))
                    existing.PasswordHash = user.PasswordHash;
            }
            await Task.CompletedTask;
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await Task.FromResult(_users.Any(u => u.Email == email));
        }
    }
}
