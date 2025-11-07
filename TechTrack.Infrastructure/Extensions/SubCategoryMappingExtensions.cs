using System.Collections.Generic;
using System.Linq;
using TechTrack.Domain.DTOs.SubCategory;
using TechTrack.Domain.Models;
using TechTrack.DTOs.SubCategory;

namespace TechTrack.Infrastructure.Extensions
{
    public static class SubCategoryMappingExtensions
    {
        public static SubCategory ToEntity(this SubCategoryCreateDto dto)
        {
            return new SubCategory
            {
                CategoryId = dto.CategoryId,
                SubCategoryName = dto.SubCategoryName,
                Description = dto.Description,
                DifficultyLevel = dto.DifficultyLevel,
                EstimatedDuration = dto.EstimatedDuration,
                ImageUrl = null // ImageUrl will be set in service after upload
            };
        }

        public static void MapToEntity(this SubCategoryUpdateDto dto, SubCategory entity)
        {
            entity.CategoryId = dto.CategoryId;
            entity.SubCategoryName = dto.SubCategoryName;
            entity.Description = dto.Description;
            entity.DifficultyLevel = dto.DifficultyLevel;
            entity.EstimatedDuration = dto.EstimatedDuration;
            // ImageUrl is handled separately in the service
        }

        public static SubCategoryGetDto ToGetDto(this SubCategory entity)
        {
            return new SubCategoryGetDto
            {
                SubCategoryId = entity.SubCategoryId,
                CategoryId = entity.CategoryId,
                SubCategoryName = entity.SubCategoryName,
                Description = entity.Description,
                DifficultyLevel = entity.DifficultyLevel,
                EstimatedDuration = entity.EstimatedDuration,
                ImageUrl = entity.ImageUrl
            };
        }

        public static IEnumerable<SubCategoryGetDto> ToGetDtoList(this IEnumerable<SubCategory> entities)
        {
            return entities.Select(e => e.ToGetDto()).ToList();
        }
    }
}
