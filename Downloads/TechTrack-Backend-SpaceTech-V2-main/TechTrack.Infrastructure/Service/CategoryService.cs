using Microsoft.EntityFrameworkCore;
using TechPathNavigator.Domain.Common.Errors;
using TechPathNavigator.Domain.Common.Results;
using TechTrack.Domain.Interfaces.IService;
using TechTrack.Domain.Models;
using TechTrack.DTOs.Category;
using TechTrack.Infrastructure.Data;

namespace TechTrack.Infrastructure.Service.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        private readonly ICloudinaryService _cloudinaryService;

        public CategoryService(AppDbContext context, ICloudinaryService cloudinaryService)
        {
            _context = context;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<ServiceResult<IEnumerable<CategoryGetDto>>> GetAllAsync()
        {
            try
            {
                var categories = await _context.Categories
                    .OrderByDescending(c => c.CreatedAt)
                    .ToListAsync();

                var dtoList = categories.Select(c => new CategoryGetDto
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                }).ToList();

                return ServiceResult<IEnumerable<CategoryGetDto>>.Ok(dtoList);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<CategoryGetDto>>.Fail($"Error retrieving categories: {ex.Message}");
            }
        }

        public async Task<ServiceResult<CategoryGetDto>> GetByIdAsync(int id)
        {
            try
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null)
                    return ServiceResult<CategoryGetDto>.Fail(ErrorMessages.Category_NotFound);

                var dto = new CategoryGetDto
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    Description = category.Description,
                    ImageUrl = category.ImageUrl,
                    CreatedAt = category.CreatedAt,
                    UpdatedAt = category.UpdatedAt
                };

                return ServiceResult<CategoryGetDto>.Ok(dto);
            }
            catch (Exception ex)
            {
                return ServiceResult<CategoryGetDto>.Fail($"Error retrieving category: {ex.Message}");
            }
        }

        public async Task<ServiceResult<CategoryGetDto>> CreateAsync(CategoryCreateDto dto)
        {
            try
            {
                // Check if category name already exists
                var exists = await _context.Categories
                    .AnyAsync(c => c.CategoryName.ToLower() == dto.CategoryName.ToLower());

                if (exists)
                    return ServiceResult<CategoryGetDto>.Fail(ErrorMessages.Category_NameExists);

                // Upload image if provided
                string? imageUrl = null;
                if (dto.Image != null)
                {
                    imageUrl = await _cloudinaryService.UploadImageAsync(dto.Image, "categories");
                }

                // Create entity
                var category = new TechTrack.Domain.Models.Category
                {
                    CategoryName = dto.CategoryName,
                    Description = dto.Description,
                    ImageUrl = imageUrl,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                _context.Categories.Add(category);
                await _context.SaveChangesAsync();

                var resultDto = new CategoryGetDto
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    Description = category.Description,
                    ImageUrl = category.ImageUrl,
                    CreatedAt = category.CreatedAt,
                    UpdatedAt = category.UpdatedAt
                };

                return ServiceResult<CategoryGetDto>.Ok(resultDto);
            }
            catch (Exception ex)
            {
                return ServiceResult<CategoryGetDto>.Fail($"Error creating category: {ex.Message}");
            }
        }

        public async Task<ServiceResult<CategoryGetDto>> UpdateAsync(int id, CategoryUpdateDto dto)
        {
            try
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null)
                    return ServiceResult<CategoryGetDto>.Fail(ErrorMessages.Category_NotFound);

                // Check if new name conflicts with existing categories (excluding current)
                var nameExists = await _context.Categories
                    .AnyAsync(c => c.CategoryName.ToLower() == dto.CategoryName.ToLower()
                                && c.CategoryId != id);

                if (nameExists)
                    return ServiceResult<CategoryGetDto>.Fail(ErrorMessages.Category_NameExists);

                // Handle image update/deletion
                if (dto.DeleteImage && !string.IsNullOrWhiteSpace(category.ImageUrl))
                {
                    // Delete existing image
                    var publicId = _cloudinaryService.ExtractPublicIdFromUrl(category.ImageUrl);
                    if (publicId != null)
                    {
                        await _cloudinaryService.DeleteImageAsync(publicId);
                    }
                    category.ImageUrl = null;
                }
                else if (dto.Image != null)
                {
                    // Delete old image if exists
                    if (!string.IsNullOrWhiteSpace(category.ImageUrl))
                    {
                        var oldPublicId = _cloudinaryService.ExtractPublicIdFromUrl(category.ImageUrl);
                        if (oldPublicId != null)
                        {
                            await _cloudinaryService.DeleteImageAsync(oldPublicId);
                        }
                    }

                    // Upload new image
                    category.ImageUrl = await _cloudinaryService.UploadImageAsync(dto.Image, "categories");
                }

                // Update other properties
                category.CategoryName = dto.CategoryName;
                category.Description = dto.Description;
                category.UpdatedAt = DateTime.UtcNow;

                _context.Categories.Update(category);
                await _context.SaveChangesAsync();

                var resultDto = new CategoryGetDto
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    Description = category.Description,
                    ImageUrl = category.ImageUrl,
                    CreatedAt = category.CreatedAt,
                    UpdatedAt = category.UpdatedAt
                };

                return ServiceResult<CategoryGetDto>.Ok(resultDto);
            }
            catch (Exception ex)
            {
                return ServiceResult<CategoryGetDto>.Fail($"Error updating category: {ex.Message}");
            }
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            try
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null)
                    return ServiceResult<bool>.Fail(ErrorMessages.Category_NotFound);

                // Delete image from Cloudinary if exists
                if (!string.IsNullOrWhiteSpace(category.ImageUrl))
                {
                    var publicId = _cloudinaryService.ExtractPublicIdFromUrl(category.ImageUrl);
                    if (publicId != null)
                    {
                        await _cloudinaryService.DeleteImageAsync(publicId);
                    }
                }

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

                return ServiceResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Fail($"Error deleting category: {ex.Message}");
            }
        }
    }
}
