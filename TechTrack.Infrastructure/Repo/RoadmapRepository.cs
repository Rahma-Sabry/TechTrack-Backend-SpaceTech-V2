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
    }
}