namespace TechTrack.DTOs.Technology
{
    public class TechnologyGetDto
    {
        public int TechnologyId { get; set; }
        public string TechnologyName { get; set; }
        public string Description { get; set; }
        public string? VideoUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TrackId { get; set; }
    }
}
