using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechPathNavigator.Domain.Common.Results;
using TechTrack.Domain.DTOs.SubCategory;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Interfaces.IService;
using TechTrack.DTOs.SubCategory;
using TechTrack.Infrastructure.Extensions;

namespace TechTrack.Infrastructure.Service.SubCategory
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepo;
        private readonly ICloudinaryService _cloudinaryService;

        public SubCategoryService(ISubCategoryRepository subCategoryRepo, ICloudinaryService cloudinaryService)
        {
            _subCategoryRepo = subCategoryRepo;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<ServiceResult<IEnumerable<SubCategoryGetDto>>> GetAllAsync()
        {
            var items = await _subCategoryRepo.GetAllAsync();
            return ServiceResult<IEnumerable<SubCategoryGetDto>>.Ok(items.ToGetDtoList());
        }

        public async Task<ServiceResult<SubCategoryGetDto>> GetByIdAsync(int id)
        {
            var item = await _subCategoryRepo.GetByIdAsync(id);
            if (item == null)
                return ServiceResult<SubCategoryGetDto>.Fail("Not found");

            return ServiceResult<SubCategoryGetDto>.Ok(item.ToGetDto());
        }

        public async Task<ServiceResult<SubCategoryGetDto>> CreateAsync(SubCategoryCreateDto dto)
        {
            try
            {
                var allSubCategories = await _subCategoryRepo.GetAllAsync();
                var exists = allSubCategories.Any(sc =>
                    sc.SubCategoryName.ToLower() == dto.SubCategoryName.ToLower());

                if (exists)
                    return ServiceResult<SubCategoryGetDto>.Fail("SubCategory name already exists");

                string? imageUrl = null;
                if (dto.Image != null)
                {
                    imageUrl = await _cloudinaryService.UploadImageAsync(dto.Image, "subcategories");
                }

                var entity = new TechTrack.Domain.Models.SubCategory
                {
                    CategoryId = dto.CategoryId,
                    SubCategoryName = dto.SubCategoryName,
                    Description = dto.Description,
                    DifficultyLevel = dto.DifficultyLevel,
                    EstimatedDuration = dto.EstimatedDuration,
                    ImageUrl = imageUrl
                };

                var created = await _subCategoryRepo.AddAsync(entity);

                var resultDto = new SubCategoryGetDto
                {
                    SubCategoryId = created.SubCategoryId,
                    CategoryId = created.CategoryId,
                    SubCategoryName = created.SubCategoryName,
                    Description = created.Description,
                    DifficultyLevel = created.DifficultyLevel,
                    EstimatedDuration = created.EstimatedDuration,
                    ImageUrl = created.ImageUrl
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
                var entity = await _subCategoryRepo.GetByIdAsync(id);
                if (entity == null)
                    return ServiceResult<SubCategoryGetDto>.Fail("SubCategory not found");

                var allSubCategories = await _subCategoryRepo.GetAllAsync();
                var nameExists = allSubCategories.Any(sc =>
                    sc.SubCategoryName.ToLower() == dto.SubCategoryName.ToLower() &&
                    sc.SubCategoryId != id);

                if (nameExists)
                    return ServiceResult<SubCategoryGetDto>.Fail("SubCategory name already exists");

                if (dto.DeleteImage && !string.IsNullOrWhiteSpace(entity.ImageUrl))
                {
                    var publicId = _cloudinaryService.ExtractPublicIdFromUrl(entity.ImageUrl);
                    if (publicId != null)
                    {
                        await _cloudinaryService.DeleteImageAsync(publicId);
                    }
                    entity.ImageUrl = null;
                }
                else if (dto.Image != null)
                {
                    if (!string.IsNullOrWhiteSpace(entity.ImageUrl))
                    {
                        var oldPublicId = _cloudinaryService.ExtractPublicIdFromUrl(entity.ImageUrl);
                        if (oldPublicId != null)
                        {
                            await _cloudinaryService.DeleteImageAsync(oldPublicId);
                        }
                    }
                    entity.ImageUrl = await _cloudinaryService.UploadImageAsync(dto.Image, "subcategories");
                }

                entity.CategoryId = dto.CategoryId;
                entity.SubCategoryName = dto.SubCategoryName;
                entity.Description = dto.Description;
                entity.DifficultyLevel = dto.DifficultyLevel;
                entity.EstimatedDuration = dto.EstimatedDuration;

                var updated = await _subCategoryRepo.UpdateAsync(entity);

                var resultDto = new SubCategoryGetDto
                {
                    SubCategoryId = updated!.SubCategoryId,
                    CategoryId = updated.CategoryId,
                    SubCategoryName = updated.SubCategoryName,
                    Description = updated.Description,
                    DifficultyLevel = updated.DifficultyLevel,
                    EstimatedDuration = updated.EstimatedDuration,
                    ImageUrl = updated.ImageUrl
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
                var entity = await _subCategoryRepo.GetByIdAsync(id);
                if (entity == null)
                    return ServiceResult<bool>.Fail("SubCategory not found");

                if (!string.IsNullOrWhiteSpace(entity.ImageUrl))
                {
                    var publicId = _cloudinaryService.ExtractPublicIdFromUrl(entity.ImageUrl);
                    if (publicId != null)
                    {
                        await _cloudinaryService.DeleteImageAsync(publicId);
                    }
                }

                var deleted = await _subCategoryRepo.DeleteAsync(id);

                return ServiceResult<bool>.Ok(deleted);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Fail($"Error deleting subcategory: {ex.Message}");
            }
        }
    }
}