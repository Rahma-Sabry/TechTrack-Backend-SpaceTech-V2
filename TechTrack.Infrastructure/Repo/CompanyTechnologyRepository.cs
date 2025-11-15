using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Models;

namespace TechTrack.Infrastructure.Repository
{
    public class CompanyTechnologyRepository : ICompanyTechnologyRepository
    {
        private readonly List<CompanyTechnology> _companyTechnologies = new();
        private int _nextId = 1;

        public async Task<IEnumerable<CompanyTechnology>> GetAllAsync()
        {
            return await Task.FromResult(_companyTechnologies.AsEnumerable());
        }

        public async Task<CompanyTechnology?> GetByIdAsync(int id)
        {
            return await Task.FromResult(_companyTechnologies.FirstOrDefault(ct => ct.CompanyTechnologyId == id));
        }

        public async Task<CompanyTechnology> AddAsync(CompanyTechnology companyTech)
        {
            companyTech.CompanyTechnologyId = _nextId++;
            _companyTechnologies.Add(companyTech);
            return await Task.FromResult(companyTech);
        }

        public async Task<CompanyTechnology?> UpdateAsync(CompanyTechnology companyTech)
        {
            var existing = _companyTechnologies.FirstOrDefault(ct => ct.CompanyTechnologyId == companyTech.CompanyTechnologyId);
            if (existing == null)
                return null;

            existing.CompanyId = companyTech.CompanyId;
            existing.TechnologyId = companyTech.TechnologyId;
            existing.UsageLevel = companyTech.UsageLevel;
            existing.Notes = companyTech.Notes;

            return await Task.FromResult(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var companyTech = _companyTechnologies.FirstOrDefault(ct => ct.CompanyTechnologyId == id);
            if (companyTech == null)
                return false;

            _companyTechnologies.Remove(companyTech);
            return await Task.FromResult(true);
        }

        public async Task<bool> ExistsPairAsync(int companyId, int technologyId)
        {
            return await Task.FromResult(_companyTechnologies.Any(ct => ct.CompanyId == companyId && ct.TechnologyId == technologyId));
        }
    }
}