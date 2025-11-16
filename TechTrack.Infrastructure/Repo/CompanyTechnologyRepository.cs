using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Models;
using TechTrack.Infrastructure.Data;

namespace TechTrack.Infrastructure.Repo
{
    public class CompanyTechnologyRepository : GenericRepository<CompanyTechnology>, ICompanyTechnologyRepository
    {
        public CompanyTechnologyRepository(AppDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<CompanyTechnology>> GetAllAsync()
        {
            return await _dbSet
                .Include(ct => ct.Company)
                .Include(ct => ct.Technology)
                .ToListAsync();
        }

        public override async Task<CompanyTechnology?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(ct => ct.Company)
                .Include(ct => ct.Technology)
                .FirstOrDefaultAsync(ct => ct.CompanyTechnologyId == id);
        }

        public async Task<bool> ExistsPairAsync(int companyId, int technologyId)
        {
            return await _dbSet.AnyAsync(ct => ct.CompanyId == companyId && ct.TechnologyId == technologyId);
        }
    }
}