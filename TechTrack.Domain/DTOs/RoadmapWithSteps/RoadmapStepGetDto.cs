using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTrack.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechTrack.Domain.DTOs.RoadmapWithSteps
{
    public class RoadmapStepGetDto
    {
        public int RoadmapId { get; set; }
     //   public IEnumerable<RoadmapStepGetDto> Steps { get; set; }

        public int TechnologyId { get; set; }
        public Technology? Technology { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }

        // Removed duplicate 'Steps' property of type List<string> to fix CS0102.
    }
}
