using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace TechTrack.DTOs.Category
{
    public class CategoryUpdateDto
    {
        [Required, MaxLength(200)]
        public string CategoryName { get; set; } = string.Empty;

        public string? Description { get; set; }

        // Optional new image
        public IFormFile? Image { get; set; }
        
        // If true, delete existing image without uploading new one
        public bool DeleteImage { get; set; } = false;
    }
}
