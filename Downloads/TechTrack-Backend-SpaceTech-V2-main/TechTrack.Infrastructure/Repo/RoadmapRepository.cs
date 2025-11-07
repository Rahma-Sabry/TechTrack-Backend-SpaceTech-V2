using Microsoft.EntityFrameworkCore;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Models;
using TechTrack.Infrastructure.Data;

namespace TechTrack.Infrastructure.Repository
{
    public class RoadmapRepository : IRoadmapRepository
    {
        private readonly AppDbContext _context;

        public RoadmapRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Roadmap>> GetAllAsync() => await _context.Roadmaps.ToListAsync();
        public async Task<Roadmap?> GetByIdAsync(int id) => await _context.Roadmaps.FindAsync(id);
        public async Task AddAsync(Roadmap roadmap) => await _context.Roadmaps.AddAsync(roadmap);
        public async Task UpdateAsync(Roadmap roadmap) => _context.Roadmaps.Update(roadmap);
        public async Task DeleteAsync(Roadmap roadmap) => _context.Roadmaps.Remove(roadmap);
        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
