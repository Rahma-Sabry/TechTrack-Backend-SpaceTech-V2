using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechPathNavigator.Domain.Common.Messages;
using TechTrack.Domain.DTOs.UserTechnologyReview;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Interfaces.IService;
using TechTrack.Domain.Models;
using TechTrack.DTOs;
using TechTrack.Infrastructure.Extensions;

namespace TechTrack.Infrastructure.Service
{
    public class UserTechnologyReviewService : IUserTechnologyReviewService
    {
        private readonly IUserTechnologyReviewRepository _repo;

        public UserTechnologyReviewService(IUserTechnologyReviewRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> CreateAsync(UserTechnologyReviewCreateDto dto)
        {
            var review = dto.ToModel();
            await _repo.AddAsync(review);
            return ApiMessages.ReviewCreated;
        }

        public async Task<string> DeleteAsync(int id)
        {
            var review = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(review!);
            return ApiMessages.ReviewDeleted;
        }

        public async Task<IEnumerable<UserTechnologyReviewGetDto>> GetAllAsync()
        {
            var reviews = await _repo.GetAllAsync();
            return reviews.Select(r => r.ToGetDto());
        }

        public async Task<UserTechnologyReviewGetDto?> GetByIdAsync(int id)
        {
            var review = await _repo.GetByIdAsync(id);
            return review?.ToGetDto();
        }

        public async Task<string> UpdateAsync(int id, UserTechnologyReviewUpdateDto dto)
        {
            var review = await _repo.GetByIdAsync(id);
            dto.ToModel(review!);
            await _repo.UpdateAsync(review!);
            return ApiMessages.ReviewUpdated;
        }
    }
}
