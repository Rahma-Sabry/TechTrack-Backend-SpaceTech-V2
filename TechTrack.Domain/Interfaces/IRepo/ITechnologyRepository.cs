using TechTrack.Domain.Models;

namespace TechTrack.Domain.Interfaces.IRepo
{
    public interface ITechnologyRepository
    {
        Task<IEnumerable<Technology>> GetAllAsync();
        Task<Technology?> GetByIdAsync(int id);
        Task<Technology> AddAsync(Technology entity);
        Task<Technology?> UpdateAsync(Technology entity);
        Task<bool> DeleteAsync(int id);
    }
}
