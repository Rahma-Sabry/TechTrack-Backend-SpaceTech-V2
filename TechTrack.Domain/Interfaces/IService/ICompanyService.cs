using System.Collections.Generic;
using System.Threading.Tasks;
using TechTrack.Domain.DTOs.Company;

namespace TechTrack.Domain.Interfaces.IService
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyGetDto>> GetAllAsync();
        Task<CompanyGetDto?> GetByIdAsync(int id);
        Task<string> CreateAsync(CompanyCreateDto dto);
        Task<string> UpdateAsync(int id, CompanyUpdateDto dto);
        Task<string> DeleteAsync(int id);
    }
}