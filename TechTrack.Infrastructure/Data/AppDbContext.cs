using Microsoft.EntityFrameworkCore;
using TechTrack.Domain.Models;

namespace TechTrack.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Roadmap> Roadmaps { get; set; } 
        public DbSet<RoadmapStep> RoadmapSteps { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserTechnologyReview> UserTechnologyReviews { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyTechnology> CompanyTechnologies { get; set; }
        public DbSet<InterviewQuestion> InterviewQuestions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
