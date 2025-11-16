using System.Threading.Tasks;
using TechTrack.Domain.Models;

namespace TechTrack.Domain.Interfaces.IRepo
{
    public interface ICompanyTechnologyRepository : IGenericRepository<CompanyTechnology>
    {
        Task<bool> ExistsPairAsync(int companyId, int technologyId);
    }
}