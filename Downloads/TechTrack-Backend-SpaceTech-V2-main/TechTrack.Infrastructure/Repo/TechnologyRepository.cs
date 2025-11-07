using Microsoft.EntityFrameworkCore;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Models;
using TechTrack.Infrastructure.Data;

namespace TechTrack.Infrastructure.Repo
{
    public class TechnologyRepository : IGenericRepository<Technology>, ITechnologyRepository
    {
        private readonly AppDbContext _context;

        public TechnologyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Technology>> GetAllAsync()
        {
            return await _context.Technologies.Include(t => t.Track).ToListAsync();
        }

        public async Task<Technology?> GetByIdAsync(int id)
        {
            return await _context.Technologies.Include(t => t.Track)
                                              .FirstOrDefaultAsync(t => t.TechnologyId == id);
        }

        public async Task<Technology> AddAsync(Technology entity)
        {
            _context.Technologies.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Technology?> UpdateAsync(Technology entity)
        {
            _context.Technologies.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Technologies.FindAsync(id);
            if (entity == null) return false;

            _context.Technologies.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
