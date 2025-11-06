using System.Collections.Generic;
using System.Linq;
using TechTrack.Domain.DTOs.RoadmapStep;
using TechTrack.Domain.Models;

namespace TechTrack.Domain.Extensions
{
    public static class RoadmapStepMappingExtensions
    {
        public static RoadmapStepGetDto ToGetDto(this RoadmapStep step)
        {
            return new RoadmapStepGetDto
            {
                RoadmapStepId = step.RoadmapStepId,
                RoadmapId = step.RoadmapId,
                StepTitle = step.StepTitle,
                StepDescription = step.StepDescription,
                StepOrder = step.StepOrder
            };
        }

        public static IEnumerable<RoadmapStepGetDto> ToGetDtoList(this IEnumerable<RoadmapStep> steps)
        {
            return steps.Select(s => s.ToGetDto());
        }

        public static RoadmapStep ToEntity(this RoadmapStepCreateDto dto)
        {
            return new RoadmapStep
            {
                RoadmapId = dto.RoadmapId,
                StepTitle = dto.StepTitle,
                StepDescription = dto.StepDescription,
                StepOrder = dto.StepOrder
            };
        }

        public static void MapToEntity(this RoadmapStepUpdateDto dto, RoadmapStep entity)
        {
            entity.StepTitle = dto.StepTitle;
            entity.StepDescription = dto.StepDescription;
            entity.StepOrder = dto.StepOrder;
        }
    }
}
