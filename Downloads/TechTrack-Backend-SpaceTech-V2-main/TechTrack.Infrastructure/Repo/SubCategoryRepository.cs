using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Models;
using TechTrack.Infrastructure.Data;

namespace TechTrack.Infrastructure.Repo
{
    public class SubCategoryRepository : IGenericRepository<SubCategory>, ISubCategoryRepository
    {
        private readonly AppDbContext _context;

        public SubCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SubCategory>> GetAllAsync()
            => await _context.SubCategories.ToListAsync();

        public async Task<SubCategory?> GetByIdAsync(int id)
            => await _context.SubCategories.FindAsync(id);

        public async Task<SubCategory> AddAsync(SubCategory subCategory)
        {
            _context.SubCategories.Add(subCategory);
            await _context.SaveChangesAsync();
            return subCategory;
        }

        public async Task<SubCategory?> UpdateAsync(SubCategory subCategory)
        {
            _context.SubCategories.Update(subCategory);
            await _context.SaveChangesAsync();
            return subCategory;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var subCategory = await _context.SubCategories.FindAsync(id);
            if (subCategory == null) return false;

            _context.SubCategories.Remove(subCategory);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
