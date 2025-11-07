using TechTrack.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechTrack.Domain.Interfaces.IRepo
{
    public interface ICompanyTechnologyRepository
    {
        Task<CompanyTechnology?> GetByIdAsync(int id);
        Task<IEnumerable<CompanyTechnology>> GetAllAsync();
        Task AddAsync(CompanyTechnology companyTech);
        Task UpdateAsync(CompanyTechnology companyTech);
        Task DeleteAsync(CompanyTechnology companyTech);
        Task<bool> ExistsPairAsync(int companyId, int technologyId);
    }
}