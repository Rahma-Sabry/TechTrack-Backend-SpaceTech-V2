using System.Collections.Generic;
using System.Threading.Tasks;
using TechTrack.Domain.DTOs.User;

namespace TechTrack.Domain.Interfaces.IService
{
    public interface IUserService
    {
        Task<IEnumerable<UserGetDto>> GetAllAsync();
        Task<UserGetDto?> GetByIdAsync(int id);
        Task<string> CreateAsync(UserCreateDto dto);
        Task<string> UpdateAsync(int id, UserUpdateDto dto);
        Task<string> DeleteAsync(int id);
    }
}