using System;
using System.Collections.Generic;
using System.Text;

namespace TechTrack.Domain.Models
{
    public class Roadmap
    {
        public int RoadmapId { get; set; }

        public int TechnologyId { get; set; }
        public Technology? Technology { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }

        public ICollection<RoadmapStep>? RoadmapSteps { get; set; }
    }
}
