namespace TechTrack.DTOs.Roadmap
{
    public class RoadmapCreateDto
    {
        public int TechnologyId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<string> Steps { get; set; } = new List<string>();

    }
}
