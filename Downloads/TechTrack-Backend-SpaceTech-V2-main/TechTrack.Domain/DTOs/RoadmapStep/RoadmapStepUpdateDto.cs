using System.ComponentModel.DataAnnotations;

namespace TechTrack.Domain.DTOs.RoadmapStep
{
    public class RoadmapStepUpdateDto
    {
        [Required, MaxLength(200)]
        public string StepTitle { get; set; }

        [MaxLength(1000)]
        public string? StepDescription { get; set; }

        [Required]
        public int StepOrder { get; set; }
    }
}
