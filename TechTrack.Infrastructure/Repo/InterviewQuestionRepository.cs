using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Models;
using TechTrack.Infrastructure.Data;

namespace TechTrack.Infrastructure.Repo
{
    public class InterviewQuestionRepository : GenericRepository<InterviewQuestion>, IInterviewQuestionRepository
    {
        public InterviewQuestionRepository(AppDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<InterviewQuestion>> GetAllAsync()
        {
            return await _dbSet.Include(q => q.Technology).ToListAsync();
        }

        public override async Task<InterviewQuestion?> GetByIdAsync(int id)
        {
            return await _dbSet.Include(q => q.Technology)
                               .FirstOrDefaultAsync(q => q.QuestionId == id);
        }
    }
}