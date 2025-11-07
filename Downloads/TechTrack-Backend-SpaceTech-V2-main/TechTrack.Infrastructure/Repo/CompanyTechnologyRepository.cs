using TechTrack.Domain.Models;
using TechTrack.Domain.Interfaces.IRepo;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechTrack.Infrastructure.Repository
{
    public class CompanyTechnologyRepository : ICompanyTechnologyRepository
    {
        private readonly List<CompanyTechnology> _companyTechnologies = new();

        public async Task AddAsync(CompanyTechnology companyTech)
        {
            companyTech.CompanyTechnologyId = _companyTechnologies.Count + 1;
            _companyTechnologies.Add(companyTech);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(CompanyTechnology companyTech)
        {
            _companyTechnologies.Remove(companyTech);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<CompanyTechnology>> GetAllAsync()
        {
            return await Task.FromResult(_companyTechnologies);
        }

        public async Task<CompanyTechnology?> GetByIdAsync(int id)
        {
            return await Task.FromResult(_companyTechnologies.FirstOrDefault(ct => ct.CompanyTechnologyId == id));
        }

        public async Task UpdateAsync(CompanyTechnology companyTech)
        {
            var existing = _companyTechnologies.FirstOrDefault(ct => ct.CompanyTechnologyId == companyTech.CompanyTechnologyId);
            if (existing != null)
            {
                existing.CompanyId = companyTech.CompanyId;
                existing.TechnologyId = companyTech.TechnologyId;
                existing.UsageLevel = companyTech.UsageLevel;
                existing.Notes = companyTech.Notes;
            }
            await Task.CompletedTask;
        }

        public async Task<bool> ExistsPairAsync(int companyId, int technologyId)
        {
            return await Task.FromResult(_companyTechnologies.Any(ct => ct.CompanyId == companyId && ct.TechnologyId == technologyId));
        }
    }
}