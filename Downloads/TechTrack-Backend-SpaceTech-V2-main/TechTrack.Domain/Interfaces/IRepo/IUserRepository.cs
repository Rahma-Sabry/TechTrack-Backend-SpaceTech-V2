using TechTrack.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechTrack.Domain.Interfaces.IRepo
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
        Task<bool> ExistsByEmailAsync(string email);
    }
}
