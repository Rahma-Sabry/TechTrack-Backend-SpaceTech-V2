using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Models;
using TechTrack.Infrastructure.Data;

namespace TechTrack.Infrastructure.Repo
{
    public class RoadmapStepRepository : GenericRepository<RoadmapStep>, IRoadmapStepRepository
    {
        public RoadmapStepRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<RoadmapStep>> GetAllByRoadmapIdAsync(int roadmapId)
        {
            return await _dbSet
                .Where(rs => rs.RoadmapId == roadmapId)
                .OrderBy(rs => rs.StepOrder)  // Order by step order if you have that field
                .ToListAsync();
        }
    }
}
