using TechTrack.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechTrack.Domain.Interfaces.IRepo
{
    public interface ICompanyRepository
    {
        Task<Company?> GetByIdAsync(int id);
        Task<IEnumerable<Company>> GetAllAsync();
        Task AddAsync(Company company);
        Task UpdateAsync(Company company);
        Task DeleteAsync(Company company);
        Task<bool> ExistsByNameAsync(string name);
    }
}