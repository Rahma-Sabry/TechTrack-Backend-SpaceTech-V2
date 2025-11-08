using Microsoft.EntityFrameworkCore;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Models;
using TechTrack.Infrastructure.Data;

namespace TechTrack.Infrastructure.Repository
{
    public class CompanyTechnologyRepository : ICompanyTechnologyRepository
    {
        private readonly AppDbContext _context;

        public CompanyTechnologyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CompanyTechnology?> GetByIdAsync(int id)
        {
            return await _context.CompanyTechnologies
                .Include(ct => ct.Company)
                .Include(ct => ct.Technology)
                .FirstOrDefaultAsync(ct => ct.CompanyTechnologyId == id);
        }

        public async Task<IEnumerable<CompanyTechnology>> GetAllAsync()
        {
            return await _context.CompanyTechnologies
                .Include(ct => ct.Company)
                .Include(ct => ct.Technology)
                .ToListAsync();
        }

        public async Task AddAsync(CompanyTechnology companyTech)
        {
            await _context.CompanyTechnologies.AddAsync(companyTech);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CompanyTechnology companyTech)
        {
            _context.CompanyTechnologies.Update(companyTech);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(CompanyTechnology companyTech)
        {
            _context.CompanyTechnologies.Remove(companyTech);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsPairAsync(int companyId, int technologyId)
        {
            return await _context.CompanyTechnologies
                .AnyAsync(ct => ct.CompanyId == companyId && ct.TechnologyId == technologyId);
        }
    }
}
