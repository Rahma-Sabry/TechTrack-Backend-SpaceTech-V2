// ============================================
// CompanyRepository.cs - REPLACE THE EXISTING ONE
// Location: TechTrack.Infrastructure/Repo/CompanyRepository.cs
// ============================================

using Microsoft.EntityFrameworkCore;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Models;
using TechTrack.Infrastructure.Data;

namespace TechTrack.Infrastructure.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;

        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Company?> GetByIdAsync(int id)
        {
            return await _context.Companies
                .Include(c => c.CompanyTechnology)
                .FirstOrDefaultAsync(c => c.CompanyId == id);
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _context.Companies
                .Include(c => c.CompanyTechnology)
                .ToListAsync();
        }

        public async Task AddAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Company company)
        {
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Companies
                .AnyAsync(c => c.CompanyName.ToLower() == name.ToLower());
        }
    }
}

// ============================================
// CompanyTechnologyRepository.cs - REPLACE THE EXISTING ONE
// Location: TechTrack.Infrastructure/Repo/CompanyTechnologyRepository.cs
// ============================================

using Microsoft.EntityFrameworkCore;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Models;
using TechTrack.Infrastructure.Data;

namespace TechTrack.Infrastructure.Repository
{
    public class CompanyTechnologyRepository : ICompanyTechnologyRepository
    {
        private readonly AppDbContext _context;

        public CompanyTechnologyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CompanyTechnology?> GetByIdAsync(int id)
        {
            return await _context.CompanyTechnologies
                .Include(ct => ct.Company)
                .Include(ct => ct.Technology)
                .FirstOrDefaultAsync(ct => ct.CompanyTechnologyId == id);
        }

        public async Task<IEnumerable<CompanyTechnology>> GetAllAsync()
        {
            return await _context.CompanyTechnologies
                .Include(ct => ct.Company)
                .Include(ct => ct.Technology)
                .ToListAsync();
        }

        public async Task AddAsync(CompanyTechnology companyTech)
        {
            await _context.CompanyTechnologies.AddAsync(companyTech);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CompanyTechnology companyTech)
        {
            _context.CompanyTechnologies.Update(companyTech);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(CompanyTechnology companyTech)
        {
            _context.CompanyTechnologies.Remove(companyTech);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsPairAsync(int companyId, int technologyId)
        {
            return await _context.CompanyTechnologies
                .AnyAsync(ct => ct.CompanyId == companyId && ct.TechnologyId == technologyId);
        }
    }
}

// ============================================
// InterviewQuestionRepository.cs - REPLACE THE EXISTING ONE
// Location: TechTrack.Infrastructure/Repo/InterviewQuestionRepository.cs
// ============================================

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

// ============================================
// UserRepository.cs - REPLACE THE EXISTING ONE
// Location: TechTrack.Infrastructure/Repo/UserRepository.cs
// ============================================

using Microsoft.EntityFrameworkCore;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Models;
using TechTrack.Infrastructure.Data;

namespace TechTrack.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Reviews)
                .FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users
                .Include(u => u.Reviews)
                .ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Users
                .AnyAsync(u => u.Email.ToLower() == email.ToLower());
        }
    }
}

// ============================================
// UserTechnologyReviewRepository.cs - REPLACE THE EXISTING ONE
// Location: TechTrack.Infrastructure/Repo/UserTechnologyReviewRepository.cs
// ============================================

using Microsoft.EntityFrameworkCore;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Models;
using TechTrack.Infrastructure.Data;

namespace TechTrack.Infrastructure.Repository
{
    public class UserTechnologyReviewRepository : IUserTechnologyReviewRepository
    {
        private readonly AppDbContext _context;

        public UserTechnologyReviewRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserTechnologyReview?> GetByIdAsync(int id)
        {
            return await _context.UserTechnologyReviews
                .Include(r => r.User)
                .Include(r => r.Technology)
                .FirstOrDefaultAsync(r => r.ReviewId == id);
        }

        public async Task<IEnumerable<UserTechnologyReview>> GetAllAsync()
        {
            return await _context.UserTechnologyReviews
                .Include(r => r.User)
                .Include(r => r.Technology)
                .ToListAsync();
        }

        public async Task AddAsync(UserTechnologyReview review)
        {
            await _context.UserTechnologyReviews.AddAsync(review);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserTechnologyReview review)
        {
            _context.UserTechnologyReviews.Update(review);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserTechnologyReview review)
        {
            _context.UserTechnologyReviews.Remove(review);
            await _context.SaveChangesAsync();
        }
    }
}