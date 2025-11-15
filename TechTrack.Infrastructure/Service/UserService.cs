using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechPathNavigator.Domain.Common.Errors;
using TechPathNavigator.Domain.Common.Messages;
using TechTrack.Domain.DTOs.User;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Interfaces.IService;
using TechTrack.Infrastructure.Extensions;

namespace TechTrack.Infrastructure.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<string> CreateAsync(UserCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.UserName))
                return ErrorMessages.User_NameRequired;

            if (string.IsNullOrWhiteSpace(dto.Email))
                return ErrorMessages.User_EmailRequired;

            if (await _userRepo.ExistsByEmailAsync(dto.Email))
                return ErrorMessages.User_EmailExists;

            var user = dto.ToModel();
            await _userRepo.AddAsync(user);
            return ApiMessages.UserCreated;
        }

        public async Task<string> DeleteAsync(int id)
        {
            var deleted = await _userRepo.DeleteAsync(id);
            if (!deleted)
                return ErrorMessages.User_NotFound;

            return ApiMessages.UserDeleted;
        }

        public async Task<IEnumerable<UserGetDto>> GetAllAsync()
        {
            var users = await _userRepo.GetAllAsync();
            return users.Select(u => u.ToGetDto());
        }

        public async Task<UserGetDto?> GetByIdAsync(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            return user?.ToGetDto();
        }

        public async Task<string> UpdateAsync(int id, UserUpdateDto dto)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null)
                return ErrorMessages.User_NotFound;

            user = dto.ToModel(user);
            await _userRepo.UpdateAsync(user);
            return ApiMessages.UserUpdated;
        }
    }
}