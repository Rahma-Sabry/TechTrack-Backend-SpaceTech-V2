using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechPathNavigator.Domain.Common.Results;
using TechTrack.API.Extensions;
using TechTrack.Domain.DTOs.Track;
using TechTrack.Domain.Interfaces.IService;
using TechTrack.Domain.Models;
using TechTrack.Infrastructure.Data;

namespace TechTrack.Infrastructure.Service.Track
{
    public class TrackService : ITrackService
    {
        private readonly AppDbContext _context;

        public TrackService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResult<IEnumerable<TrackGetDto>>> GetAllAsync()
        {
            var tracks = await _context.Tracks.ToListAsync();
            return ServiceResult<IEnumerable<TrackGetDto>>.Ok(tracks.ToGetDtoList());
        }

        public async Task<ServiceResult<TrackGetDto>> GetByIdAsync(int id)
        {
            var track = await _context.Tracks.FindAsync(id);
            return ServiceResult<TrackGetDto>.Ok(track.ToGetDto());
        }

        public async Task<ServiceResult<TrackGetDto>> CreateAsync(TrackCreateDto dto)
        {
            var track = dto.ToEntity();
            _context.Tracks.Add(track);
            await _context.SaveChangesAsync();
            return ServiceResult<TrackGetDto>.Ok(track.ToGetDto());
        }

        public async Task<ServiceResult<TrackGetDto>> UpdateAsync(int id, TrackUpdateDto dto)
        {
            var track = await _context.Tracks.FindAsync(id);
            dto.MapToEntity(track);
            _context.Tracks.Update(track);
            await _context.SaveChangesAsync();
            return ServiceResult<TrackGetDto>.Ok(track.ToGetDto());
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            var track = await _context.Tracks.FindAsync(id);
            _context.Tracks.Remove(track);
            await _context.SaveChangesAsync();
            return ServiceResult<bool>.Ok(true);
        }
    }
}
