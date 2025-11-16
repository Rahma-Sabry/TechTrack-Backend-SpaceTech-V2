using System;
using System.Collections.Generic;
using System.Text;

namespace TechTrack.Domain.DTOs.UserTechnologyReview
{
    public class UserTechnologyReviewCreateDto
    {
        public int UserId { get; set; }
        public int TechnologyId { get; set; }
        public int Rating { get; set; }
        public string? ReviewText { get; set; }
    }
}
