using System.Collections.Generic;
using System.Linq;
using TechTrack.Domain.DTOs.Track;
using TechTrack.Domain.Models;
namespace TechTrack.API.Extensions
{
    public static class TrackMappingExtensions
    {
        public static Track ToEntity(this TrackCreateDto dto)
        {
            return new Track
            {
                TrackName = dto.TrackName,
                Description = dto.Description,
                DifficultyLevel = dto.DifficultyLevel,
                EstimatedDuration = dto.EstimatedDuration,
                SubCategoryId = dto.SubCategoryId
            };
        }

        public static void MapToEntity(this TrackUpdateDto dto, Track entity)
        {
            entity.TrackName = dto.TrackName;
            entity.Description = dto.Description;
            entity.DifficultyLevel = dto.DifficultyLevel;
            entity.EstimatedDuration = dto.EstimatedDuration;
            entity.SubCategoryId = dto.SubCategoryId;
        }

        public static TrackGetDto ToGetDto(this Track entity)
        {
            return new TrackGetDto
            {
                TrackId = entity.TrackId,
                TrackName = entity.TrackName,
                Description = entity.Description,
                DifficultyLevel = entity.DifficultyLevel,
                EstimatedDuration = entity.EstimatedDuration,
                SubCategoryId = entity.SubCategoryId
            };
        }

        public static IEnumerable<TrackGetDto> ToGetDtoList(this IEnumerable<Track> entities)
        {
            return entities.Select(e => e.ToGetDto()).ToList();
        }
    }
}
