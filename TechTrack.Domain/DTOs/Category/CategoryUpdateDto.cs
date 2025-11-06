using System.ComponentModel.DataAnnotations;

namespace TechTrack.DTOs.Category
{
    public class CategoryUpdateDto
    {
        [Required, MaxLength(200)]
        public string CategoryName { get; set; }

        public string? Description { get; set; }

        [MaxLength(500)]
        public string? ImageUrl { get; set; }
    }
}
