using System.Collections.Generic;
using System.Threading.Tasks;
using TechTrack.Domain.DTOs.InterviewQuestion;

namespace TechTrack.Domain.Interfaces.IService
{
    public interface IInterviewQuestionService
    {
        Task<IEnumerable<InterviewQuestionGetDto>> GetAllAsync();
        Task<InterviewQuestionGetDto?> GetByIdAsync(int id);
        Task<string> CreateAsync(InterviewQuestionCreateDto dto);
        Task<string> UpdateAsync(int id, InterviewQuestionUpdateDto dto);
        Task<string> DeleteAsync(int id);
    }
}