using Microsoft.EntityFrameworkCore;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Models;
using TechTrack.Infrastructure.Data;

namespace TechTrack.Infrastructure.Repo
{
    public class RoadmapStepRepository : IRoadmapStepRepository
    {
        private readonly AppDbContext _context;

        public RoadmapStepRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoadmapStep>> GetAllAsync()
        {
            return await _context.RoadmapSteps.ToListAsync();
        }

        // Add this method
        public async Task<IEnumerable<RoadmapStep>> GetAllByRoadmapIdAsync(int roadmapId)
        {
            return await _context.RoadmapSteps
                .Where(rs => rs.RoadmapId == roadmapId)
                .OrderBy(rs => rs.StepOrder)
                .ToListAsync();
        }

        public async Task<RoadmapStep?> GetByIdAsync(int id)
        {
            return await _context.RoadmapSteps.FindAsync(id);
        }

        public async Task AddAsync(RoadmapStep roadmapStep)
        {
            await _context.RoadmapSteps.AddAsync(roadmapStep);
        }

        public async Task UpdateAsync(RoadmapStep roadmapStep)
        {
            _context.RoadmapSteps.Update(roadmapStep);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var step = await GetByIdAsync(id);
            if (step != null)
                _context.RoadmapSteps.Remove(step);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}