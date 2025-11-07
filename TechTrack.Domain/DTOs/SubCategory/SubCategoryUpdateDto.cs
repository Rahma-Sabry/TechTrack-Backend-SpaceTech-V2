using Microsoft.AspNetCore.Http;

namespace TechTrack.Domain.DTOs.SubCategory
{
    public class SubCategoryUpdateDto
    {
        public int CategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string Description { get; set; }
        public int? DifficultyLevel { get; set; }
        public int EstimatedDuration { get; set; }
        public IFormFile? Image { get; set; }
        public bool DeleteImage { get; set; }
    }
}
