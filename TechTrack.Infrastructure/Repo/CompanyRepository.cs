
using TechTrack.Domain.Models;
using TechTrack.Domain.Interfaces.IRepo;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechTrack.Infrastructure.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly List<Company> _companies = new();

        public async Task AddAsync(Company company)
        {
            company.CompanyId = _companies.Count + 1;
            _companies.Add(company);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Company company)
        {
            _companies.Remove(company);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await Task.FromResult(_companies);
        }

        public async Task<Company?> GetByIdAsync(int id)
        {
            return await Task.FromResult(_companies.FirstOrDefault(c => c.CompanyId == id));
        }

        public async Task UpdateAsync(Company company)
        {
            var existing = _companies.FirstOrDefault(c => c.CompanyId == company.CompanyId);
            if (existing != null)
            {
                existing.CompanyName = company.CompanyName;
                existing.Industry = company.Industry;
                existing.WebsiteUrl = company.WebsiteUrl;
                existing.Description = company.Description;
            }
            await Task.CompletedTask;
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await Task.FromResult(_companies.Any(c => c.CompanyName == name));
        }
    }
}
