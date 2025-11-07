using TechTrack.Domain.Models;
using TechTrack.Domain.Interfaces.IRepo;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechTrack.Infrastructure.Repository
{
    public class UserTechnologyReviewRepository : IUserTechnologyReviewRepository
    {
        private readonly List<UserTechnologyReview> _reviews = new();

        public async Task AddAsync(UserTechnologyReview review)
        {
            review.ReviewId = _reviews.Count + 1;
            _reviews.Add(review);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(UserTechnologyReview review)
        {
            _reviews.Remove(review);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<UserTechnologyReview>> GetAllAsync()
        {
            return await Task.FromResult(_reviews);
        }

        public async Task<UserTechnologyReview?> GetByIdAsync(int id)
        {
            return await Task.FromResult(_reviews.FirstOrDefault(r => r.ReviewId == id));
        }

        public async Task UpdateAsync(UserTechnologyReview review)
        {
            var existing = _reviews.FirstOrDefault(r => r.ReviewId == review.ReviewId);
            if (existing != null)
            {
                existing.UserId = review.UserId;
                existing.TechnologyId = review.TechnologyId;
                existing.Rating = review.Rating;
                existing.ReviewText = review.ReviewText;
            }
            await Task.CompletedTask;
        }
    }
}
