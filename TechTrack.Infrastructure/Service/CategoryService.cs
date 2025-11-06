using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechPathNavigator.Domain.Common.Errors;
using TechPathNavigator.Domain.Common.Results;
using TechTrack.Infrastructure.Extensions;
using TechTrack.Domain.Interfaces.IService;
using TechTrack.Domain.Models;
using TechTrack.DTOs.Category;
using TechTrack.Infrastructure.Data;

namespace TechTrack.Infrastructure.Service.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResult<IEnumerable<CategoryGetDto>>> GetAllAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            var dtoList = categories.ToGetDtoList();

            return ServiceResult<IEnumerable<CategoryGetDto>>.Ok(dtoList);
        }

        public async Task<ServiceResult<CategoryGetDto>> GetByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return ServiceResult<CategoryGetDto>.Fail(ErrorMessages.Category_NotFound);

            return ServiceResult<CategoryGetDto>.Ok(category.ToGetDto());
        }

        public async Task<ServiceResult<CategoryGetDto>> CreateAsync(CategoryCreateDto dto)
        {
            var exists = await _context.Categories.AnyAsync(c => c.CategoryName == dto.CategoryName);
            if (exists)
                return ServiceResult<CategoryGetDto>.Fail(ErrorMessages.Category_NameExists);

            var category = dto.ToEntity();
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return ServiceResult<CategoryGetDto>.Ok(category.ToGetDto());
        }

        public async Task<ServiceResult<CategoryGetDto>> UpdateAsync(int id, CategoryUpdateDto dto)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return ServiceResult<CategoryGetDto>.Fail(ErrorMessages.Category_NotFound);

            dto.MapToEntity(category);
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            return ServiceResult<CategoryGetDto>.Ok(category.ToGetDto());
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return ServiceResult<bool>.Fail(ErrorMessages.Category_NotFound);

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return ServiceResult<bool>.Ok(true);
        }
    }
}
