using TechTrack.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechTrack.Domain.Interfaces.IRepo
{
    public interface IUserTechnologyReviewRepository
    {
        Task<UserTechnologyReview?> GetByIdAsync(int id);
        Task<IEnumerable<UserTechnologyReview>> GetAllAsync();
        Task AddAsync(UserTechnologyReview review);
        Task UpdateAsync(UserTechnologyReview review);
        Task DeleteAsync(UserTechnologyReview review);
    }
}
