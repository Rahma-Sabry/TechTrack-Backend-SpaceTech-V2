using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechPathNavigator.Domain.Common.Errors;
using TechPathNavigator.Domain.Common.Messages;
using TechTrack.Domain.DTOs.Company;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Interfaces.IService;
using TechTrack.Domain.Models;
using TechTrack.DTOs;
using TechTrack.Infrastructure.Extensions;    

namespace TechTrack.Infrastructure.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repo;

        public CompanyService(ICompanyRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> CreateAsync(CompanyCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.CompanyName))
                return ErrorMessages.Company_NameRequired;

            if (await _repo.ExistsByNameAsync(dto.CompanyName))
                return ErrorMessages.Company_NameExists;

            var company = dto.ToModel(); // <-- mapping here

            await _repo.AddAsync(company);
            return ApiMessages.CompanyCreated;
        }

        public async Task<string> DeleteAsync(int id)
        {
            var company = await _repo.GetByIdAsync(id);
            if (company == null) return ErrorMessages.Company_NameRequired;

            await _repo.DeleteAsync(company);
            return ApiMessages.CompanyDeleted;
        }

        public async Task<IEnumerable<CompanyGetDto>> GetAllAsync()
        {
            var companies = await _repo.GetAllAsync();
            return companies.Select(c => c.ToGetDto()); // <-- mapping here
        }

        public async Task<CompanyGetDto?> GetByIdAsync(int id)
        {
            var company = await _repo.GetByIdAsync(id);
            if (company == null) return null;

            return company.ToGetDto(); // <-- mapping here
        }

        public async Task<string> UpdateAsync(int id, CompanyUpdateDto dto)
        {
            var company = await _repo.GetByIdAsync(id);
            if (company == null) return ErrorMessages.Company_NameRequired;

            company = dto.ToModel(company); // <-- mapping here

            await _repo.UpdateAsync(company);
            return ApiMessages.CompanyUpdated;
        }
    }
}
