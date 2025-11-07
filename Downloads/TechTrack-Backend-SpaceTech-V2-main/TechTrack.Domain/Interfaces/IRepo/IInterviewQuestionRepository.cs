using TechTrack.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechTrack.Domain.Interfaces.IRepo
{
    public interface IInterviewQuestionRepository
    {
        Task<InterviewQuestion?> GetByIdAsync(int id);
        Task<IEnumerable<InterviewQuestion>> GetAllAsync();
        Task AddAsync(InterviewQuestion question);
        Task UpdateAsync(InterviewQuestion question);
        Task DeleteAsync(InterviewQuestion question);
    }
}
