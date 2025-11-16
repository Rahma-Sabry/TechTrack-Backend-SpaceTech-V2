using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Models;
using TechTrack.Infrastructure.Data;

namespace TechTrack.Infrastructure.Repo
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _dbSet.AnyAsync(c => c.CompanyName == name);
        }

        public override async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public override async Task<Company?> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.CompanyId == id);
        }
    }
}