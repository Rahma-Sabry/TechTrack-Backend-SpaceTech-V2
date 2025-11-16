using System.Security.Cryptography;
using System.Text;
using TechTrack.Domain.DTOs.User;
using TechTrack.Domain.Models;
using TechTrack.DTOs;

namespace TechTrack.Infrastructure.Extensions
{
    public static class UserMappingExtensions
    {
        public static UserGetDto ToGetDto(this User user)
        {
            if (user == null) return null!;
            return new UserGetDto
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email
            };
        }

        public static User ToModel(this UserCreateDto dto)
        {
            if (dto == null) return null!;
            return new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                PasswordHash = HashPassword(dto.Password)
            };
        }

        public static User ToModel(this UserUpdateDto dto, User existing)
        {
            if (dto == null || existing == null) return existing;

            existing.UserName = dto.UserName;
            existing.Email = dto.Email;
            if (!string.IsNullOrWhiteSpace(dto.Password))
                existing.PasswordHash = HashPassword(dto.Password);

            return existing;
        }

        private static string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
