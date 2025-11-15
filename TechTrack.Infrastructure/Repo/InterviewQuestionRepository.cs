using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Models;

namespace TechTrack.Infrastructure.Repository
{
    public class InterviewQuestionRepository : IInterviewQuestionRepository
    {
        private readonly List<InterviewQuestion> _questions = new();
        private int _nextId = 1;

        public async Task<IEnumerable<InterviewQuestion>> GetAllAsync()
        {
            return await Task.FromResult(_questions.AsEnumerable());
        }

        public async Task<InterviewQuestion?> GetByIdAsync(int id)
        {
            return await Task.FromResult(_questions.FirstOrDefault(q => q.QuestionId == id));
        }

        public async Task<InterviewQuestion> AddAsync(InterviewQuestion question)
        {
            question.QuestionId = _nextId++;
            _questions.Add(question);
            return await Task.FromResult(question);
        }

        public async Task<InterviewQuestion?> UpdateAsync(InterviewQuestion question)
        {
            var existing = _questions.FirstOrDefault(q => q.QuestionId == question.QuestionId);
            if (existing == null)
                return null;

            existing.TechnologyId = question.TechnologyId;
            existing.QuestionText = question.QuestionText;
            existing.DifficultyLevel = question.DifficultyLevel;
            existing.QuestionType = question.QuestionType;
            existing.SampleAnswer = question.SampleAnswer;

            return await Task.FromResult(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var question = _questions.FirstOrDefault(q => q.QuestionId == id);
            if (question == null)
                return false;

            _questions.Remove(question);
            return await Task.FromResult(true);
        }
    }
}