namespace TechTrack.DTOs.SubCategory
{
    public class SubCategoryCreateDto
    {
        public int CategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string Description { get; set; }
        public int? DifficultyLevel { get; set; }
        public int EstimatedDuration { get; set; }
        public string? ImageUrl { get; set; }
    }
}
