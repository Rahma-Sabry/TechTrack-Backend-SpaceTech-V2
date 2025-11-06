using System.Collections.Generic;
using System.Threading.Tasks;
using TechTrack.Domain.DTOs.UserTechnologyReview;
using TechTrack.DTOs;

namespace TechTrack.Domain.Interfaces.IService
{
    public interface IUserTechnologyReviewService
    {
        Task<IEnumerable<UserTechnologyReviewGetDto>> GetAllAsync();
        Task<UserTechnologyReviewGetDto?> GetByIdAsync(int id);
        Task<string> CreateAsync(UserTechnologyReviewCreateDto dto);
        Task<string> UpdateAsync(int id, UserTechnologyReviewUpdateDto dto);
        Task<string> DeleteAsync(int id);
    }
}
