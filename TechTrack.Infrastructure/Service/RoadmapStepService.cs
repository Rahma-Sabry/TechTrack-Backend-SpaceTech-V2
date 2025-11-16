using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechPathNavigator.Domain.Common.Errors;
using TechPathNavigator.Domain.Common.Messages;
using TechTrack.Domain.DTOs.RoadmapStep;
using TechTrack.Domain.Extensions;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Interfaces.IService;

namespace TechTrack.Infrastructure.Service
{
    public class RoadmapStepService : IRoadmapStepService
    {
        private readonly IRoadmapStepRepository _roadmapStepRepo;

        public RoadmapStepService(IRoadmapStepRepository roadmapStepRepo)
        {
            _roadmapStepRepo = roadmapStepRepo;
        }

        public async Task<IEnumerable<RoadmapStepGetDto>> GetAllAsync()
        {
            var steps = await _roadmapStepRepo.GetAllAsync();
            if (!steps.Any())
                throw new Exception(ErrorMessages.RoadmapStep_NotFound);

            return steps.ToGetDtoList();
        }

        public async Task<IEnumerable<RoadmapStepGetDto>> GetAllByRoadmapIdAsync(int roadmapId)
        {
            var steps = await _roadmapStepRepo.GetAllByRoadmapIdAsync(roadmapId);
            return steps.ToGetDtoList();
        }

        public async Task<RoadmapStepGetDto?> GetByIdAsync(int id)
        {
            var step = await _roadmapStepRepo.GetByIdAsync(id);
            if (step == null)
                throw new Exception(ErrorMessages.RoadmapStep_NotFound);

            return step.ToGetDto();
        }

        public async Task<RoadmapStepGetDto> CreateAsync(RoadmapStepCreateDto dto)
        {
            if (dto == null)
                throw new Exception(ApiMessages.NotFound);

            var step = dto.ToEntity();
            var created = await _roadmapStepRepo.AddAsync(step);

            Console.WriteLine(ApiMessages.RoadmapStepCreated);
            return created.ToGetDto();
        }

        public async Task<RoadmapStepGetDto?> UpdateAsync(int id, RoadmapStepUpdateDto dto)
        {
            var step = await _roadmapStepRepo.GetByIdAsync(id);
            if (step == null)
                throw new Exception(ErrorMessages.RoadmapStep_NotFound);

            dto.MapToEntity(step);
            var updated = await _roadmapStepRepo.UpdateAsync(step);

            Console.WriteLine(ApiMessages.RoadmapStepUpdated);
            return updated!.ToGetDto();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleted = await _roadmapStepRepo.DeleteAsync(id);
            if (!deleted)
                throw new Exception(ErrorMessages.RoadmapStep_NotFound);

            Console.WriteLine(ApiMessages.RoadmapStepDeleted);
            return true;
        }
    }
}