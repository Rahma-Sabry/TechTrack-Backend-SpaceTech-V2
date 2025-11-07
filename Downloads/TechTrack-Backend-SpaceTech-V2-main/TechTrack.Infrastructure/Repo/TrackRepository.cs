using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Models;
using TechTrack.Infrastructure.Data;

namespace TechTrack.Infrastructure.Repo
{
    public class TrackRepository : ITrackRepository
    {
        private readonly AppDbContext _context;

        public TrackRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Track>> GetAllAsync() => await _context.Tracks.ToListAsync();
        public async Task<Track?> GetByIdAsync(int id) => await _context.Tracks.FindAsync(id);

        public async Task AddAsync(Track track)
        {
            _context.Tracks.Add(track);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Track track)
        {
            _context.Tracks.Update(track);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Track track)
        {
            _context.Tracks.Remove(track);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id) => await _context.Tracks.AnyAsync(t => t.TrackId == id);
    }
}
