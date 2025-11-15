using System.Threading.Tasks;
using TechTrack.Domain.Models;

namespace TechTrack.Domain.Interfaces.IRepo
{
    public interface ITrackRepository : IGenericRepository<Track>
    {
        Task<bool> ExistsAsync(int id);
    }
}