using System;
using System.Collections.Generic;
using System.Text;

namespace TechTrack.Domain.DTOs.Company
{
    public class CompanyCreateDto
    {
        public string? CompanyName { get; set; }
        public string? Industry { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? Description { get; set; }
    }
}
