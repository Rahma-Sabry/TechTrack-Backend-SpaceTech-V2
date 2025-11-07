using System.Collections.Generic;
using System.Threading.Tasks;
using TechPathNavigator.Domain.Common.Results;
using TechTrack.DTOs.Category;

namespace TechTrack.Domain.Interfaces.IService
{
    public interface ICategoryService
    {
        Task<ServiceResult<IEnumerable<CategoryGetDto>>> GetAllAsync();
        Task<ServiceResult<CategoryGetDto>> GetByIdAsync(int id);
        Task<ServiceResult<CategoryGetDto>> CreateAsync(CategoryCreateDto dto);
        Task<ServiceResult<CategoryGetDto>> UpdateAsync(int id, CategoryUpdateDto dto);
        Task<ServiceResult<bool>> DeleteAsync(int id);
    }
}
