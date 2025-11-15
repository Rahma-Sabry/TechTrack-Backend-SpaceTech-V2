using System.Collections.Generic;
using System.Threading.Tasks;
using TechPathNavigator.Domain.Common.Results;
using TechTrack.Domain.DTOs.SubCategory;
using TechTrack.DTOs.SubCategory;

namespace TechTrack.Domain.Interfaces.IService
{
    public interface ISubCategoryService
    {
        Task<ServiceResult<IEnumerable<SubCategoryGetDto>>> GetAllAsync();
        Task<ServiceResult<SubCategoryGetDto>> GetByIdAsync(int id);
        Task<ServiceResult<SubCategoryGetDto>> CreateAsync(SubCategoryCreateDto dto);
        Task<ServiceResult<SubCategoryGetDto>> UpdateAsync(int id, SubCategoryUpdateDto dto);
        Task<ServiceResult<bool>> DeleteAsync(int id);
    }
}