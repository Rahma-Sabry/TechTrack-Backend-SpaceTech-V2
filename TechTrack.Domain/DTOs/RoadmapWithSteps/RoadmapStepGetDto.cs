using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTrack.Domain.DTOs.RoadmapWithSteps
{
    internal class RoadmapStepGetDto
    {
        public int RoadmapId { get; set; }
        public IEnumerable<RoadmapStepGetDto> Steps { get; set; }
    }
}
