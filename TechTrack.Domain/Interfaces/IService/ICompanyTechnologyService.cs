using System.Collections.Generic;
using System.Threading.Tasks;
using TechTrack.Domain.DTOs.CompanyTechnology;

namespace TechTrack.Domain.Interfaces.IService
{
    public interface ICompanyTechnologyService
    {
        Task<IEnumerable<CompanyTechnologyGetDto>> GetAllAsync();
        Task<CompanyTechnologyGetDto?> GetByIdAsync(int id);
        Task<string> CreateAsync(CompanyTechnologyCreateDto dto);
        Task<string> UpdateAsync(int id, CompanyTechnologyUpdateDto dto);
        Task<string> DeleteAsync(int id);
    }
}
