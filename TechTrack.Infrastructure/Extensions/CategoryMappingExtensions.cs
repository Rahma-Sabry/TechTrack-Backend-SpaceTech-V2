using System.Collections.Generic;
using System.Linq;
using TechTrack.Domain.Models;
using TechTrack.DTOs.Category;

namespace TechTrack.Infrastructure.Extensions
{
    public static class CategoryMappingExtensions
    {
        public static Category ToEntity(this CategoryCreateDto dto)
        {
            return new Category
            {
                CategoryName = dto.CategoryName,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl
            };
        }

        public static void MapToEntity(this CategoryUpdateDto dto, Category entity)
        {
            entity.CategoryName = dto.CategoryName;
            entity.Description = dto.Description;
            entity.ImageUrl = dto.ImageUrl;
        }

        public static CategoryGetDto ToGetDto(this Category entity)
        {
            return new CategoryGetDto
            {
                CategoryId = entity.CategoryId,
                CategoryName = entity.CategoryName,
                Description = entity.Description,
                ImageUrl = entity.ImageUrl
            };
        }

        public static IEnumerable<CategoryGetDto> ToGetDtoList(this IEnumerable<Category> entities)
        {
            return entities.Select(e => e.ToGetDto()).ToList();
        }
    }
}
