using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Models;
using TechTrack.Infrastructure.Data;
using TechTrack.Infrastructure.Repo;

namespace TechTrack.Infrastructure.Repository
{
    public class RoadmapRepository : GenericRepository<Roadmap>, IRoadmapRepository
    {
        public RoadmapRepository(AppDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Roadmap>> GetAllAsync()
        {
            return await _dbSet
                .Include(r => r.RoadmapSteps)
                .ToListAsync();
        }

        public override async Task<Roadmap?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(r => r.RoadmapSteps)
                .FirstOrDefaultAsync(r => r.RoadmapId == id);
        }
    }
}