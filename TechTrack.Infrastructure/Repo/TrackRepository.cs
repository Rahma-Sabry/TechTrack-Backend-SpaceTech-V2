using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Models;
using TechTrack.Infrastructure.Data;

namespace TechTrack.Infrastructure.Repo
{
    public class TrackRepository : GenericRepository<Track>, ITrackRepository
    {
        public TrackRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _dbSet.AnyAsync(t => t.TrackId == id);
        }
    }
}