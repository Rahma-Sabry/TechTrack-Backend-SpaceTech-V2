using System;
using System.Collections.Generic;
using System.Text;

namespace TechTrack.Domain.DTOs.CompanyTechnology
{
    public class CompanyTechnologyCreateDto
    {
        public int CompanyId { get; set; }
        public int TechnologyId { get; set; }
        public string? UsageLevel { get; set; }
        public string? Notes { get; set; }
    }
}
