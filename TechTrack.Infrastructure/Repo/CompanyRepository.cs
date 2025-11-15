using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Models;

namespace TechTrack.Infrastructure.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly List<Company> _companies = new();
        private int _nextId = 1;

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await Task.FromResult(_companies.AsEnumerable());
        }

        public async Task<Company?> GetByIdAsync(int id)
        {
            return await Task.FromResult(_companies.FirstOrDefault(c => c.CompanyId == id));
        }

        public async Task<Company> AddAsync(Company company)
        {
            company.CompanyId = _nextId++;
            _companies.Add(company);
            return await Task.FromResult(company);
        }

        public async Task<Company?> UpdateAsync(Company company)
        {
            var existing = _companies.FirstOrDefault(c => c.CompanyId == company.CompanyId);
            if (existing == null)
                return null;

            existing.CompanyName = company.CompanyName;
            existing.Industry = company.Industry;
            existing.WebsiteUrl = company.WebsiteUrl;
            existing.Description = company.Description;

            return await Task.FromResult(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var company = _companies.FirstOrDefault(c => c.CompanyId == id);
            if (company == null)
                return false;

            _companies.Remove(company);
            return await Task.FromResult(true);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await Task.FromResult(_companies.Any(c => c.CompanyName == name));
        }
    }
}