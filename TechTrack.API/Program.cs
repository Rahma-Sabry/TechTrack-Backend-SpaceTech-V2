using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TechTrack.API.Middleware;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Interfaces.IService;
using TechTrack.Infrastructure.Data;
using TechTrack.Infrastructure.Repo;
using TechTrack.Infrastructure.Repository;
using TechTrack.Infrastructure.Service;
using TechTrack.Infrastructure.Service.Category;
using TechTrack.Infrastructure.Service.SubCategory;
using TechTrack.Infrastructure.Service.Technology;
using TechTrack.Infrastructure.Service.Track;

var builder = WebApplication.CreateBuilder(args);

// 💾 Database Connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ------------------- Repositories -------------------

// User & Reviews
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserTechnologyReviewRepository, UserTechnologyReviewRepository>();

// Company & CompanyTechnology
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyTechnologyRepository, CompanyTechnologyRepository>();

// Interview Questions
builder.Services.AddScoped<IInterviewQuestionRepository, InterviewQuestionRepository>();

// Tracks & Technologies
builder.Services.AddScoped<ITrackRepository, TrackRepository>();
builder.Services.AddScoped<ITechnologyRepository, TechnologyRepository>();

// Category & SubCategory
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();

// Roadmap & RoadmapStep
builder.Services.AddScoped<IRoadmapRepository, RoadmapRepository>();
builder.Services.AddScoped<IRoadmapStepRepository, RoadmapStepRepository>();

// ------------------- Services -------------------

// User & Reviews
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserTechnologyReviewService, UserTechnologyReviewService>();

// Company & CompanyTechnology
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ICompanyTechnologyService, CompanyTechnologyService>();

// Interview Questions
builder.Services.AddScoped<IInterviewQuestionService, InterviewQuestionService>();

// Tracks & Technologies
builder.Services.AddScoped<ITrackService, TrackService>();
builder.Services.AddScoped<ITechnologyService, TechnologyService>();

// Category & SubCategory
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();

// Roadmap & RoadmapStep
builder.Services.AddScoped<IRoadmapService, RoadmapService>();
builder.Services.AddScoped<IRoadmapStepService, RoadmapStepService>();

// ------------------- Controllers -------------------
builder.Services.AddControllers();

// ------------------- Swagger -------------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TechTrack API",
        Version = "v1",
        Description = "API for managing technologies, tracks, users, companies, and roadmaps"
    });
});


// ------------------- CORS -------------------
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// ------------------- Middleware -------------------
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TechTrack API V2");
    c.RoutePrefix = string.Empty;
});

// Custom Middleware (optional, implement if you have them)
app.UseGlobalExceptionHandler(); // implement this extension or remove
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors();

// ------------------- Map Controllers -------------------
app.MapControllers();


app.Run();
