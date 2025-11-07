using Microsoft.EntityFrameworkCore;
using TechPathNavigator.Domain.Common.Results;
using TechPathNavigator.Domain.Common.Errors;
using TechTrack.Domain.Interfaces.IService;
using TechTrack.DTOs.Technology;
using TechTrack.Infrastructure.Data;
using TechTrack.Infrastructure.Extensions;

namespace TechTrack.Infrastructure.Service.Technology
{
    public class TechnologyService : ITechnologyService
    {
        private readonly AppDbContext _context;

        public TechnologyService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResult<IEnumerable<TechnologyGetDto>>> GetAllAsync()
        {
            var techs = await _context.Technologies.Include(t => t.Track).ToListAsync();
            return ServiceResult<IEnumerable<TechnologyGetDto>>.Ok(techs.ToGetDtoList());
        }

        public async Task<ServiceResult<TechnologyGetDto>> GetByIdAsync(int id)
        {
            var tech = await _context.Technologies.FindAsync(id);
            if (tech == null)
                return ServiceResult<TechnologyGetDto>.Fail(ErrorMessages.Technology_NotFound);

            return ServiceResult<TechnologyGetDto>.Ok(tech.ToGetDto());
        }

        public async Task<ServiceResult<TechnologyGetDto>> CreateAsync(TechnologyCreateDto dto)
        {
            var entity = dto.ToEntity();
            _context.Technologies.Add(entity);
            await _context.SaveChangesAsync();
            return ServiceResult<TechnologyGetDto>.Ok(entity.ToGetDto());
        }

        public async Task<ServiceResult<TechnologyGetDto>> UpdateAsync(int id, TechnologyUpdateDto dto)
        {
            var entity = await _context.Technologies.FindAsync(id);
            if (entity == null)
                return ServiceResult<TechnologyGetDto>.Fail(ErrorMessages.Technology_NotFound);

            dto.MapToEntity(entity);
            _context.Technologies.Update(entity);
            await _context.SaveChangesAsync();
            return ServiceResult<TechnologyGetDto>.Ok(entity.ToGetDto());
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            var entity = await _context.Technologies.FindAsync(id);
            if (entity == null)
                return ServiceResult<bool>.Fail(ErrorMessages.Technology_NotFound);

            _context.Technologies.Remove(entity);
            await _context.SaveChangesAsync();
            return ServiceResult<bool>.Ok(true);
        }
    }
}
