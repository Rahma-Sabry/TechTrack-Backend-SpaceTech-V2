using System.Collections.Generic;
using System.Threading.Tasks;
using TechPathNavigator.Domain.Common.Results;
using TechTrack.API.Extensions;
using TechTrack.Domain.DTOs.Track;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Interfaces.IService;

namespace TechTrack.Infrastructure.Service.Track
{
    public class TrackService : ITrackService
    {
        private readonly ITrackRepository _trackRepo;

        public TrackService(ITrackRepository trackRepo)
        {
            _trackRepo = trackRepo;
        }

        public async Task<ServiceResult<IEnumerable<TrackGetDto>>> GetAllAsync()
        {
            var tracks = await _trackRepo.GetAllAsync();
            return ServiceResult<IEnumerable<TrackGetDto>>.Ok(tracks.ToGetDtoList());
        }

        public async Task<ServiceResult<TrackGetDto>> GetByIdAsync(int id)
        {
            var track = await _trackRepo.GetByIdAsync(id);
            if (track == null)
                return ServiceResult<TrackGetDto>.Fail("Track not found");

            return ServiceResult<TrackGetDto>.Ok(track.ToGetDto());
        }

        public async Task<ServiceResult<TrackGetDto>> CreateAsync(TrackCreateDto dto)
        {
            var track = dto.ToEntity();
            var created = await _trackRepo.AddAsync(track);
            return ServiceResult<TrackGetDto>.Ok(created.ToGetDto());
        }

        public async Task<ServiceResult<TrackGetDto>> UpdateAsync(int id, TrackUpdateDto dto)
        {
            var track = await _trackRepo.GetByIdAsync(id);
            if (track == null)
                return ServiceResult<TrackGetDto>.Fail("Track not found");

            dto.MapToEntity(track);
            var updated = await _trackRepo.UpdateAsync(track);
            return ServiceResult<TrackGetDto>.Ok(updated!.ToGetDto());
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            var deleted = await _trackRepo.DeleteAsync(id);
            if (!deleted)
                return ServiceResult<bool>.Fail("Track not found");

            return ServiceResult<bool>.Ok(true);
        }
    }
}