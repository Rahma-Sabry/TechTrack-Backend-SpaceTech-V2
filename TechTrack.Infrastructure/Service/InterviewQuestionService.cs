using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechPathNavigator.Domain.Common.Errors;
using TechPathNavigator.Domain.Common.Messages;
using TechTrack.Domain.DTOs.InterviewQuestion;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Interfaces.IService;
using TechTrack.Domain.Models;
using TechTrack.DTOs;
using TechTrack.Infrastructure.Extensions;

namespace TechTrack.Infrastructure.Service
{
    public class InterviewQuestionService : IInterviewQuestionService
    {
        private readonly IInterviewQuestionRepository _repo;

        public InterviewQuestionService(IInterviewQuestionRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> CreateAsync(InterviewQuestionCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.QuestionText))
                return ErrorMessages.InterviewQuestion_TextRequired;

            var question = dto.ToModel();
            await _repo.AddAsync(question);
            return ApiMessages.InterviewQuestionCreated;
        }

        public async Task<string> DeleteAsync(int id)
        {
            var question = await _repo.GetByIdAsync(id);
            if (question == null) return ErrorMessages.InterviewQuestion_TextRequired;

            await _repo.DeleteAsync(question);
            return ApiMessages.InterviewQuestionDeleted;
        }

        public async Task<IEnumerable<InterviewQuestionGetDto>> GetAllAsync()
        {
            var questions = await _repo.GetAllAsync();
            return questions.Select(q => q.ToGetDto());
        }

        public async Task<InterviewQuestionGetDto?> GetByIdAsync(int id)
        {
            var question = await _repo.GetByIdAsync(id);
            if (question == null) return null;
            return question.ToGetDto();
        }

        public async Task<string> UpdateAsync(int id, InterviewQuestionUpdateDto dto)
        {
            var question = await _repo.GetByIdAsync(id);
            if (question == null) return ErrorMessages.InterviewQuestion_TextRequired;

            question = dto.ToModel(question);
            await _repo.UpdateAsync(question);
            return ApiMessages.InterviewQuestionUpdated;
        }
    }
}
