using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechPathNavigator.Domain.Common.Errors;
using TechPathNavigator.Domain.Common.Messages;
using TechTrack.Domain.DTOs.InterviewQuestion;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Interfaces.IService;
using TechTrack.Infrastructure.Extensions;

namespace TechTrack.Infrastructure.Service
{
    public class InterviewQuestionService : IInterviewQuestionService
    {
        private readonly IInterviewQuestionRepository _questionRepo;

        public InterviewQuestionService(IInterviewQuestionRepository questionRepo)
        {
            _questionRepo = questionRepo;
        }

        public async Task<string> CreateAsync(InterviewQuestionCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.QuestionText))
                return ErrorMessages.InterviewQuestion_TextRequired;

            var question = dto.ToModel();
            await _questionRepo.AddAsync(question);
            return ApiMessages.InterviewQuestionCreated;
        }

        public async Task<string> DeleteAsync(int id)
        {
            var deleted = await _questionRepo.DeleteAsync(id);
            if (!deleted)
                return ErrorMessages.InterviewQuestion_TextRequired;

            return ApiMessages.InterviewQuestionDeleted;
        }

        public async Task<IEnumerable<InterviewQuestionGetDto>> GetAllAsync()
        {
            var questions = await _questionRepo.GetAllAsync();
            return questions.Select(q => q.ToGetDto());
        }

        public async Task<InterviewQuestionGetDto?> GetByIdAsync(int id)
        {
            var question = await _questionRepo.GetByIdAsync(id);
            return question?.ToGetDto();
        }

        public async Task<string> UpdateAsync(int id, InterviewQuestionUpdateDto dto)
        {
            var question = await _questionRepo.GetByIdAsync(id);
            if (question == null)
                return ErrorMessages.InterviewQuestion_TextRequired;

            question = dto.ToModel(question);
            await _questionRepo.UpdateAsync(question);
            return ApiMessages.InterviewQuestionUpdated;
        }
    }
}