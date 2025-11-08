using Microsoft.EntityFrameworkCore;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Models;
using TechTrack.Infrastructure.Data;

namespace TechTrack.Infrastructure.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;

        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Company?> GetByIdAsync(int id)
        {
            return await _context.Companies
                .Include(c => c.CompanyTechnology)
                .FirstOrDefaultAsync(c => c.CompanyId == id);
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _context.Companies
                .Include(c => c.CompanyTechnology)
                .ToListAsync();
        }

        public async Task AddAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Company company)
        {
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Companies
                .AnyAsync(c => c.CompanyName.ToLower() == name.ToLower());
        }
    }
}
