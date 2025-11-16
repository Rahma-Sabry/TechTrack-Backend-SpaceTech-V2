using System.Threading.Tasks;
using TechTrack.Domain.Models;

namespace TechTrack.Domain.Interfaces.IRepo
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<bool> ExistsByNameAsync(string name);
    }
}