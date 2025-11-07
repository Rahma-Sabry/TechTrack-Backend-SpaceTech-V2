using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace TechTrack.DTOs.Category
{
    public class CategoryCreateDto
    {
        [Required, MaxLength(200)]
        public string CategoryName { get; set; } = string.Empty;

        public string? Description { get; set; }

        // This will be the uploaded file
        public IFormFile? Image { get; set; }
    }
}
