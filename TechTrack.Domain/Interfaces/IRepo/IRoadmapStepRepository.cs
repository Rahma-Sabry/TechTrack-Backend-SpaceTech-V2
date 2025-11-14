using TechTrack.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechTrack.Domain.Interfaces.IRepo
{
    public interface IRoadmapStepRepository
    {
        Task<IEnumerable<RoadmapStep>> GetAllAsync();
        Task<RoadmapStep?> GetByIdAsync(int id);
        Task AddAsync(RoadmapStep roadmapStep);
        Task<IEnumerable<RoadmapStep>> GetAllByRoadmapIdAsync(int roadmapId);

        Task UpdateAsync(RoadmapStep roadmapStep);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
