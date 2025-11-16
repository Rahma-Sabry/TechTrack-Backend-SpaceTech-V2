using System;
using System.Collections.Generic;
using System.Text;

namespace TechTrack.Domain.DTOs.InterviewQuestion
{
    public class InterviewQuestionGetDto
    {
        public int QuestionId { get; set; }
        public int TechnologyId { get; set; }
        public string? QuestionText { get; set; }
        public string? DifficultyLevel { get; set; }
        public string? QuestionType { get; set; }
        public string? SampleAnswer { get; set; }
    }
}
