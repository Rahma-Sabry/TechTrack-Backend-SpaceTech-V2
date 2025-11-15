using System.Collections.Generic;
using System.Threading.Tasks;
using TechTrack.Domain.DTOs.RoadmapStep;

namespace TechTrack.Domain.Interfaces.IService
{
    public interface IRoadmapStepService
    {
        Task<IEnumerable<RoadmapStepGetDto>> GetAllAsync();
        Task<IEnumerable<RoadmapStepGetDto>> GetAllByRoadmapIdAsync(int roadmapId);
        Task<RoadmapStepGetDto?> GetByIdAsync(int id);
        Task<RoadmapStepGetDto> CreateAsync(RoadmapStepCreateDto dto);
        Task<RoadmapStepGetDto?> UpdateAsync(int id, RoadmapStepUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}