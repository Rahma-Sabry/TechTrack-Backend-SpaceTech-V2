using TechTrack.Domain.DTOs.InterviewQuestion;
using TechTrack.Domain.Models;
using TechTrack.DTOs;

namespace TechTrack.Infrastructure.Extensions
{
    public static class InterviewQuestionMappingExtensions
    {
        public static InterviewQuestionGetDto ToGetDto(this InterviewQuestion q)
        {
            if (q == null) return null!;
            return new InterviewQuestionGetDto
            {
                QuestionId = q.QuestionId,
                TechnologyId = q.TechnologyId,
                QuestionText = q.QuestionText,
                DifficultyLevel = q.DifficultyLevel,
                QuestionType = q.QuestionType,
                SampleAnswer = q.SampleAnswer
            };
        }

        public static InterviewQuestion ToModel(this InterviewQuestionCreateDto dto)
        {
            if (dto == null) return null!;
            return new InterviewQuestion
            {
                TechnologyId = dto.TechnologyId,
                QuestionText = dto.QuestionText,
                DifficultyLevel = dto.DifficultyLevel,
                QuestionType = dto.QuestionType,
                SampleAnswer = dto.SampleAnswer
            };
        }

        public static InterviewQuestion ToModel(this InterviewQuestionUpdateDto dto, InterviewQuestion existing)
        {
            if (dto == null || existing == null) return existing;

            existing.TechnologyId = dto.TechnologyId;
            existing.QuestionText = dto.QuestionText;
            existing.DifficultyLevel = dto.DifficultyLevel;
            existing.QuestionType = dto.QuestionType;
            existing.SampleAnswer = dto.SampleAnswer;

            return existing;
        }
    }
}
