using Microsoft.EntityFrameworkCore;
using TechPathNavigator.Domain.Common.Results;
using TechTrack.DTOs.Roadmap;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Interfaces.IService;
using TechTrack.Infrastructure.Extensions;

namespace TechTrack.Infrastructure.Service
{
    public class RoadmapService : IRoadmapService
    {
        private readonly IRoadmapRepository _repo;

        public RoadmapService(IRoadmapRepository repo)
        {
            _repo = repo;
        }

        public async Task<ServiceResult<IEnumerable<RoadmapGetDto>>> GetAllAsync()
        {
            var roadmaps = await _repo.GetAllAsync();
            return ServiceResult<IEnumerable<RoadmapGetDto>>.Ok(roadmaps.ToGetDtoList());
        }

        public async Task<ServiceResult<RoadmapGetDto>> GetByIdAsync(int id)
        {
            var roadmap = await _repo.GetByIdAsync(id);
            if (roadmap == null) return ServiceResult<RoadmapGetDto>.Fail("Not found");
            return ServiceResult<RoadmapGetDto>.Ok(roadmap.ToGetDto());
        }

        public async Task<ServiceResult<RoadmapGetDto>> CreateAsync(RoadmapCreateDto dto)
        {
            var roadmap = dto.ToEntity();
            await _repo.AddAsync(roadmap);
            await _repo.SaveChangesAsync();
            return ServiceResult<RoadmapGetDto>.Ok(roadmap.ToGetDto());
        }

        public async Task<ServiceResult<RoadmapGetDto>> UpdateAsync(int id, RoadmapUpdateDto dto)
        {
            var roadmap = await _repo.GetByIdAsync(id);
            if (roadmap == null) return ServiceResult<RoadmapGetDto>.Fail("Not found");

            dto.MapToEntity(roadmap);
            await _repo.UpdateAsync(roadmap);
            await _repo.SaveChangesAsync();

            return ServiceResult<RoadmapGetDto>.Ok(roadmap.ToGetDto());
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            var roadmap = await _repo.GetByIdAsync(id);
            if (roadmap == null) return ServiceResult<bool>.Fail("Not found");

            await _repo.DeleteAsync(roadmap);
            await _repo.SaveChangesAsync();

            return ServiceResult<bool>.Ok(true);
        }
    }
}
