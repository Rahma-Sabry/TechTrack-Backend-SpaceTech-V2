using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechPathNavigator.Domain.Common.Errors;
using TechPathNavigator.Domain.Common.Messages;
using TechTrack.Domain.DTOs.CompanyTechnology;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Interfaces.IService;
using TechTrack.Infrastructure.Extensions;

namespace TechTrack.Infrastructure.Service
{
    public class CompanyTechnologyService : ICompanyTechnologyService
    {
        private readonly ICompanyTechnologyRepository _companyTechRepo;

        public CompanyTechnologyService(ICompanyTechnologyRepository companyTechRepo)
        {
            _companyTechRepo = companyTechRepo;
        }

        public async Task<string> CreateAsync(CompanyTechnologyCreateDto dto)
        {
            if (await _companyTechRepo.ExistsPairAsync(dto.CompanyId, dto.TechnologyId))
                return ErrorMessages.CompanyTechnology_PairExists;

            var companyTech = dto.ToModel();
            await _companyTechRepo.AddAsync(companyTech);
            return ApiMessages.CompanyTechnologyCreated;
        }

        public async Task<string> DeleteAsync(int id)
        {
            var deleted = await _companyTechRepo.DeleteAsync(id);
            if (!deleted)
                return ErrorMessages.CompanyTechnology_CompanyInvalid;

            return ApiMessages.CompanyTechnologyDeleted;
        }

        public async Task<IEnumerable<CompanyTechnologyGetDto>> GetAllAsync()
        {
            var cts = await _companyTechRepo.GetAllAsync();
            return cts.Select(ct => ct.ToGetDto());
        }

        public async Task<CompanyTechnologyGetDto?> GetByIdAsync(int id)
        {
            var ct = await _companyTechRepo.GetByIdAsync(id);
            return ct?.ToGetDto();
        }

        public async Task<string> UpdateAsync(int id, CompanyTechnologyUpdateDto dto)
        {
            var ct = await _companyTechRepo.GetByIdAsync(id);
            if (ct == null)
                return ErrorMessages.CompanyTechnology_CompanyInvalid;

            ct = dto.ToModel(ct);
            await _companyTechRepo.UpdateAsync(ct);
            return ApiMessages.CompanyTechnologyUpdated;
        }
    }
}