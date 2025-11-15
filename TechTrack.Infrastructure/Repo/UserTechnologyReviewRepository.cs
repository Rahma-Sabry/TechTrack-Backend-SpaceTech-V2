using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Models;

namespace TechTrack.Infrastructure.Repository
{
    public class UserTechnologyReviewRepository : IUserTechnologyReviewRepository
    {
        private readonly List<UserTechnologyReview> _reviews = new();
        private int _nextId = 1;

        public async Task<IEnumerable<UserTechnologyReview>> GetAllAsync()
        {
            return await Task.FromResult(_reviews.AsEnumerable());
        }

        public async Task<UserTechnologyReview?> GetByIdAsync(int id)
        {
            return await Task.FromResult(_reviews.FirstOrDefault(r => r.ReviewId == id));
        }

        public async Task<UserTechnologyReview> AddAsync(UserTechnologyReview review)
        {
            review.ReviewId = _nextId++;
            _reviews.Add(review);
            return await Task.FromResult(review);
        }

        public async Task<UserTechnologyReview?> UpdateAsync(UserTechnologyReview review)
        {
            var existing = _reviews.FirstOrDefault(r => r.ReviewId == review.ReviewId);
            if (existing == null)
                return null;

            existing.UserId = review.UserId;
            existing.TechnologyId = review.TechnologyId;
            existing.Rating = review.Rating;
            existing.ReviewText = review.ReviewText;

            return await Task.FromResult(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var review = _reviews.FirstOrDefault(r => r.ReviewId == id);
            if (review == null)
                return false;

            _reviews.Remove(review);
            return await Task.FromResult(true);
        }
    }
}