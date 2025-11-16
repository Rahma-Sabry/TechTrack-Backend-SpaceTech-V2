using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TechTrack.Domain.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        public string? CompanyName { get; set; }
        public string? Industry { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? Description { get; set; }
        public ICollection<CompanyTechnology>? CompanyTechnology { get; set; }
    }
}
