using System.Collections.Generic;
using System.Threading.Tasks;
using TechPathNavigator.Domain.Common.Results;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Interfaces.IService;
using TechTrack.DTOs.Roadmap;
using TechTrack.Infrastructure.Extensions;

namespace TechTrack.Infrastructure.Service
{
    public class RoadmapService : IRoadmapService
    {
        private readonly IRoadmapRepository _roadmapRepo;

        public RoadmapService(IRoadmapRepository roadmapRepo)
        {
            _roadmapRepo = roadmapRepo;
        }

        public async Task<ServiceResult<IEnumerable<RoadmapGetDto>>> GetAllAsync()
        {
            var roadmaps = await _roadmapRepo.GetAllAsync();
            return ServiceResult<IEnumerable<RoadmapGetDto>>.Ok(roadmaps.ToGetDtoList());
        }

        public async Task<ServiceResult<RoadmapGetDto>> GetByIdAsync(int id)
        {
            var roadmap = await _roadmapRepo.GetByIdAsync(id);
            if (roadmap == null)
                return ServiceResult<RoadmapGetDto>.Fail("Not found");

            return ServiceResult<RoadmapGetDto>.Ok(roadmap.ToGetDto());
        }

        public async Task<ServiceResult<RoadmapGetDto>> CreateAsync(RoadmapCreateDto dto)
        {
            var roadmap = dto.ToEntity();
            var created = await _roadmapRepo.AddAsync(roadmap);
            return ServiceResult<RoadmapGetDto>.Ok(created.ToGetDto());
        }

        public async Task<ServiceResult<RoadmapGetDto>> UpdateAsync(int id, RoadmapUpdateDto dto)
        {
            var roadmap = await _roadmapRepo.GetByIdAsync(id);
            if (roadmap == null)
                return ServiceResult<RoadmapGetDto>.Fail("Not found");

            dto.MapToEntity(roadmap);
            var updated = await _roadmapRepo.UpdateAsync(roadmap);
            return ServiceResult<RoadmapGetDto>.Ok(updated!.ToGetDto());
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            var deleted = await _roadmapRepo.DeleteAsync(id);
            if (!deleted)
                return ServiceResult<bool>.Fail("Not found");

            return ServiceResult<bool>.Ok(true);
        }
    }
}