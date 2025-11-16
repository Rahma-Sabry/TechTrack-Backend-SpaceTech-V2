// using Microsoft.Extensions.DependencyInjection;

// namespace TechPathNavigator.Data
// {
//     public static class SeedData
//     {
//         public static void Initialize(IServiceProvider serviceProvider)
//         {
//             using var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
//             DbSeeder.SeedCategories(context);
//             DbSeeder.SeedCompanies(context);
//             DbSeeder.SeedCompanyTechnologies(context);
//             DbSeeder.SeedInterviewQuestions(context);
//             DbSeeder.SeedRoadmaps(context);
//             DbSeeder.SeedRoadmapSteps(context); 
//             DbSeeder.SeedSubCategories(context);
//             DbSeeder.SeedTechnology(context);
//             DbSeeder.SeedTracks(context);
//             DbSeeder.SeedUsers(context);
//             DbSeeder.SeedReviews(context);
//         }
//     }
// }
