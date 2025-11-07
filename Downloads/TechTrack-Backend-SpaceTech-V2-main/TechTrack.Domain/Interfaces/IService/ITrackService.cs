using System.Collections.Generic;
using System.Threading.Tasks;
using TechPathNavigator.Domain.Common.Results;
using TechTrack.Domain.DTOs.Track;

namespace TechTrack.Domain.Interfaces.IService
{
    public interface ITrackService
    {
        Task<ServiceResult<IEnumerable<TrackGetDto>>> GetAllAsync();
        Task<ServiceResult<TrackGetDto>> GetByIdAsync(int id);
        Task<ServiceResult<TrackGetDto>> CreateAsync(TrackCreateDto dto);
        Task<ServiceResult<TrackGetDto>> UpdateAsync(int id, TrackUpdateDto dto);
        Task<ServiceResult<bool>> DeleteAsync(int id);
    }
}
