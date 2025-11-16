using System.Collections.Generic;
using System.Threading.Tasks;
using TechTrack.Domain.Models;

namespace TechTrack.Domain.Interfaces.IRepo
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        // All methods inherited from IGenericRepository
        // GetAllAsync and GetByIdAsync are overridden to include SubCategories
    }
}