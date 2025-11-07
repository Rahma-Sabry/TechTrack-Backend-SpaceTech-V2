using TechTrack.Domain.Models;

namespace TechTrack.Domain.Interfaces.IRepo
{
    public interface IRoadmapRepository
    {
        Task<IEnumerable<Roadmap>> GetAllAsync();
        Task<Roadmap?> GetByIdAsync(int id);
        Task AddAsync(Roadmap roadmap);
        Task UpdateAsync(Roadmap roadmap);
        Task DeleteAsync(Roadmap roadmap);
        Task SaveChangesAsync();
    }
}
