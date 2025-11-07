using TechTrack.Domain.Models;
using TechTrack.DTOs.Technology;

namespace TechTrack.Infrastructure.Extensions
{
    public static class TechnologyMappingExtensions
    {
        public static Technology ToEntity(this TechnologyCreateDto dto)
        {
            return new Technology
            {
                TrackId = dto.TrackId,
                TechnologyName = dto.TechnologyName,
                Description = dto.Description,
                VideoUrl = dto.VideoUrl
            };
        }

        public static void MapToEntity(this TechnologyUpdateDto dto, Technology entity)
        {
            entity.TechnologyName = dto.TechnologyName;
            entity.Description = dto.Description;
            entity.VideoUrl = dto.VideoUrl;
        }

        public static TechnologyGetDto ToGetDto(this Technology entity)
        {
            return new TechnologyGetDto
            {
                TechnologyId = entity.TechnologyId,
                TechnologyName = entity.TechnologyName,
                Description = entity.Description,
                VideoUrl = entity.VideoUrl,
                TrackId = entity.TrackId,
                CreatedAt = entity.CreatedAt
            };
        }

        public static IEnumerable<TechnologyGetDto> ToGetDtoList(this IEnumerable<Technology> entities)
        {
            return entities.Select(e => e.ToGetDto()).ToList();
        }
    }
}
