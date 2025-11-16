using TechTrack.Domain.DTOs.CompanyTechnology;
using TechTrack.Domain.Models;
using TechTrack.DTOs;

namespace TechTrack.Infrastructure.Extensions
{
    public static class CompanyTechnologyMappingExtensions
    {
        public static CompanyTechnologyGetDto ToGetDto(this CompanyTechnology ct)
        {
            if (ct == null) return null!;

            return new CompanyTechnologyGetDto
            {
                CompanyTechnologyId = ct.CompanyTechnologyId,
                CompanyId = ct.CompanyId,
                TechnologyId = ct.TechnologyId,
                UsageLevel = ct.UsageLevel,
                Notes = ct.Notes
            };
        }

        public static CompanyTechnology ToModel(this CompanyTechnologyCreateDto dto)
        {
            if (dto == null) return null!;

            return new CompanyTechnology
            {
                CompanyId = dto.CompanyId,
                TechnologyId = dto.TechnologyId,
                UsageLevel = dto.UsageLevel,
                Notes = dto.Notes
            };
        }

        public static CompanyTechnology ToModel(this CompanyTechnologyUpdateDto dto, CompanyTechnology existing)
        {
            if (dto == null || existing == null) return existing;

            existing.CompanyId = dto.CompanyId;
            existing.TechnologyId = dto.TechnologyId;
            existing.UsageLevel = dto.UsageLevel;
            existing.Notes = dto.Notes;

            return existing;
        }
    }
}
