using System.Collections.Generic;
using System.Threading.Tasks;
using TechPathNavigator.Domain.Common.Results;
using TechTrack.DTOs.Roadmap;

namespace TechTrack.Domain.Interfaces.IService
{
    public interface IRoadmapService
    {
        Task<ServiceResult<IEnumerable<RoadmapGetDto>>> GetAllAsync();
        Task<ServiceResult<RoadmapGetDto>> GetByIdAsync(int id);
        Task<ServiceResult<RoadmapGetDto>> CreateAsync(RoadmapCreateDto dto);
        Task<ServiceResult<RoadmapGetDto>> UpdateAsync(int id, RoadmapUpdateDto dto);
        Task<ServiceResult<bool>> DeleteAsync(int id);
    }
}