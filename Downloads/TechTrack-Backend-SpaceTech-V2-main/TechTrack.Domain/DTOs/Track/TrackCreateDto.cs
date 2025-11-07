using System;
using System.Collections.Generic;
using System.Text;

namespace TechTrack.Domain.DTOs.Track
{
    public class TrackCreateDto
    {
        public string? TrackName { get; set; }
        public string? Description { get; set; }
        public string? DifficultyLevel { get; set; }
        public int EstimatedDuration { get; set; }
        public int SubCategoryId { get; set; }
    }
}
