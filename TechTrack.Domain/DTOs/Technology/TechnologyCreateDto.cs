namespace TechTrack.DTOs.Technology
{
    public class TechnologyCreateDto
    {
        public int TrackId { get; set; }
        public string TechnologyName { get; set; }
        public string Description { get; set; }
        public string? VideoUrl { get; set; }
    }
}
