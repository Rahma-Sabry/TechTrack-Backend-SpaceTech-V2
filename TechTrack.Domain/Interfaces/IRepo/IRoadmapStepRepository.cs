using System.Collections.Generic;
using System.Threading.Tasks;
using TechTrack.Domain.Models;

namespace TechTrack.Domain.Interfaces.IRepo
{
    public interface IRoadmapStepRepository : IGenericRepository<RoadmapStep>
    {
        Task<IEnumerable<RoadmapStep>> GetAllByRoadmapIdAsync(int roadmapId);
    }
}