using Microsoft.EntityFrameworkCore;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Models;
using TechTrack.Infrastructure.Data;

namespace TechTrack.Infrastructure.Repository
{
    public class UserTechnologyReviewRepository : IUserTechnologyReviewRepository
    {
        private readonly AppDbContext _context;

        public UserTechnologyReviewRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserTechnologyReview?> GetByIdAsync(int id)
        {
            return await _context.UserTechnologyReviews
                .Include(r => r.User)
                .Include(r => r.Technology)
                .FirstOrDefaultAsync(r => r.ReviewId == id);
        }

        public async Task<IEnumerable<UserTechnologyReview>> GetAllAsync()
        {
            return await _context.UserTechnologyReviews
                .Include(r => r.User)
                .Include(r => r.Technology)
                .ToListAsync();
        }

        public async Task AddAsync(UserTechnologyReview review)
        {
            await _context.UserTechnologyReviews.AddAsync(review);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserTechnologyReview review)
        {
            _context.UserTechnologyReviews.Update(review);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserTechnologyReview review)
        {
            _context.UserTechnologyReviews.Remove(review);
            await _context.SaveChangesAsync();
        }
    }
}
