using TechTrack.Domain.Models;
using TechTrack.Domain.Interfaces.IRepo;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechTrack.Infrastructure.Repository
{
    public class InterviewQuestionRepository : IInterviewQuestionRepository
    {
        private readonly List<InterviewQuestion> _questions = new();

        public async Task AddAsync(InterviewQuestion question)
        {
            question.QuestionId = _questions.Count + 1;
            _questions.Add(question);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(InterviewQuestion question)
        {
            _questions.Remove(question);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<InterviewQuestion>> GetAllAsync()
        {
            return await Task.FromResult(_questions);
        }

        public async Task<InterviewQuestion?> GetByIdAsync(int id)
        {
            return await Task.FromResult(_questions.FirstOrDefault(q => q.QuestionId == id));
        }

        public async Task UpdateAsync(InterviewQuestion question)
        {
            var existing = _questions.FirstOrDefault(q => q.QuestionId == question.QuestionId);
            if (existing != null)
            {
                existing.TechnologyId = question.TechnologyId;
                existing.QuestionText = question.QuestionText;
                existing.DifficultyLevel = question.DifficultyLevel;
                existing.QuestionType = question.QuestionType;
                existing.SampleAnswer = question.SampleAnswer;
            }
            await Task.CompletedTask;
        }
    }
}
