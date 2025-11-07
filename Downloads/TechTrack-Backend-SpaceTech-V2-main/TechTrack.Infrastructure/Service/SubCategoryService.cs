using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechPathNavigator.Domain.Common.Errors;
using TechPathNavigator.Domain.Common.Results;
using TechTrack.Domain.DTOs.SubCategory;
using TechTrack.Domain.Interfaces.IService;
using TechTrack.Domain.Models;
using TechTrack.DTOs.SubCategory;
using TechTrack.Infrastructure.Data;
using TechTrack.Infrastructure.Extensions;

namespace TechTrack.Infrastructure.Service.SubCategory
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly AppDbContext _context;
        private readonly ICloudinaryService _cloudinaryService;

        public SubCategoryService(AppDbContext context, ICloudinaryService cloudinaryService)
        {
            _context = context;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<ServiceResult<IEnumerable<SubCategoryGetDto>>> GetAllAsync()
        {
            var items = await _context.SubCategories.ToListAsync();
            return ServiceResult<IEnumerable<SubCategoryGetDto>>.Ok(items.ToGetDtoList());
        }

        public async Task<ServiceResult<SubCategoryGetDto>> GetByIdAsync(int id)
        {
            var item = await _context.SubCategories.FindAsync(id);
            if (item == null) return ServiceResult<SubCategoryGetDto>.Fail("Not found");

            return ServiceResult<SubCategoryGetDto>.Ok(item.ToGetDto());
        }

        public async Task<ServiceResult<SubCategoryGetDto>> CreateAsync(SubCategoryCreateDto dto)
        {
            try
            {
                // Check if subcategory name already exists
                var exists = await _context.SubCategories
                    .AnyAsync(sc => sc.SubCategoryName.ToLower() == dto.SubCategoryName.ToLower());

                if (exists)
                    return ServiceResult<SubCategoryGetDto>.Fail("SubCategory name already exists");

                // Upload image if provided
                string? imageUrl = null;
                if (dto.Image != null)
                {
                    imageUrl = await _cloudinaryService.UploadImageAsync(dto.Image, "subcategories");
                }

                // Create entity
                var entity = new TechTrack.Domain.Models.SubCategory
                {
                    CategoryId = dto.CategoryId,
                    SubCategoryName = dto.SubCategoryName,
                    Description = dto.Description,
                    DifficultyLevel = dto.DifficultyLevel,
                    EstimatedDuration = dto.EstimatedDuration,
                    ImageUrl = imageUrl
                };

                _context.SubCategories.Add(entity);
                await _context.SaveChangesAsync();

                var resultDto = new SubCategoryGetDto
                {
                    SubCategoryId = entity.SubCategoryId,
                    CategoryId = entity.CategoryId,
                    SubCategoryName = entity.SubCategoryName,
                    Description = entity.Description,
                    DifficultyLevel = entity.DifficultyLevel,
                    EstimatedDuration = entity.EstimatedDuration,
                    ImageUrl = entity.ImageUrl
                };

                return ServiceResult<SubCategoryGetDto>.Ok(resultDto);
            }
            catch (Exception ex)
            {
                return ServiceResult<SubCategoryGetDto>.Fail($"Error creating subcategory: {ex.Message}");
            }
        }

        public async Task<ServiceResult<SubCategoryGetDto>> UpdateAsync(int id, SubCategoryUpdateDto dto)
        {
            try
            {
                var entity = await _context.SubCategories.FindAsync(id);
                if (entity == null)
                    return ServiceResult<SubCategoryGetDto>.Fail("SubCategory not found");

                // Check if new name conflicts with existing subcategories (excluding current)
                var nameExists = await _context.SubCategories
                    .AnyAsync(sc => sc.SubCategoryName.ToLower() == dto.SubCategoryName.ToLower()
                                && sc.SubCategoryId != id);

                if (nameExists)
                    return ServiceResult<SubCategoryGetDto>.Fail("SubCategory name already exists");

                // Handle image update/deletion
                if (dto.DeleteImage && !string.IsNullOrWhiteSpace(entity.ImageUrl))
                {
                    // Delete existing image
                    var publicId = _cloudinaryService.ExtractPublicIdFromUrl(entity.ImageUrl);
                    if (publicId != null)
                    {
                        await _cloudinaryService.DeleteImageAsync(publicId);
                    }
                    entity.ImageUrl = null;
                }
                else if (dto.Image != null)
                {
                    // Delete old image if exists
                    if (!string.IsNullOrWhiteSpace(entity.ImageUrl))
                    {
                        var oldPublicId = _cloudinaryService.ExtractPublicIdFromUrl(entity.ImageUrl);
                        if (oldPublicId != null)
                        {
                            await _cloudinaryService.DeleteImageAsync(oldPublicId);
                        }
                    }

                    // Upload new image
                    entity.ImageUrl = await _cloudinaryService.UploadImageAsync(dto.Image, "subcategories");
                }

                // Update other properties
                entity.CategoryId = dto.CategoryId;
                entity.SubCategoryName = dto.SubCategoryName;
                entity.Description = dto.Description;
                entity.DifficultyLevel = dto.DifficultyLevel;
                entity.EstimatedDuration = dto.EstimatedDuration;

                _context.SubCategories.Update(entity);
                await _context.SaveChangesAsync();

                var resultDto = new SubCategoryGetDto
                {
                    SubCategoryId = entity.SubCategoryId,
                    CategoryId = entity.CategoryId,
                    SubCategoryName = entity.SubCategoryName,
                    Description = entity.Description,
                    DifficultyLevel = entity.DifficultyLevel,
                    EstimatedDuration = entity.EstimatedDuration,
                    ImageUrl = entity.ImageUrl
                };

                return ServiceResult<SubCategoryGetDto>.Ok(resultDto);
            }
            catch (Exception ex)
            {
                return ServiceResult<SubCategoryGetDto>.Fail($"Error updating subcategory: {ex.Message}");
            }
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _context.SubCategories.FindAsync(id);
                if (entity == null)
                    return ServiceResult<bool>.Fail("SubCategory not found");

                // Delete image from Cloudinary if exists
                if (!string.IsNullOrWhiteSpace(entity.ImageUrl))
                {
                    var publicId = _cloudinaryService.ExtractPublicIdFromUrl(entity.ImageUrl);
                    if (publicId != null)
                    {
                        await _cloudinaryService.DeleteImageAsync(publicId);
                    }
                }

                _context.SubCategories.Remove(entity);
                await _context.SaveChangesAsync();

                return ServiceResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Fail($"Error deleting subcategory: {ex.Message}");
            }
        }
    }
}
