namespace TechTrack.Domain.DTOs.RoadmapStep
{
    public class RoadmapStepGetDto
    {
        public int RoadmapStepId { get; set; }
        public int RoadmapId { get; set; }
        public string StepTitle { get; set; }
        public string? StepDescription { get; set; }
        public int StepOrder { get; set; }
    }
}
