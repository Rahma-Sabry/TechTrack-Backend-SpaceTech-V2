using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Models;

namespace TechTrack.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new();
        private int _nextId = 1;

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await Task.FromResult(_users.AsEnumerable());
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await Task.FromResult(_users.FirstOrDefault(u => u.UserId == id));
        }

        public async Task<User> AddAsync(User user)
        {
            user.UserId = _nextId++;
            _users.Add(user);
            return await Task.FromResult(user);
        }

        public async Task<User?> UpdateAsync(User user)
        {
            var existing = _users.FirstOrDefault(u => u.UserId == user.UserId);
            if (existing == null)
                return null;

            existing.UserName = user.UserName;
            existing.Email = user.Email;
            if (!string.IsNullOrWhiteSpace(user.PasswordHash))
                existing.PasswordHash = user.PasswordHash;

            return await Task.FromResult(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = _users.FirstOrDefault(u => u.UserId == id);
            if (user == null)
                return false;

            _users.Remove(user);
            return await Task.FromResult(true);
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await Task.FromResult(_users.Any(u => u.Email == email));
        }
    }
}