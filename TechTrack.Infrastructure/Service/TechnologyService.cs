using System.Collections.Generic;
using System.Threading.Tasks;
using TechPathNavigator.Domain.Common.Errors;
using TechPathNavigator.Domain.Common.Results;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Interfaces.IService;
using TechTrack.DTOs.Technology;
using TechTrack.Infrastructure.Extensions;

namespace TechTrack.Infrastructure.Service.Technology
{
    public class TechnologyService : ITechnologyService
    {
        private readonly ITechnologyRepository _technologyRepo;

        public TechnologyService(ITechnologyRepository technologyRepo)
        {
            _technologyRepo = technologyRepo;
        }

        public async Task<ServiceResult<IEnumerable<TechnologyGetDto>>> GetAllAsync()
        {
            var techs = await _technologyRepo.GetAllAsync();
            return ServiceResult<IEnumerable<TechnologyGetDto>>.Ok(techs.ToGetDtoList());
        }

        public async Task<ServiceResult<TechnologyGetDto>> GetByIdAsync(int id)
        {
            var tech = await _technologyRepo.GetByIdAsync(id);
            if (tech == null)
                return ServiceResult<TechnologyGetDto>.Fail(ErrorMessages.Technology_NotFound);

            return ServiceResult<TechnologyGetDto>.Ok(tech.ToGetDto());
        }

        public async Task<ServiceResult<TechnologyGetDto>> CreateAsync(TechnologyCreateDto dto)
        {
            var entity = dto.ToEntity();
            var created = await _technologyRepo.AddAsync(entity);
            return ServiceResult<TechnologyGetDto>.Ok(created.ToGetDto());
        }

        public async Task<ServiceResult<TechnologyGetDto>> UpdateAsync(int id, TechnologyUpdateDto dto)
        {
            var entity = await _technologyRepo.GetByIdAsync(id);
            if (entity == null)
                return ServiceResult<TechnologyGetDto>.Fail(ErrorMessages.Technology_NotFound);

            dto.MapToEntity(entity);
            var updated = await _technologyRepo.UpdateAsync(entity);
            return ServiceResult<TechnologyGetDto>.Ok(updated!.ToGetDto());
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            var deleted = await _technologyRepo.DeleteAsync(id);
            if (!deleted)
                return ServiceResult<bool>.Fail(ErrorMessages.Technology_NotFound);

            return ServiceResult<bool>.Ok(true);
        }
    }
}