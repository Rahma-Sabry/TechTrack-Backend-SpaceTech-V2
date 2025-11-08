using Microsoft.EntityFrameworkCore;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Models;
using TechTrack.Infrastructure.Data;

namespace TechTrack.Infrastructure.Repository
{
    public class InterviewQuestionRepository : IInterviewQuestionRepository
    {
        private readonly AppDbContext _context;

        public InterviewQuestionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<InterviewQuestion?> GetByIdAsync(int id)
        {
            return await _context.InterviewQuestions
                .Include(q => q.Technology)
                .FirstOrDefaultAsync(q => q.QuestionId == id);
        }

        public async Task<IEnumerable<InterviewQuestion>> GetAllAsync()
        {
            return await _context.InterviewQuestions
                .Include(q => q.Technology)
                .ToListAsync();
        }

        public async Task AddAsync(InterviewQuestion question)
        {
            await _context.InterviewQuestions.AddAsync(question);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(InterviewQuestion question)
        {
            _context.InterviewQuestions.Update(question);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(InterviewQuestion question)
        {
            _context.InterviewQuestions.Remove(question);
            await _context.SaveChangesAsync();
        }
    }
}
