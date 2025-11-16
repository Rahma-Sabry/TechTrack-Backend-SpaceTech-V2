using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Models;
using TechTrack.Infrastructure.Data;

namespace TechTrack.Infrastructure.Repo
{
    public class TechnologyRepository : GenericRepository<Technology>, ITechnologyRepository
    {
        public TechnologyRepository(AppDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Technology>> GetAllAsync()
        {
            return await _dbSet.Include(t => t.Track).ToListAsync();
        }

        public override async Task<Technology?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(t => t.Track)
                .FirstOrDefaultAsync(t => t.TechnologyId == id);
        }
    }
}