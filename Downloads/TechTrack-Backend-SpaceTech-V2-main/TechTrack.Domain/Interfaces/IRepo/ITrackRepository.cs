using System.Collections.Generic;
using System.Threading.Tasks;
using TechTrack.Domain.Models;

namespace TechTrack.Domain.Interfaces.IRepo
{
    public interface ITrackRepository
    {
        Task<IEnumerable<Track>> GetAllAsync();
        Task<Track?> GetByIdAsync(int id);
        Task AddAsync(Track track);
        Task UpdateAsync(Track track);
        Task DeleteAsync(Track track);
        Task<bool> ExistsAsync(int id);
    }
}
