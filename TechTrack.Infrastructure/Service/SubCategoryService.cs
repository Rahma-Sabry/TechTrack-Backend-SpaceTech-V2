using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public SubCategoryService(AppDbContext context)
        {
            _context = context;
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
            var entity = dto.ToEntity();
            _context.SubCategories.Add(entity);
            await _context.SaveChangesAsync();

            return ServiceResult<SubCategoryGetDto>.Ok(entity.ToGetDto());
        }

        public async Task<ServiceResult<SubCategoryGetDto>> UpdateAsync(int id, SubCategoryUpdateDto dto)
        {
            var entity = await _context.SubCategories.FindAsync(id);
            if (entity == null) return ServiceResult<SubCategoryGetDto>.Fail("Not found");

            dto.MapToEntity(entity);
            _context.SubCategories.Update(entity);
            await _context.SaveChangesAsync();

            return ServiceResult<SubCategoryGetDto>.Ok(entity.ToGetDto());
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            var entity = await _context.SubCategories.FindAsync(id);
            if (entity == null) return ServiceResult<bool>.Fail("Not found");

            _context.SubCategories.Remove(entity);
            await _context.SaveChangesAsync();
            return ServiceResult<bool>.Ok(true);
        }
    }
}
