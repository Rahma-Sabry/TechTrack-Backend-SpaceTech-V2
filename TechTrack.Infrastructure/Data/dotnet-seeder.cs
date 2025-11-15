using Microsoft.EntityFrameworkCore;
using TechTrack.Domain.Models;
using TechTrack.Infrastructure.Data;

namespace TechTrack.Infrastructure.Data
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            // Check if data already exists
            if (await context.Categories.AnyAsync())
            {
                Console.WriteLine("Database already seeded. Skipping...");
                return;
            }

            Console.WriteLine("🌱 Starting database seeding...");

            try
            {
                // 1. Seed Categories
                var categories = await SeedCategories(context);
                Console.WriteLine($"✅ Created {categories.Count} categories");

                // 2. Seed SubCategories
                var subCategories = await SeedSubCategories(context, categories);
                Console.WriteLine($"✅ Created {subCategories.Count} subcategories");

                // 3. Seed Tracks
                var tracks = await SeedTracks(context, subCategories);
                Console.WriteLine($"✅ Created {tracks.Count} tracks");

                // 4. Seed Technologies
                var technologies = await SeedTechnologies(context, tracks);
                Console.WriteLine($"✅ Created {technologies.Count} technologies");

                // 5. Seed Users
                var users = await SeedUsers(context);
                Console.WriteLine($"✅ Created {users.Count} users");

                // 6. Seed Companies
                var companies = await SeedCompanies(context);
                Console.WriteLine($"✅ Created {companies.Count} companies");

                // 7. Seed CompanyTechnologies
                var companyTechs = await SeedCompanyTechnologies(context, companies, technologies);
                Console.WriteLine($"✅ Created {companyTechs.Count} company-technology relationships");

                // 8. Seed Roadmaps
                var roadmaps = await SeedRoadmaps(context, technologies);
                Console.WriteLine($"✅ Created {roadmaps.Count} roadmaps");

                // 9. Seed RoadmapSteps
                //var roadmapSteps = await SeedRoadmapSteps(context, roadmaps);
                //Console.WriteLine($"✅ Created {roadmapSteps.Count} roadmap steps");

                // 10. Seed Interview Questions
                var questions = await SeedInterviewQuestions(context, technologies);
                Console.WriteLine($"✅ Created {questions.Count} interview questions");

                // 11. Seed Reviews
                var reviews = await SeedReviews(context, users, technologies);
                Console.WriteLine($"✅ Created {reviews.Count} user reviews");

                Console.WriteLine("🎉 Database seeding completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error during seeding: {ex.Message}");
                throw;
            }
        }

        private static async Task<List<Category>> SeedCategories(AppDbContext context)
        {
            var categories = new List<Category>
            {
                new Category
                {
                    CategoryName = "Software Development",
                    Description = "Learn software engineering, version control, architecture, and testing.",
                    ImageUrl = "https://res.cloudinary.com/djhifbjsx/image/upload/v1762618536/IMG-20251107-WA0067_xgjtdy.jpg",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Category
                {
                    CategoryName = "Data & AI",
                    Description = "Learn data analysis, pipelines, ML, and AI ethics.",
                    ImageUrl = "https://res.cloudinary.com/djhifbjsx/image/upload/v1762618536/IMG-20251107-WA0064_uoxo39.jpg",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Category
                {
                    CategoryName = "Design & UX",
                    Description = "Focus on design principles, prototyping, accessibility, and usability.",
                    ImageUrl = "https://res.cloudinary.com/djhifbjsx/image/upload/v1762618536/IMG-20251107-WA0065_ro1o0f.jpg",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Category
                {
                    CategoryName = "DevOps & Cloud",
                    Description = "Learn CI/CD, containers, automation, cloud deployments, and monitoring.",
                    ImageUrl = "https://res.cloudinary.com/djhifbjsx/image/upload/v1762618536/IMG-20251107-WA0066_vmayhr.jpg",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            context.Categories.AddRange(categories);
            await context.SaveChangesAsync();
            return categories;
        }

        private static async Task<List<SubCategory>> SeedSubCategories(AppDbContext context, List<Category> categories)
        {
            var subCategories = new List<SubCategory>
            {
                // Software Development SubCategories
                new SubCategory { CategoryId = categories[0].CategoryId, SubCategoryName = "Frontend Development", Description = "Build modern user interfaces with HTML, CSS, and JavaScript frameworks", DifficultyLevel = 2, EstimatedDuration = 120, ImageUrl = "https://res.cloudinary.com/djhifbjsx/image/upload/v1762618536/frontend_sample.jpg" },
                new SubCategory { CategoryId = categories[0].CategoryId, SubCategoryName = "Backend Development", Description = "Server-side programming, APIs, and database management", DifficultyLevel = 3, EstimatedDuration = 150, ImageUrl = "https://res.cloudinary.com/djhifbjsx/image/upload/v1762618536/backend_sample.jpg" },
                new SubCategory { CategoryId = categories[0].CategoryId, SubCategoryName = "Testing & QA", Description = "Automated testing, unit tests, integration testing", DifficultyLevel = 2, EstimatedDuration = 80, ImageUrl = "https://res.cloudinary.com/djhifbjsx/image/upload/v1762618536/testing_sample.jpg" },
                new SubCategory { CategoryId = categories[0].CategoryId, SubCategoryName = "Software Architecture", Description = "Design patterns, microservices, system design", DifficultyLevel = 4, EstimatedDuration = 100, ImageUrl = "https://res.cloudinary.com/djhifbjsx/image/upload/v1762618536/architecture_sample.jpg" },

                // Data & AI SubCategories
                new SubCategory { CategoryId = categories[1].CategoryId, SubCategoryName = "Data Analysis", Description = "Statistical analysis, data visualization, and insights", DifficultyLevel = 2, EstimatedDuration = 100, ImageUrl = "https://res.cloudinary.com/djhifbjsx/image/upload/v1762618536/data_analysis_sample.jpg" },
                new SubCategory { CategoryId = categories[1].CategoryId, SubCategoryName = "Machine Learning", Description = "Supervised and unsupervised learning algorithms", DifficultyLevel = 4, EstimatedDuration = 180, ImageUrl = "https://res.cloudinary.com/djhifbjsx/image/upload/v1762618536/ml_sample.jpg" },
                new SubCategory { CategoryId = categories[1].CategoryId, SubCategoryName = "Deep Learning", Description = "Neural networks, CNNs, RNNs, transformers", DifficultyLevel = 5, EstimatedDuration = 200, ImageUrl = "https://res.cloudinary.com/djhifbjsx/image/upload/v1762618536/dl_sample.jpg" },
                new SubCategory { CategoryId = categories[1].CategoryId, SubCategoryName = "AI Ethics", Description = "Responsible AI, bias detection, and fairness", DifficultyLevel = 2, EstimatedDuration = 60, ImageUrl = "https://res.cloudinary.com/djhifbjsx/image/upload/v1762618536/ethics_sample.jpg" },

                // Design & UX SubCategories
                new SubCategory { CategoryId = categories[2].CategoryId, SubCategoryName = "UI Design", Description = "Visual design, typography, color theory", DifficultyLevel = 2, EstimatedDuration = 90, ImageUrl = "https://res.cloudinary.com/djhifbjsx/image/upload/v1762618536/ui_design_sample.jpg" },
                new SubCategory { CategoryId = categories[2].CategoryId, SubCategoryName = "User Research", Description = "User interviews, personas, journey mapping", DifficultyLevel = 2, EstimatedDuration = 70, ImageUrl = "https://res.cloudinary.com/djhifbjsx/image/upload/v1762618536/research_sample.jpg" },
                new SubCategory { CategoryId = categories[2].CategoryId, SubCategoryName = "Accessibility", Description = "WCAG standards, inclusive design practices", DifficultyLevel = 3, EstimatedDuration = 50, ImageUrl = "https://res.cloudinary.com/djhifbjsx/image/upload/v1762618536/accessibility_sample.jpg" },
                new SubCategory { CategoryId = categories[2].CategoryId, SubCategoryName = "Prototyping", Description = "Wireframing, interactive prototypes, usability testing", DifficultyLevel = 2, EstimatedDuration = 60, ImageUrl = "https://res.cloudinary.com/djhifbjsx/image/upload/v1762618536/prototype_sample.jpg" },

                // DevOps & Cloud SubCategories
                new SubCategory { CategoryId = categories[3].CategoryId, SubCategoryName = "CI/CD Pipelines", Description = "Continuous integration and deployment automation", DifficultyLevel = 3, EstimatedDuration = 80, ImageUrl = "https://res.cloudinary.com/djhifbjsx/image/upload/v1762618536/cicd_sample.jpg" },
                new SubCategory { CategoryId = categories[3].CategoryId, SubCategoryName = "Containerization", Description = "Docker, Kubernetes, container orchestration", DifficultyLevel = 4, EstimatedDuration = 120, ImageUrl = "https://res.cloudinary.com/djhifbjsx/image/upload/v1762618536/container_sample.jpg" },
                new SubCategory { CategoryId = categories[3].CategoryId, SubCategoryName = "Cloud Platforms", Description = "AWS, Azure, GCP infrastructure and services", DifficultyLevel = 4, EstimatedDuration = 150, ImageUrl = "https://res.cloudinary.com/djhifbjsx/image/upload/v1762618536/cloud_sample.jpg" },
                new SubCategory { CategoryId = categories[3].CategoryId, SubCategoryName = "Monitoring & Logging", Description = "System observability, metrics, and alerting", DifficultyLevel = 3, EstimatedDuration = 70, ImageUrl = "https://res.cloudinary.com/djhifbjsx/image/upload/v1762618536/monitoring_sample.jpg" }
            };

            context.SubCategories.AddRange(subCategories);
            await context.SaveChangesAsync();
            return subCategories;
        }

        private static async Task<List<Track>> SeedTracks(AppDbContext context, List<SubCategory> subCategories)
        {
            var tracks = new List<Track>
            {
                new Track { SubCategoryId = subCategories[0].SubCategoryId, TrackName = "Full Stack Web Developer", Description = "Master both frontend and backend development", DifficultyLevel = "Intermediate", EstimatedDuration = 300 },
                new Track { SubCategoryId = subCategories[0].SubCategoryId, TrackName = "Frontend Specialist", Description = "Deep dive into modern UI frameworks and best practices", DifficultyLevel = "Intermediate", EstimatedDuration = 180 },
                new Track { SubCategoryId = subCategories[1].SubCategoryId, TrackName = "Backend Engineering", Description = "Build scalable server-side applications", DifficultyLevel = "Advanced", EstimatedDuration = 200 },
                new Track { SubCategoryId = subCategories[2].SubCategoryId, TrackName = "Quality Assurance Engineer", Description = "Master testing frameworks and automation", DifficultyLevel = "Intermediate", EstimatedDuration = 120 },
                new Track { SubCategoryId = subCategories[4].SubCategoryId, TrackName = "Data Scientist Path", Description = "From statistics to machine learning", DifficultyLevel = "Advanced", EstimatedDuration = 250 },
                new Track { SubCategoryId = subCategories[5].SubCategoryId, TrackName = "ML Engineer", Description = "Production machine learning systems", DifficultyLevel = "Advanced", EstimatedDuration = 280 },
                new Track { SubCategoryId = subCategories[8].SubCategoryId, TrackName = "UI/UX Designer", Description = "Create beautiful and functional user interfaces", DifficultyLevel = "Intermediate", EstimatedDuration = 150 },
                new Track { SubCategoryId = subCategories[12].SubCategoryId, TrackName = "DevOps Engineer", Description = "Automate infrastructure and deployments", DifficultyLevel = "Advanced", EstimatedDuration = 220 }
            };

            context.Tracks.AddRange(tracks);
            await context.SaveChangesAsync();
            return tracks;
        }

        private static async Task<List<Technology>> SeedTechnologies(AppDbContext context, List<Track> tracks)
        {
            var technologies = new List<Technology>
            {
                // Frontend Technologies
                new Technology { TrackId = tracks[0].TrackId, TechnologyName = "React", Description = "A JavaScript library for building user interfaces", VideoUrl = "https://www.youtube.com/watch?v=react", CreatedAt = DateTime.UtcNow },
                new Technology { TrackId = tracks[0].TrackId, TechnologyName = "Vue.js", Description = "The Progressive JavaScript Framework", VideoUrl = "https://www.youtube.com/watch?v=vue", CreatedAt = DateTime.UtcNow },
                new Technology { TrackId = tracks[0].TrackId, TechnologyName = "Angular", Description = "Platform for building mobile and desktop web applications", VideoUrl = "https://www.youtube.com/watch?v=angular", CreatedAt = DateTime.UtcNow },
                new Technology { TrackId = tracks[1].TrackId, TechnologyName = "TypeScript", Description = "JavaScript with syntax for types", VideoUrl = "https://www.youtube.com/watch?v=typescript", CreatedAt = DateTime.UtcNow },
                new Technology { TrackId = tracks[1].TrackId, TechnologyName = "Next.js", Description = "The React Framework for Production", VideoUrl = "https://www.youtube.com/watch?v=nextjs", CreatedAt = DateTime.UtcNow },

                // Backend Technologies
                new Technology { TrackId = tracks[2].TrackId, TechnologyName = "Node.js", Description = "JavaScript runtime built on Chrome's V8 engine", VideoUrl = "https://www.youtube.com/watch?v=nodejs", CreatedAt = DateTime.UtcNow },
                new Technology { TrackId = tracks[2].TrackId, TechnologyName = "Django", Description = "High-level Python web framework", VideoUrl = "https://www.youtube.com/watch?v=django", CreatedAt = DateTime.UtcNow },
                new Technology { TrackId = tracks[2].TrackId, TechnologyName = "Spring Boot", Description = "Java-based framework for microservices", VideoUrl = "https://www.youtube.com/watch?v=spring", CreatedAt = DateTime.UtcNow },
                new Technology { TrackId = tracks[2].TrackId, TechnologyName = "FastAPI", Description = "Modern, fast web framework for building APIs with Python", VideoUrl = "https://www.youtube.com/watch?v=fastapi", CreatedAt = DateTime.UtcNow },

                // Testing Technologies
                new Technology { TrackId = tracks[3].TrackId, TechnologyName = "Jest", Description = "Delightful JavaScript Testing Framework", VideoUrl = "https://www.youtube.com/watch?v=jest", CreatedAt = DateTime.UtcNow },
                new Technology { TrackId = tracks[3].TrackId, TechnologyName = "Selenium", Description = "Browser automation framework", VideoUrl = "https://www.youtube.com/watch?v=selenium", CreatedAt = DateTime.UtcNow },
                new Technology { TrackId = tracks[3].TrackId, TechnologyName = "Cypress", Description = "Fast, easy and reliable testing for anything that runs in a browser", VideoUrl = "https://www.youtube.com/watch?v=cypress", CreatedAt = DateTime.UtcNow },

                // Data Science Technologies
                new Technology { TrackId = tracks[4].TrackId, TechnologyName = "Python", Description = "Programming language for data science and ML", VideoUrl = "https://www.youtube.com/watch?v=python", CreatedAt = DateTime.UtcNow },
                new Technology { TrackId = tracks[4].TrackId, TechnologyName = "Pandas", Description = "Data analysis and manipulation tool", VideoUrl = "https://www.youtube.com/watch?v=pandas", CreatedAt = DateTime.UtcNow },
                new Technology { TrackId = tracks[4].TrackId, TechnologyName = "NumPy", Description = "Fundamental package for scientific computing", VideoUrl = "https://www.youtube.com/watch?v=numpy", CreatedAt = DateTime.UtcNow },
                new Technology { TrackId = tracks[4].TrackId, TechnologyName = "Tableau", Description = "Visual analytics platform", VideoUrl = "https://www.youtube.com/watch?v=tableau", CreatedAt = DateTime.UtcNow },

                // ML Technologies
                new Technology { TrackId = tracks[5].TrackId, TechnologyName = "TensorFlow", Description = "End-to-end machine learning platform", VideoUrl = "https://www.youtube.com/watch?v=tensorflow", CreatedAt = DateTime.UtcNow },
                new Technology { TrackId = tracks[5].TrackId, TechnologyName = "PyTorch", Description = "Machine learning framework", VideoUrl = "https://www.youtube.com/watch?v=pytorch", CreatedAt = DateTime.UtcNow },
                new Technology { TrackId = tracks[5].TrackId, TechnologyName = "Scikit-learn", Description = "Machine learning library for Python", VideoUrl = "https://www.youtube.com/watch?v=sklearn", CreatedAt = DateTime.UtcNow },
                new Technology { TrackId = tracks[5].TrackId, TechnologyName = "Keras", Description = "Deep learning API", VideoUrl = "https://www.youtube.com/watch?v=keras", CreatedAt = DateTime.UtcNow },

                // Design Technologies
                new Technology { TrackId = tracks[6].TrackId, TechnologyName = "Figma", Description = "Collaborative interface design tool", VideoUrl = "https://www.youtube.com/watch?v=figma", CreatedAt = DateTime.UtcNow },
                new Technology { TrackId = tracks[6].TrackId, TechnologyName = "Adobe XD", Description = "Design and prototype user experiences", VideoUrl = "https://www.youtube.com/watch?v=adobexd", CreatedAt = DateTime.UtcNow },
                new Technology { TrackId = tracks[6].TrackId, TechnologyName = "Sketch", Description = "Digital design toolkit", VideoUrl = "https://www.youtube.com/watch?v=sketch", CreatedAt = DateTime.UtcNow },

                // DevOps Technologies
                new Technology { TrackId = tracks[7].TrackId, TechnologyName = "Docker", Description = "Platform for developing, shipping, and running applications", VideoUrl = "https://www.youtube.com/watch?v=docker", CreatedAt = DateTime.UtcNow },
                new Technology { TrackId = tracks[7].TrackId, TechnologyName = "Kubernetes", Description = "Container orchestration platform", VideoUrl = "https://www.youtube.com/watch?v=kubernetes", CreatedAt = DateTime.UtcNow },
                new Technology { TrackId = tracks[7].TrackId, TechnologyName = "Jenkins", Description = "Automation server for CI/CD", VideoUrl = "https://www.youtube.com/watch?v=jenkins", CreatedAt = DateTime.UtcNow },
                new Technology { TrackId = tracks[7].TrackId, TechnologyName = "AWS", Description = "Amazon Web Services cloud platform", VideoUrl = "https://www.youtube.com/watch?v=aws", CreatedAt = DateTime.UtcNow },
                new Technology { TrackId = tracks[7].TrackId, TechnologyName = "Terraform", Description = "Infrastructure as Code tool", VideoUrl = "https://www.youtube.com/watch?v=terraform", CreatedAt = DateTime.UtcNow }
            };

            context.Technologies.AddRange(technologies);
            await context.SaveChangesAsync();
            return technologies;
        }

        private static async Task<List<User>> SeedUsers(AppDbContext context)
        {
            var users = new List<User>
            {
                new User
                {
                    UserName = "Marwan Amr",
                    Email = "marwanam980@gmail.com",
                    PasswordHash = HashPassword("Admin@2024")
                },
                new User
                {
                    UserName = "Sarah Johnson",
                    Email = "sarah.instructor@techtrack.com",
                    PasswordHash = HashPassword("Teach@2024")
                },
                new User
                {
                    UserName = "Ahmed Hassan",
                    Email = "ahmed.learner@techtrack.com",
                    PasswordHash = HashPassword("Learn@2024")
                },
                new User
                {
                    UserName = "Emily Chen",
                    Email = "emily.chen@techtrack.com",
                    PasswordHash = HashPassword("User@2024")
                },
                new User
                {
                    UserName = "Michael Brown",
                    Email = "michael.brown@techtrack.com",
                    PasswordHash = HashPassword("User@2024")
                }
            };

            context.Users.AddRange(users);
            await context.SaveChangesAsync();
            return users;
        }

        private static async Task<List<Company>> SeedCompanies(AppDbContext context)
        {
            var companies = new List<Company>
            {
                new Company { CompanyName = "Google", Industry = "Technology", WebsiteUrl = "https://google.com", Description = "Global leader in search, cloud, and AI solutions" },
                new Company { CompanyName = "Microsoft", Industry = "Technology", WebsiteUrl = "https://microsoft.com", Description = "Enterprise software, cloud computing, and developer tools" },
                new Company { CompanyName = "Amazon", Industry = "E-commerce & Cloud", WebsiteUrl = "https://amazon.com", Description = "E-commerce giant and AWS cloud platform provider" },
                new Company { CompanyName = "Meta", Industry = "Social Media", WebsiteUrl = "https://meta.com", Description = "Social networking and virtual reality technologies" },
                new Company { CompanyName = "Netflix", Industry = "Entertainment", WebsiteUrl = "https://netflix.com", Description = "Streaming platform with advanced recommendation systems" },
                new Company { CompanyName = "IBM", Industry = "Technology", WebsiteUrl = "https://ibm.com", Description = "Enterprise AI, cloud, and quantum computing solutions" },
                new Company { CompanyName = "Apple", Industry = "Technology", WebsiteUrl = "https://apple.com", Description = "Consumer electronics and software innovation" },
                new Company { CompanyName = "Tesla", Industry = "Automotive & Energy", WebsiteUrl = "https://tesla.com", Description = "Electric vehicles and sustainable energy solutions" }
            };

            context.Companies.AddRange(companies);
            await context.SaveChangesAsync();
            return companies;
        }

        private static async Task<List<CompanyTechnology>> SeedCompanyTechnologies(AppDbContext context, List<Company> companies, List<Technology> technologies)
        {
            var companyTechs = new List<CompanyTechnology>
            {
                // Google uses React, Angular, Python, TensorFlow, Kubernetes
                new CompanyTechnology { CompanyId = companies[0].CompanyId, TechnologyId = technologies[0].TechnologyId, UsageLevel = "Primary", Notes = "Used extensively in Google products" },
                new CompanyTechnology { CompanyId = companies[0].CompanyId, TechnologyId = technologies[2].TechnologyId, UsageLevel = "Primary", Notes = "Angular was developed by Google" },
                new CompanyTechnology { CompanyId = companies[0].CompanyId, TechnologyId = technologies[12].TechnologyId, UsageLevel = "Primary", Notes = "Core language for ML and data science" },
                new CompanyTechnology { CompanyId = companies[0].CompanyId, TechnologyId = technologies[16].TechnologyId, UsageLevel = "Primary", Notes = "Google developed TensorFlow" },
                new CompanyTechnology { CompanyId = companies[0].CompanyId, TechnologyId = technologies[24].TechnologyId, UsageLevel = "Primary", Notes = "Google developed Kubernetes" },

                // Microsoft uses TypeScript, .NET, Azure
                new CompanyTechnology { CompanyId = companies[1].CompanyId, TechnologyId = technologies[3].TechnologyId, UsageLevel = "Primary", Notes = "Microsoft created TypeScript" },
                new CompanyTechnology { CompanyId = companies[1].CompanyId, TechnologyId = technologies[26].TechnologyId, UsageLevel = "Primary", Notes = "Microsoft Azure cloud platform" },

                // Amazon uses Node.js, AWS, Python
                new CompanyTechnology { CompanyId = companies[2].CompanyId, TechnologyId = technologies[5].TechnologyId, UsageLevel = "Primary", Notes = "Backend services" },
                new CompanyTechnology { CompanyId = companies[2].CompanyId, TechnologyId = technologies[26].TechnologyId, UsageLevel = "Primary", Notes = "AWS is Amazon's cloud platform" },
                new CompanyTechnology { CompanyId = companies[2].CompanyId, TechnologyId = technologies[12].TechnologyId, UsageLevel = "Secondary", Notes = "Data analysis and ML" },

                // Meta uses React, Python, PyTorch
                new CompanyTechnology { CompanyId = companies[3].CompanyId, TechnologyId = technologies[0].TechnologyId, UsageLevel = "Primary", Notes = "Meta created React" },
                new CompanyTechnology { CompanyId = companies[3].CompanyId, TechnologyId = technologies[17].TechnologyId, UsageLevel = "Primary", Notes = "Meta developed PyTorch" },
                new CompanyTechnology { CompanyId = companies[3].CompanyId, TechnologyId = technologies[12].TechnologyId, UsageLevel = "Primary", Notes = "AI and ML development" },

                // Netflix uses Node.js, React, Spring Boot
                new CompanyTechnology { CompanyId = companies[4].CompanyId, TechnologyId = technologies[0].TechnologyId, UsageLevel = "Primary", Notes = "Frontend for streaming platform" },
                new CompanyTechnology { CompanyId = companies[4].CompanyId, TechnologyId = technologies[5].TechnologyId, UsageLevel = "Primary", Notes = "Microservices architecture" },
                new CompanyTechnology { CompanyId = companies[4].CompanyId, TechnologyId = technologies[7].TechnologyId, UsageLevel = "Primary", Notes = "Backend services" },

                // IBM uses Python, TensorFlow, Kubernetes
                new CompanyTechnology { CompanyId = companies[5].CompanyId, TechnologyId = technologies[12].TechnologyId, UsageLevel = "Primary", Notes = "AI and quantum computing" },
                new CompanyTechnology { CompanyId = companies[5].CompanyId, TechnologyId = technologies[16].TechnologyId, UsageLevel = "Secondary", Notes = "Enterprise AI solutions" },
                new CompanyTechnology { CompanyId = companies[5].CompanyId, TechnologyId = technologies[24].TechnologyId, UsageLevel = "Primary", Notes = "Cloud orchestration" }
            };

            context.CompanyTechnologies.AddRange(companyTechs);
            await context.SaveChangesAsync();
            return companyTechs;
        }

        private static async Task<List<Roadmap>> SeedRoadmaps(AppDbContext context, List<Technology> technologies)
        {
            var roadmaps = new List<Roadmap>
            {
                new Roadmap { TechnologyId = technologies[0].TechnologyId, Title = "React Mastery Path", Description = "Complete roadmap to become a React expert" },
                new Roadmap { TechnologyId = technologies[5].TechnologyId, Title = "Node.js Backend Developer", Description = "Learn server-side JavaScript development" },
                new Roadmap { TechnologyId = technologies[12].TechnologyId, Title = "Python for Data Science", Description = "Master Python for data analysis and ML" },
                new Roadmap { TechnologyId = technologies[16].TechnologyId, Title = "TensorFlow Deep Learning", Description = "Build neural networks with TensorFlow" },
                new Roadmap { TechnologyId = technologies[23].TechnologyId, Title = "Docker Containerization", Description = "Master container technology" },
                new Roadmap { TechnologyId = technologies[24].TechnologyId, Title = "Kubernetes Orchestration", Description = "Deploy and manage containerized applications" },
                new Roadmap { TechnologyId = technologies[20].TechnologyId, Title = "Figma Design System", Description = "Create scalable design systems" },
                new Roadmap { TechnologyId = technologies[9].TechnologyId, Title = "Jest Testing Mastery", Description = "Write comprehensive unit and integration tests" }
            };

            context.Roadmaps.AddRange(roadmaps);
            await context.SaveChangesAsync();
            return roadmaps;
        }

        //private static async Task<List<RoadmapStep>> SeedRoadmapSteps(AppDbContext context, List<Roadmap> roadmaps)
        //{
        //    var steps = new List<RoadmapStep>();

        //    // React Mastery Path steps
        //    steps.AddRange(new[]
        //    {
        //        new RoadmapStep { RoadmapId = roadmaps[0].RoadmapId, StepTitle = "JavaScript Fundamentals", StepDescription = "Master ES6+ features, async/await, and modern JavaScript", StepOrder = 1, CreatedAt = DateTime.UtcNow },
        //        new RoadmapStep { RoadmapId = roadmaps[0].RoadmapId, StepTitle = "React Basics", StepDescription = "Components, props, state, and JSX", StepOrder = 2, CreatedAt = DateTime.UtcNow },
        //        new RoadmapStep { RoadmapId = roadmaps[0].RoadmapId, StepTitle = "React Hooks", StepDescription = "useState, useEffect, useContext, custom hooks", StepOrder = 3, CreatedAt = DateTime.UtcNow },
        //        new RoadmapStep { RoadmapId = roadmaps[0].RoadmapId, StepTitle = "State Management", StepDescription = "Redux, Context API, and state management patterns", StepOrder = 4, CreatedAt = DateTime.UtcNow },
        //        new RoadmapStep { RoadmapId = roadmaps[0].RoadmapId, StepTitle = "Advanced Patterns", StepDescription = "Performance optimization, code splitting, lazy loading", StepOrder = 5, CreatedAt = DateTime.UtcNow }
        //    });

        //    // Node.js Backend Developer steps
        //    steps.AddRange(new[]
        //    {
        //        new RoadmapStep { RoadmapId = roadmaps[1].RoadmapId, StepTitle = "Node.js Basics", StepDescription = "Event loop, modules, npm, and core APIs", StepOrder = 1, CreatedAt = DateTime.UtcNow },
        //        new RoadmapStep { RoadmapId = roadmaps[1].RoadmapId, StepTitle = "Express.js Framework", StepDescription = "Routing, middleware, and REST APIs", StepOrder = 2, CreatedAt = DateTime.UtcNow },
        //        new RoadmapStep { RoadmapId = roadmaps[1].RoadmapId, StepTitle = "Database Integration", StepDescription = "MongoDB, PostgreSQL, ORMs", StepOrder = 3, CreatedAt = DateTime.UtcNow },
        //        new RoadmapStep { RoadmapId = roadmaps[1].RoadmapId, StepTitle = "Authentication & Security", StepDescription = "JWT, OAuth, security best practices", StepOrder = 4, CreatedAt = DateTime.UtcNow },
        //        new RoadmapStep { RoadmapId = roadmaps[1].RoadmapId, StepTitle = "Testing & Deployment", StepDescription = "Unit tests, integration tests, CI/CD", StepOrder = 5, CreatedAt = DateTime.UtcNow }
        //    });

        //    // Python for Data Science steps
        //    steps.AddRange(new[]
        //    {
        //        new RoadmapStep { RoadmapId = roadmaps[2].RoadmapId, StepTitle = "Python Fundamentals", StepDescription = "Syntax, data structures, OOP concepts", StepOrder = 1, CreatedAt = DateTime.UtcNow },
        //        new RoadmapStep { RoadmapId = roadmaps[2].RoadmapId, StepTitle = "NumPy & Pandas", StepDescription = "Data manipulation and analysis", StepOrder = 2, CreatedAt = DateTime.UtcNow },
        //        new RoadmapStep { RoadmapId = roadmaps[2].RoadmapId, StepTitle = "Data Visualization", StepDescription = "Matplotlib, Seaborn, Plotly", StepOrder = 3, CreatedAt = DateTime.UtcNow },
        //        new RoadmapStep { RoadmapId = roadmaps[2].RoadmapId, StepTitle = "Statistical Analysis", StepDescription = "Descriptive statistics, hypothesis testing", StepOrder = 4, CreatedAt = DateTime.UtcNow },
        //        new RoadmapStep { RoadmapId = roadmaps[2].RoadmapId, StepTitle = "Machine Learning Basics", StepDescription = "Scikit-learn, model training and evaluation", StepOrder = 5, CreatedAt = DateTime.UtcNow }
        //    });

        //    // Docker steps
        //    steps.AddRange(new[]
        //    {
        //        new RoadmapStep { RoadmapId = roadmaps[4].RoadmapId, StepTitle = "Container Basics", StepDescription = "Images, containers, Docker CLI", StepOrder = 1, CreatedAt = DateTime.UtcNow },
        //        new RoadmapStep { RoadmapId = roadmaps[4].RoadmapId, StepTitle = "Dockerfile Creation", StepDescription = "Writing efficient Dockerfiles", StepOrder = 2, CreatedAt = DateTime.UtcNow },
        //        new RoadmapStep { RoadmapId = roadmaps[4].RoadmapId, StepTitle = "Docker Compose", StepDescription = "Multi-container applications", StepOrder = 3, CreatedAt = DateTime.UtcNow },
        //        new RoadmapStep { RoadmapId = roadmaps[4].RoadmapId, StepTitle = "Networking & Volumes", StepDescription = "Container networking and data persistence", StepOrder = 4, CreatedAt = DateTime.UtcNow }
        //    });

        //    context.RoadmapSteps.AddRange(steps);
        //    await context.SaveChangesAsync();
        //    return steps;
        //}

        private static async Task<List<InterviewQuestion>> SeedInterviewQuestions(AppDbContext context, List<Technology> technologies)
        {
            var questions = new List<InterviewQuestion>
            {
                // React Questions
                new InterviewQuestion { TechnologyId = technologies[0].TechnologyId, QuestionText = "What are React hooks and why are they useful?", DifficultyLevel = "Medium", QuestionType = "Technical", SampleAnswer = "Hooks allow you to use state and other React features without writing a class. They make it easier to reuse stateful logic between components." },
                new InterviewQuestion { TechnologyId = technologies[0].TechnologyId, QuestionText = "Explain the virtual DOM in React", DifficultyLevel = "Medium", QuestionType = "Technical", SampleAnswer = "The virtual DOM is a lightweight copy of the actual DOM. React uses it to optimize updates by comparing changes and updating only what's necessary." },
                new InterviewQuestion { TechnologyId = technologies[0].TechnologyId, QuestionText = "What is the difference between props and state?", DifficultyLevel = "Easy", QuestionType = "Technical", SampleAnswer = "Props are read-only data passed from parent to child components. State is mutable data managed within a component." },
                new InterviewQuestion { TechnologyId = technologies[0].TechnologyId, QuestionText = "How do you optimize React application performance?", DifficultyLevel = "Hard", QuestionType = "Technical", SampleAnswer = "Use React.memo, useMemo, useCallback, code splitting, lazy loading, and avoid unnecessary re-renders." },

                // Node.js Questions
                new InterviewQuestion { TechnologyId = technologies[5].TechnologyId, QuestionText = "Explain the event loop in Node.js", DifficultyLevel = "Medium", QuestionType = "Technical", SampleAnswer = "The event loop handles asynchronous callbacks by executing them in phases: timers, pending callbacks, idle, poll, check, and close callbacks." },
                new InterviewQuestion { TechnologyId = technologies[5].TechnologyId, QuestionText = "What is middleware in Express.js?", DifficultyLevel = "Easy", QuestionType = "Technical", SampleAnswer = "Middleware functions have access to request and response objects and can execute code, modify them, or end the request-response cycle." },
                new InterviewQuestion { TechnologyId = technologies[5].TechnologyId, QuestionText = "How do you handle errors in Node.js?", DifficultyLevel = "Medium", QuestionType = "Technical", SampleAnswer = "Use try-catch blocks for synchronous code, .catch() for promises, and error-handling middleware in Express." },

                // Python Questions
                new InterviewQuestion { TechnologyId = technologies[12].TechnologyId, QuestionText = "What are list comprehensions in Python?", DifficultyLevel = "Easy", QuestionType = "Technical", SampleAnswer = "List comprehensions provide a concise way to create lists based on existing lists: [x**2 for x in range(10)]" },
                new InterviewQuestion { TechnologyId = technologies[12].TechnologyId, QuestionText = "Explain decorators in Python", DifficultyLevel = "Medium", QuestionType = "Technical", SampleAnswer = "Decorators are functions that modify the behavior of other functions. They use @decorator syntax and are useful for logging, authentication, etc." },
                new InterviewQuestion { TechnologyId = technologies[12].TechnologyId, QuestionText = "What is the difference between a list and a tuple?", DifficultyLevel = "Easy", QuestionType = "Technical", SampleAnswer = "Lists are mutable (can be changed), tuples are immutable. Lists use [], tuples use ()." },

                // TensorFlow Questions
                new InterviewQuestion { TechnologyId = technologies[16].TechnologyId, QuestionText = "What is a tensor in TensorFlow?", DifficultyLevel = "Easy", QuestionType = "Technical", SampleAnswer = "A tensor is a multi-dimensional array, the fundamental data structure in TensorFlow for representing data." },
                new InterviewQuestion { TechnologyId = technologies[16].TechnologyId, QuestionText = "Explain overfitting and how to prevent it", DifficultyLevel = "Hard", QuestionType = "Technical", SampleAnswer = "Overfitting occurs when a model learns training data too well, including noise. Prevention includes regularization, dropout, cross-validation, and more training data." },
                new InterviewQuestion { TechnologyId = technologies[16].TechnologyId, QuestionText = "What is backpropagation?", DifficultyLevel = "Hard", QuestionType = "Technical", SampleAnswer = "Backpropagation is an algorithm for training neural networks by calculating gradients and updating weights to minimize loss." },

                // Docker Questions
                new InterviewQuestion { TechnologyId = technologies[23].TechnologyId, QuestionText = "What is the difference between an image and a container?", DifficultyLevel = "Easy", QuestionType = "Technical", SampleAnswer = "An image is a read-only template with instructions for creating a container. A container is a running instance of an image." },
                new InterviewQuestion { TechnologyId = technologies[23].TechnologyId, QuestionText = "How do you optimize Docker images?", DifficultyLevel = "Medium", QuestionType = "Technical", SampleAnswer = "Use multi-stage builds, minimize layers, use .dockerignore, choose lightweight base images, and remove unnecessary files." },
                new InterviewQuestion { TechnologyId = technologies[23].TechnologyId, QuestionText = "What is Docker Compose used for?", DifficultyLevel = "Easy", QuestionType = "Technical", SampleAnswer = "Docker Compose is used to define and run multi-container Docker applications using a YAML file." },

                // Kubernetes Questions
                new InterviewQuestion { TechnologyId = technologies[24].TechnologyId, QuestionText = "What is a pod in Kubernetes?", DifficultyLevel = "Easy", QuestionType = "Technical", SampleAnswer = "A pod is the smallest deployable unit in Kubernetes, containing one or more containers that share storage and network resources." },
                new InterviewQuestion { TechnologyId = technologies[24].TechnologyId, QuestionText = "Explain Kubernetes services", DifficultyLevel = "Medium", QuestionType = "Technical", SampleAnswer = "Services expose pods to network traffic and provide stable endpoints for accessing applications running in pods." },
                new InterviewQuestion { TechnologyId = technologies[24].TechnologyId, QuestionText = "What is the difference between a Deployment and a StatefulSet?", DifficultyLevel = "Hard", QuestionType = "Technical", SampleAnswer = "Deployments manage stateless applications with interchangeable pods. StatefulSets manage stateful applications requiring stable identities and persistent storage." },

                // TypeScript Questions
                new InterviewQuestion { TechnologyId = technologies[3].TechnologyId, QuestionText = "What are TypeScript interfaces?", DifficultyLevel = "Easy", QuestionType = "Technical", SampleAnswer = "Interfaces define the structure of objects, specifying property names and types without implementation." },
                new InterviewQuestion { TechnologyId = technologies[3].TechnologyId, QuestionText = "Explain generics in TypeScript", DifficultyLevel = "Medium", QuestionType = "Technical", SampleAnswer = "Generics allow you to write reusable code that works with multiple types while maintaining type safety." },

                // Jest Questions
                new InterviewQuestion { TechnologyId = technologies[9].TechnologyId, QuestionText = "What is mocking in Jest?", DifficultyLevel = "Medium", QuestionType = "Technical", SampleAnswer = "Mocking replaces real implementations with fake ones to isolate the code being tested from external dependencies." },
                new InterviewQuestion { TechnologyId = technologies[9].TechnologyId, QuestionText = "How do you test async code in Jest?", DifficultyLevel = "Medium", QuestionType = "Technical", SampleAnswer = "Use async/await, return promises, or use done callback. Jest also provides resolves and rejects matchers." },

                // Figma Questions
                new InterviewQuestion { TechnologyId = technologies[20].TechnologyId, QuestionText = "What are Figma components?", DifficultyLevel = "Easy", QuestionType = "Technical", SampleAnswer = "Components are reusable design elements that can be instantiated multiple times. Changes to the master component update all instances." },
                new InterviewQuestion { TechnologyId = technologies[20].TechnologyId, QuestionText = "Explain Auto Layout in Figma", DifficultyLevel = "Medium", QuestionType = "Technical", SampleAnswer = "Auto Layout creates responsive frames that automatically adjust based on their content, similar to flexbox in CSS." },

                // Behavioral Questions
                new InterviewQuestion { TechnologyId = technologies[0].TechnologyId, QuestionText = "Describe a challenging bug you fixed in a React application", DifficultyLevel = "Medium", QuestionType = "Behavioral", SampleAnswer = "Focus on your problem-solving approach, debugging techniques, and what you learned from the experience." },
                new InterviewQuestion { TechnologyId = technologies[5].TechnologyId, QuestionText = "How do you handle disagreements about technical decisions?", DifficultyLevel = "Medium", QuestionType = "Behavioral", SampleAnswer = "Listen to all perspectives, present data-driven arguments, focus on project goals, and be willing to compromise." },

                // System Design Questions
                new InterviewQuestion { TechnologyId = technologies[5].TechnologyId, QuestionText = "Design a URL shortening service", DifficultyLevel = "Hard", QuestionType = "SystemDesign", SampleAnswer = "Discuss database schema, hash functions, scaling strategies, caching, and handling collisions." },
                new InterviewQuestion { TechnologyId = technologies[24].TechnologyId, QuestionText = "How would you design a microservices architecture?", DifficultyLevel = "Hard", QuestionType = "SystemDesign", SampleAnswer = "Cover service boundaries, communication patterns, data management, monitoring, and deployment strategies." }
            };

            context.InterviewQuestions.AddRange(questions);
            await context.SaveChangesAsync();
            return questions;
        }

        private static async Task<List<UserTechnologyReview>> SeedReviews(AppDbContext context, List<User> users, List<Technology> technologies)
        {
            var reviews = new List<UserTechnologyReview>
            {
                new UserTechnologyReview { UserId = users[0].UserId, TechnologyId = technologies[0].TechnologyId, Rating = 5, ReviewText = "React is an excellent library for building modern UIs. The component-based architecture makes code very maintainable." },
                new UserTechnologyReview { UserId = users[1].UserId, TechnologyId = technologies[0].TechnologyId, Rating = 4, ReviewText = "Great for building interactive UIs, but has a steep learning curve for beginners." },
                new UserTechnologyReview { UserId = users[2].UserId, TechnologyId = technologies[5].TechnologyId, Rating = 5, ReviewText = "Node.js revolutionized backend development. The async model is perfect for I/O-intensive applications." },
                new UserTechnologyReview { UserId = users[0].UserId, TechnologyId = technologies[12].TechnologyId, Rating = 5, ReviewText = "Python is incredibly versatile. Perfect for data science, ML, and general programming." },
                new UserTechnologyReview { UserId = users[3].UserId, TechnologyId = technologies[16].TechnologyId, Rating = 4, ReviewText = "Powerful ML framework with excellent documentation. The ecosystem is mature and production-ready." },
                new UserTechnologyReview { UserId = users[4].UserId, TechnologyId = technologies[23].TechnologyId, Rating = 5, ReviewText = "Docker simplified our deployment process dramatically. Containers are the future of application deployment." },
                new UserTechnologyReview { UserId = users[1].UserId, TechnologyId = technologies[24].TechnologyId, Rating = 4, ReviewText = "Kubernetes is complex but essential for managing containerized applications at scale." },
                new UserTechnologyReview { UserId = users[2].UserId, TechnologyId = technologies[20].TechnologyId, Rating = 5, ReviewText = "Figma transformed our design workflow. Real-time collaboration is a game-changer." },
                new UserTechnologyReview { UserId = users[3].UserId, TechnologyId = technologies[3].TechnologyId, Rating = 5, ReviewText = "TypeScript catches so many bugs before runtime. Type safety is worth the extra syntax." },
                new UserTechnologyReview { UserId = users[4].UserId, TechnologyId = technologies[9].TechnologyId, Rating = 4, ReviewText = "Jest makes testing JavaScript enjoyable. The snapshot testing feature is particularly useful." }
            };

            context.UserTechnologyReviews.AddRange(reviews);
            await context.SaveChangesAsync();
            return reviews;
        }

        private static string HashPassword(string password)
        {
            using var sha = System.Security.Cryptography.SHA256.Create();
            var bytes = System.Text.Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}