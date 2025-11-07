namespace TechTrack.DTOs.Roadmap
{
    public class RoadmapGetDto
    {
        public int RoadmapId { get; set; }
        public int TechnologyId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
