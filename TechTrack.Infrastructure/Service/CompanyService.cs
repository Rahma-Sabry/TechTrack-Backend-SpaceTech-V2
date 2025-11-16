using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechPathNavigator.Domain.Common.Errors;
using TechPathNavigator.Domain.Common.Messages;
using TechTrack.Domain.DTOs.Company;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Interfaces.IService;
using TechTrack.Infrastructure.Extensions;

namespace TechTrack.Infrastructure.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepo;

        public CompanyService(ICompanyRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }

        public async Task<string> CreateAsync(CompanyCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.CompanyName))
                return ErrorMessages.Company_NameRequired;

            if (await _companyRepo.ExistsByNameAsync(dto.CompanyName))
                return ErrorMessages.Company_NameExists;

            var company = dto.ToModel();
            await _companyRepo.AddAsync(company);
            return ApiMessages.CompanyCreated;
        }

        public async Task<string> DeleteAsync(int id)
        {
            var deleted = await _companyRepo.DeleteAsync(id);
            if (!deleted)
                return ErrorMessages.Company_NameRequired;

            return ApiMessages.CompanyDeleted;
        }

        public async Task<IEnumerable<CompanyGetDto>> GetAllAsync()
        {
            var companies = await _companyRepo.GetAllAsync();
            return companies.Select(c => c.ToGetDto());
        }

        public async Task<CompanyGetDto?> GetByIdAsync(int id)
        {
            var company = await _companyRepo.GetByIdAsync(id);
            return company?.ToGetDto();
        }

        public async Task<string> UpdateAsync(int id, CompanyUpdateDto dto)
        {
            var company = await _companyRepo.GetByIdAsync(id);
            if (company == null)
                return ErrorMessages.Company_NameRequired;

            company = dto.ToModel(company);
            await _companyRepo.UpdateAsync(company);
            return ApiMessages.CompanyUpdated;
        }
    }
}