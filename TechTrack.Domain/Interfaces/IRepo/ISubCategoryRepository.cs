using System.Collections.Generic;
using System.Threading.Tasks;
using TechTrack.Domain.Models;

namespace TechTrack.Domain.Interfaces.IRepo
{
    public interface ISubCategoryRepository
    {
        Task<IEnumerable<SubCategory>> GetAllAsync();
        Task<SubCategory?> GetByIdAsync(int id);
        Task<SubCategory> AddAsync(SubCategory subCategory);
        Task<SubCategory?> UpdateAsync(SubCategory subCategory);
        Task<bool> DeleteAsync(int id);
    }
}
