
namespace TechTrack.Domain.DTOs.RoadmapStep
{
    public class RoadmapStepGetDto
    {
        public int RoadmapStepId { get; set; }
        public int RoadmapId { get; set; }
        public string StepTitle { get; set; }
        public string? StepDescription { get; set; }
        public int StepOrder { get; set; }
        public List<RoadmapStepGetDto> Steps { get; set; }
        //  public IEnumerable<RoadmapStepGetDto> Steps { get; set; }
    }
}
