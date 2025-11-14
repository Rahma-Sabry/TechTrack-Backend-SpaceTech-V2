using TechTrack.Domain.DTOs.RoadmapStep;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechTrack.Domain.Interfaces.IService
{
    public interface IRoadmapStepService
    {
        Task<IEnumerable<RoadmapStepGetDto>> GetAllAsync();
        Task<IEnumerable<RoadmapStepGetDto>> GetAllByRoadmapIdAsync(int roadmapId); // Add this
        Task<RoadmapStepGetDto?> GetByIdAsync(int id);
        Task<RoadmapStepGetDto> CreateAsync(RoadmapStepCreateDto dto);
        Task<RoadmapStepGetDto?> UpdateAsync(int id, RoadmapStepUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}