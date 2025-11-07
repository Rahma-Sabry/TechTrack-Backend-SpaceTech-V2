using System;
using System.Collections.Generic;
using System.Text;

namespace TechTrack.Domain.DTOs.UserTechnologyReview
{
    public class UserTechnologyReviewGetDto
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public int TechnologyId { get; set; }
        public int Rating { get; set; }
        public string? ReviewText { get; set; }
    }
}
