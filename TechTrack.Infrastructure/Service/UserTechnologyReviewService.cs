using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechPathNavigator.Domain.Common.Messages;
using TechTrack.Domain.DTOs.UserTechnologyReview;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Interfaces.IService;
using TechTrack.Infrastructure.Extensions;

namespace TechTrack.Infrastructure.Service
{
    public class UserTechnologyReviewService : IUserTechnologyReviewService
    {
        private readonly IUserTechnologyReviewRepository _reviewRepo;

        public UserTechnologyReviewService(IUserTechnologyReviewRepository reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }

        public async Task<string> CreateAsync(UserTechnologyReviewCreateDto dto)
        {
            var review = dto.ToModel();
            await _reviewRepo.AddAsync(review);
            return ApiMessages.ReviewCreated;
        }

        public async Task<string> DeleteAsync(int id)
        {
            var deleted = await _reviewRepo.DeleteAsync(id);
            if (!deleted)
                return "Review not found";

            return ApiMessages.ReviewDeleted;
        }

        public async Task<IEnumerable<UserTechnologyReviewGetDto>> GetAllAsync()
        {
            var reviews = await _reviewRepo.GetAllAsync();
            return reviews.Select(r => r.ToGetDto());
        }

        public async Task<UserTechnologyReviewGetDto?> GetByIdAsync(int id)
        {
            var review = await _reviewRepo.GetByIdAsync(id);
            return review?.ToGetDto();
        }

        public async Task<string> UpdateAsync(int id, UserTechnologyReviewUpdateDto dto)
        {
            var review = await _reviewRepo.GetByIdAsync(id);
            if (review == null)
                return "Review not found";

            dto.ToModel(review);
            await _reviewRepo.UpdateAsync(review);
            return ApiMessages.ReviewUpdated;
        }
    }
}