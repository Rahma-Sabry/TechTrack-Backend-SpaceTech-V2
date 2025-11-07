using TechPathNavigator.Domain.Common.Results;
using TechTrack.DTOs.Technology;

namespace TechTrack.Domain.Interfaces.IService
{
    public interface ITechnologyService
    {
        Task<ServiceResult<IEnumerable<TechnologyGetDto>>> GetAllAsync();
        Task<ServiceResult<TechnologyGetDto>> GetByIdAsync(int id);
        Task<ServiceResult<TechnologyGetDto>> CreateAsync(TechnologyCreateDto dto);
        Task<ServiceResult<TechnologyGetDto>> UpdateAsync(int id, TechnologyUpdateDto dto);
        Task<ServiceResult<bool>> DeleteAsync(int id);
    }
}
