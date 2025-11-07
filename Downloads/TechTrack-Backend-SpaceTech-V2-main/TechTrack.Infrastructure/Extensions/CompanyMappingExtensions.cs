using TechTrack.Domain.DTOs.Company;
using TechTrack.Domain.Models;
using TechTrack.DTOs;

namespace TechTrack.Infrastructure.Extensions
{
    public static class CompanyMappingExtensions
    {
        public static CompanyGetDto ToGetDto(this Company company)
        {
            if (company == null) return null!;

            return new CompanyGetDto
            {
                CompanyId = company.CompanyId,
                CompanyName = company.CompanyName,
                Industry = company.Industry,
                WebsiteUrl = company.WebsiteUrl,
                Description = company.Description
            };
        }

        public static Company ToModel(this CompanyCreateDto dto)
        {
            if (dto == null) return null!;

            return new Company
            {
                CompanyName = dto.CompanyName,
                Industry = dto.Industry,
                WebsiteUrl = dto.WebsiteUrl,
                Description = dto.Description
            };
        }

        public static Company ToModel(this CompanyUpdateDto dto, Company existing)
        {
            if (dto == null || existing == null) return existing;

            existing.CompanyName = dto.CompanyName;
            existing.Industry = dto.Industry;
            existing.WebsiteUrl = dto.WebsiteUrl;
            existing.Description = dto.Description;

            return existing;
        }
    }
}
