using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTrack.Domain.DTOs.CompanyTechnology;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Interfaces.IService;
using TechTrack.Domain.Models;
using TechTrack.DTOs;

namespace TechTrack.Infrastructure.Service
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