using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechPathNavigator.Domain.Common.Errors;
using TechPathNavigator.Domain.Common.Results;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Interfaces.IService;
using TechTrack.Domain.Models;
using TechTrack.DTOs.Category;

namespace TechTrack.Infrastructure.Service.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly ICloudinaryService _cloudinaryService;

        public CategoryService(ICategoryRepository categoryRepo, ICloudinaryService cloudinaryService)
        {
            _categoryRepo = categoryRepo;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<ServiceResult<IEnumerable<CategoryGetDto>>> GetAllAsync()
        {
            try
            {
                var categories = await _categoryRepo.GetAllAsync();

                var dtoList = categories
                    .OrderByDescending(c => c.CreatedAt)
                    .Select(c => new CategoryGetDto
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
                var category = await _categoryRepo.GetByIdAsync(id);
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
                var allCategories = await _categoryRepo.GetAllAsync();
                var exists = allCategories.Any(c => c.CategoryName.ToLower() == dto.CategoryName.ToLower());

                if (exists)
                    return ServiceResult<CategoryGetDto>.Fail(ErrorMessages.Category_NameExists);

                string? imageUrl = null;
                if (dto.Image != null)
                {
                    imageUrl = await _cloudinaryService.UploadImageAsync(dto.Image, "categories");
                }

                var category = new TechTrack.Domain.Models.Category
                {
                    CategoryName = dto.CategoryName,
                    Description = dto.Description,
                    ImageUrl = imageUrl,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                var createdCategory = await _categoryRepo.AddAsync(category);

                var resultDto = new CategoryGetDto
                {
                    CategoryId = createdCategory.CategoryId,
                    CategoryName = createdCategory.CategoryName,
                    Description = createdCategory.Description,
                    ImageUrl = createdCategory.ImageUrl,
                    CreatedAt = createdCategory.CreatedAt,
                    UpdatedAt = createdCategory.UpdatedAt
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
                var category = await _categoryRepo.GetByIdAsync(id);
                if (category == null)
                    return ServiceResult<CategoryGetDto>.Fail(ErrorMessages.Category_NotFound);

                var allCategories = await _categoryRepo.GetAllAsync();
                var nameExists = allCategories.Any(c =>
                    c.CategoryName.ToLower() == dto.CategoryName.ToLower() && c.CategoryId != id);

                if (nameExists)
                    return ServiceResult<CategoryGetDto>.Fail(ErrorMessages.Category_NameExists);

                if (dto.DeleteImage && !string.IsNullOrWhiteSpace(category.ImageUrl))
                {
                    var publicId = _cloudinaryService.ExtractPublicIdFromUrl(category.ImageUrl);
                    if (publicId != null)
                    {
                        await _cloudinaryService.DeleteImageAsync(publicId);
                    }
                    category.ImageUrl = null;
                }
                else if (dto.Image != null)
                {
                    if (!string.IsNullOrWhiteSpace(category.ImageUrl))
                    {
                        var oldPublicId = _cloudinaryService.ExtractPublicIdFromUrl(category.ImageUrl);
                        if (oldPublicId != null)
                        {
                            await _cloudinaryService.DeleteImageAsync(oldPublicId);
                        }
                    }
                    category.ImageUrl = await _cloudinaryService.UploadImageAsync(dto.Image, "categories");
                }

                category.CategoryName = dto.CategoryName;
                category.Description = dto.Description;
                category.UpdatedAt = DateTime.UtcNow;

                var updatedCategory = await _categoryRepo.UpdateAsync(category);

                var resultDto = new CategoryGetDto
                {
                    CategoryId = updatedCategory!.CategoryId,
                    CategoryName = updatedCategory.CategoryName,
                    Description = updatedCategory.Description,
                    ImageUrl = updatedCategory.ImageUrl,
                    CreatedAt = updatedCategory.CreatedAt,
                    UpdatedAt = updatedCategory.UpdatedAt
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
                var category = await _categoryRepo.GetByIdAsync(id);
                if (category == null)
                    return ServiceResult<bool>.Fail(ErrorMessages.Category_NotFound);

                if (!string.IsNullOrWhiteSpace(category.ImageUrl))
                {
                    var publicId = _cloudinaryService.ExtractPublicIdFromUrl(category.ImageUrl);
                    if (publicId != null)
                    {
                        await _cloudinaryService.DeleteImageAsync(publicId);
                    }
                }

                var deleted = await _categoryRepo.DeleteAsync(id);

                return ServiceResult<bool>.Ok(deleted);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Fail($"Error deleting category: {ex.Message}");
            }
        }
    }
}