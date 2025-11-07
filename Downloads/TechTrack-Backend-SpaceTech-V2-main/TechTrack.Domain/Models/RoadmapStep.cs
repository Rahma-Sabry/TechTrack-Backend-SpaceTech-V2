using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechTrack.Domain.Models
{
    public class RoadmapStep
    {
        [Key]
        public int RoadmapStepId { get; set; }

        [Required]
        public int RoadmapId { get; set; }   // Foreign Key

        [Required, MaxLength(200)]
        public string StepTitle { get; set; }

        [MaxLength(1000)]
        public string? StepDescription { get; set; }

        [Required]
        public int StepOrder { get; set; }

        // Navigation Property
        public Roadmap Roadmap { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
