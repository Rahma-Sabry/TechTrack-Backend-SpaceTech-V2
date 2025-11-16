using System.Collections.Generic;
using System.Linq;
using TechTrack.Domain.Models;
using TechTrack.DTOs.Roadmap;

namespace TechTrack.Infrastructure.Extensions
{
    public static class RoadmapMappingExtensions
    {
        public static RoadmapGetDto ToGetDto(this Roadmap roadmap)
        {
            if (roadmap == null) return null;

            return new RoadmapGetDto
            {
                RoadmapId = roadmap.RoadmapId,
                TechnologyId = roadmap.TechnologyId,
                Title = roadmap.Title,
                Description = roadmap.Description,
                Steps = roadmap.RoadmapSteps?
                    .OrderBy(rs => rs.StepOrder)
                    .Select(rs => rs.StepTitle)
                    .ToList() ?? new List<string>()
            };
        }

        public static IEnumerable<RoadmapGetDto> ToGetDtoList(this IEnumerable<Roadmap> roadmaps)
        {
            return roadmaps?.Select(r => r.ToGetDto()) ?? new List<RoadmapGetDto>();
        }

        public static Roadmap ToEntity(this RoadmapCreateDto dto)
        {
            if (dto == null) return null;

            return new Roadmap
            {
                TechnologyId = dto.TechnologyId,
                Title = dto.Title,
                Description = dto.Description,
                Steps = new List<string>()
            };
        }

        public static void MapToEntity(this RoadmapUpdateDto dto, Roadmap roadmap)
        {
            if (dto == null || roadmap == null) return;

            if (!string.IsNullOrEmpty(dto.Title))
                roadmap.Title = dto.Title;

            if (!string.IsNullOrEmpty(dto.Description))
                roadmap.Description = dto.Description;
        }
    }
}
