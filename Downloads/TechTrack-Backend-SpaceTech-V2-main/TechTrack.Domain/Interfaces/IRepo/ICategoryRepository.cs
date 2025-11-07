using System.Collections.Generic;
using System.Threading.Tasks;
using TechTrack.Domain.Models;

namespace TechTrack.Domain.Interfaces.IRepo
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task AddAsync(Category category);
        void Update(Category category);
        void Delete(Category category);
        Task SaveChangesAsync();
    }
}
