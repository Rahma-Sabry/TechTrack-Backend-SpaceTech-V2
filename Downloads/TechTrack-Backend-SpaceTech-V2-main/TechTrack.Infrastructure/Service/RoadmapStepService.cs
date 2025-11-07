using TechPathNavigator.Domain.Common.Errors;
using TechPathNavigator.Domain.Common.Messages;
using TechTrack.Domain.DTOs.RoadmapStep;
using TechTrack.Domain.Extensions;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Interfaces.IService;
using TechTrack.Domain.Models;

namespace TechTrack.Infrastructure.Service
{
    public class RoadmapStepService : IRoadmapStepService
    {
        private readonly IRoadmapStepRepository _repo;

        public RoadmapStepService(IRoadmapStepRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<RoadmapStepGetDto>> GetAllAsync()
        {
            var steps = await _repo.GetAllAsync();

            if (!steps.Any())
                throw new Exception(ErrorMessages.RoadmapStep_NotFound);

            return steps.ToGetDtoList();
        }

        public async Task<RoadmapStepGetDto?> GetByIdAsync(int id)
        {
            var step = await _repo.GetByIdAsync(id);
            if (step == null)
                throw new Exception(ErrorMessages.RoadmapStep_NotFound);

            return step.ToGetDto();
        }

        public async Task<RoadmapStepGetDto> CreateAsync(RoadmapStepCreateDto dto)
        {
            if (dto == null)
                throw new Exception(ApiMessages.NotFound);

            var step = dto.ToEntity();
            await _repo.AddAsync(step);
            await _repo.SaveChangesAsync();

            Console.WriteLine(ApiMessages.RoadmapStepCreated);
            return step.ToGetDto();
        }

        public async Task<RoadmapStepGetDto?> UpdateAsync(int id, RoadmapStepUpdateDto dto)
        {
            var step = await _repo.GetByIdAsync(id);
            if (step == null)
                throw new Exception(ErrorMessages.RoadmapStep_NotFound);

            dto.MapToEntity(step);
            await _repo.UpdateAsync(step);
            await _repo.SaveChangesAsync();

            Console.WriteLine(ApiMessages.RoadmapStepUpdated);
            return step.ToGetDto();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var step = await _repo.GetByIdAsync(id);
            if (step == null)
                throw new Exception(ErrorMessages.RoadmapStep_NotFound);

            await _repo.DeleteAsync(id);
            await _repo.SaveChangesAsync();

            Console.WriteLine(ApiMessages.RoadmapStepDeleted);
            return true;
        }
    }
}
