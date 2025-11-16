// using System.Linq;
// using TechPathNavigator.Models;

// namespace TechPathNavigator.Data
// {
//     public static class DbSeeder
//     {
//         public static void SeedCategories(ApplicationDbContext context)
//         {
//             if (!context.Categories.Any())
//             {
//                 var categories = new[]
//                 {
//                     new Category
//                     {
//                         CategoryName = "Software Development",
//                         Description = "Learn to build applications and software using programming languages like C#, Python, and JavaScript.",
//                         ImageBase64 = ""
//                     },
//                     new Category
//                     {
//                         CategoryName = "DevOps & Infrastructure",
//                         Description = "Discover how to automate, deploy, and manage applications efficiently using cloud and CI/CD tools.",
//                         ImageBase64 = ""
//                     },
//                     new Category
//                     {
//                         CategoryName = "Data & AI",
//                         Description = "Explore data analysis, machine learning, and artificial intelligence to turn raw data into smart insights.",
//                         ImageBase64 = ""
//                     },
//                     new Category
//                     {
//                         CategoryName = "Design & User Experience",
//                         Description = "Create intuitive and engaging interfaces that make users love the products they interact with.",
//                         ImageBase64 = ""
//                     }
//                 };

//                 context.Categories.AddRange(categories);
//                 context.SaveChanges();
//             }
//         }

//         public static void SeedCompanies(ApplicationDbContext context)
//         {
//             if (!context.Companies.Any())
//             {
//                 var companies = new[]
//                 {
//                     new Company
//                     {
//                         CompanyName = "Google",
//                         Industry = "Web & Cloud",
//                         WebsiteUrl = "https://www.google.com",
//                         Description = "A global tech leader in search, cloud computing, AI, and web technologies."
//                     },
//                     new Company
//                     {
//                         CompanyName = "Microsoft",
//                         Industry = "Software & Cloud",
//                         WebsiteUrl = "https://www.microsoft.com",
//                         Description = "Creator of Windows, Azure, and .NET — a pioneer in enterprise and cloud solutions."
//                     },
//                     new Company
//                     {
//                         CompanyName = "Amazon",
//                         Industry = "E-commerce & Cloud",
//                         WebsiteUrl = "https://www.amazon.com",
//                         Description = "Leading e-commerce platform and provider of AWS cloud services."
//                     },
//                     new Company
//                     {
//                         CompanyName = "IBM",
//                         Industry = "Data & AI",
//                         WebsiteUrl = "https://www.ibm.com",
//                         Description = "A historic innovator in data science, AI (Watson), and enterprise technology."
//                     },
//                     new Company
//                     {
//                         CompanyName = "Unity Technologies",
//                         Industry = "Game Development",
//                         WebsiteUrl = "https://unity.com",
//                         Description = "The company behind Unity — the most popular engine for 2D and 3D game development."
//                     },
//                     new Company
//                     {
//                         CompanyName = "CrowdStrike",
//                         Industry = "Cyber Security",
//                         WebsiteUrl = "https://www.crowdstrike.com",
//                         Description = "A leading cybersecurity company specializing in endpoint protection and threat intelligence."
//                     },
//                     new Company
//                     {
//                         CompanyName = "Palantir",
//                         Industry = "Data & AI",
//                         WebsiteUrl = "https://www.palantir.com",
//                         Description = "Builds powerful data platforms for defense, healthcare, and finance industries."
//                     },
//                     new Company
//                     {
//                         CompanyName = "Figma",
//                         Industry = "UI/UX Design",
//                         WebsiteUrl = "https://www.figma.com",
//                         Description = "The collaborative design tool used by teams worldwide to build user interfaces."
//                     },
//                     new Company
//                     {
//                         CompanyName = "Netflix",
//                         Industry = "Web & Streaming",
//                         WebsiteUrl = "https://www.netflix.com",
//                         Description = "A tech-driven entertainment company known for its scalable backend and microservices."
//                     },
//                     new Company
//                     {
//                         CompanyName = "GitHub",
//                         Industry = "DevOps & Development",
//                         WebsiteUrl = "https://github.com",
//                         Description = "The home for open-source projects and developer collaboration, owned by Microsoft."
//                     }
//                 };

//                 context.Companies.AddRange(companies);
//                 context.SaveChanges();
//             }
//         }

//         public static void SeedCompanyTechnologies(ApplicationDbContext context)
//         {
//             if (!context.CompanyTechnologies.Any())
//             {
//                 var companyTechnologies = new[]
//                 {
//                     new CompanyTechnology
//                     {
//                         CompanyId = 2,
//                         TechnologyId = 4,
//                         UsageLevel = "primary",
//                         Notes = "Microsoft uses .NET Core for most of its backend services and Azure tools."
//                     },
//                     new CompanyTechnology
//                     {
//                         CompanyId = 2,
//                         TechnologyId = 5,
//                         UsageLevel = "primary",
//                         Notes = "Entity Framework Core is widely used in Microsoft's internal .NET applications."
//                     },
//                     new CompanyTechnology
//                     {
//                         CompanyId = 3,
//                         TechnologyId = 3,
//                         UsageLevel = "primary",
//                         Notes = "Meta created and maintains React for all its web interfaces (Facebook, Instagram)."
//                     },
//                     new CompanyTechnology
//                     {
//                         CompanyId = 1,
//                         TechnologyId = 2,
//                         UsageLevel = "primary",
//                         Notes = "Google uses JavaScript extensively across its web products like Gmail and Docs."
//                     },
//                     new CompanyTechnology
//                     {
//                         CompanyId = 1,
//                         TechnologyId = 18,
//                         UsageLevel = "primary",
//                         Notes = "Google uses Node.js for many of its scalable backend services."
//                     },
//                     new CompanyTechnology
//                     {
//                         CompanyId = 4,
//                         TechnologyId = 7,
//                         UsageLevel = "primary",
//                         Notes = "Apple uses Swift as the main language for all iOS and macOS app development."
//                     },
//                     new CompanyTechnology
//                     {
//                         CompanyId = 5,
//                         TechnologyId = 4,
//                         UsageLevel = "secondary",
//                         Notes = "Amazon uses .NET Core in some AWS services and enterprise solutions."
//                     },
//                     new CompanyTechnology
//                     {
//                         CompanyId = 7,
//                         TechnologyId = 9,
//                         UsageLevel = "primary",
//                         Notes = "Unity Technologies uses its own Unity engine to build and demo games."
//                     },
//                     new CompanyTechnology
//                     {
//                         CompanyId = 10,
//                         TechnologyId = 16,
//                         UsageLevel = "primary",
//                         Notes = "Figma is built with and designed using its own Figma tool."
//                     },
//                     new CompanyTechnology
//                     {
//                         CompanyId = 8,
//                         TechnologyId = 10,
//                         UsageLevel = "primary",
//                         Notes = "CrowdStrike uses Wireshark for deep network traffic analysis in threat detection."
//                     },
//                     new CompanyTechnology
//                     {
//                         CompanyId = 6,
//                         TechnologyId = 14,
//                         UsageLevel = "primary",
//                         Notes = "IBM uses Python and Pandas for data processing in its AI and analytics platforms."
//                     },
//                     new CompanyTechnology
//                     {
//                         CompanyId = 9,
//                         TechnologyId = 15,
//                         UsageLevel = "primary",
//                         Notes = "Palantir uses Scikit-learn for machine learning models in its data platforms."
//                     },
//                     new CompanyTechnology
//                     {
//                         CompanyId = 11,
//                         TechnologyId = 3,
//                         UsageLevel = "secondary",
//                         Notes = "Netflix uses React for parts of its frontend UI alongside other frameworks."
//                     },
//                     new CompanyTechnology
//                     {
//                         CompanyId = 12,
//                         TechnologyId = 2,
//                         UsageLevel = "primary",
//                         Notes = "GitHub's web interface relies heavily on JavaScript for dynamic interactions."
//                     },
//                     new CompanyTechnology
//                     {
//                         CompanyId = 1,
//                         TechnologyId = 12,
//                         UsageLevel = "primary",
//                         Notes = "Google uses SQL in BigQuery and many internal data systems."
//                     }
//                 };

//                 context.CompanyTechnologies.AddRange(companyTechnologies);
//                 context.SaveChanges();
//             }
//         }

//         public static void SeedInterviewQuestions(ApplicationDbContext context)
//         {
//             if (!context.InterviewQuestions.Any())
//             {
//                 var questions = new[]
//                 {
//                     new InterviewQuestion
//                     {
//                         TechnologyId = 1,
//                         QuestionText = "What is the difference between HTML and CSS?",
//                         DifficultyLevel = "Beginner",
//                         QuestionType = "technical",
//                         SampleAnswer = "HTML defines the structure of a webpage (like headings and paragraphs), while CSS controls its appearance (like colors, fonts, and layout)."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId = 1,
//                         QuestionText = "What are semantic HTML elements and why are they important?",
//                         DifficultyLevel = "Intermediate",
//                         QuestionType = "technical",
//                         SampleAnswer = "Semantic elements like <header>, <article>, and <footer> give meaning to content, improving accessibility and SEO by helping browsers and search engines understand the page structure."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 1,
//                         QuestionText: "Explain the difference between Flexbox and CSS Grid and when to use each.",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Flexbox is best for one-dimensional layouts (rows or columns), while CSS Grid is used for two-dimensional layouts. Grid allows more complex and precise control over layout structure."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 2,
//                         QuestionText: "What is the difference between var, let, and const?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "var is function-scoped and can be redeclared, let and const are block-scoped; const cannot be reassigned while let can."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 2,
//                         QuestionText: "What are JavaScript promises and how do they work?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "A Promise represents a value that may be available now, later, or never. It helps handle asynchronous operations with .then() for success and .catch() for errors."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 2,
//                         QuestionText: "Explain the concept of closures in JavaScript.",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "A closure gives access to an outer function’s scope from an inner function even after the outer function has executed. It’s often used for data privacy or stateful functions."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 3,
//                         QuestionText: "What is React used for?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "React is used to build reusable and interactive user interfaces using components."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 3,
//                         QuestionText: "What is the difference between state and props in React?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "Props are read-only inputs passed from a parent component, while state is local and managed within the component itself."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 3,
//                         QuestionText: "Explain the purpose of React hooks like useEffect and useMemo.",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "useEffect runs side effects (like API calls or event listeners), while useMemo optimizes performance by memoizing expensive computations to prevent unnecessary re-renders."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 4,
//                         QuestionText: "What is Tailwind CSS and why is it called utility-first?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Tailwind CSS is a utility-first CSS framework that provides small, reusable classes for building custom designs directly in your HTML."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 4,
//                         QuestionText: "How can you customize the default Tailwind configuration?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "You can modify the `tailwind.config.js` file to add custom colors, fonts, breakpoints, and extend existing design tokens."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 4,
//                         QuestionText: "Explain the concept of JIT (Just-in-Time) mode in Tailwind CSS.",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "JIT mode generates styles on-demand as you write HTML, drastically reducing build times and allowing dynamic class generation for better performance and flexibility."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 5,
//                         QuestionText: "What is Redux used for?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Redux is used for managing global application state in JavaScript apps, ensuring consistent data flow across components."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 5,
//                         QuestionText: "What are actions and reducers in Redux?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "Actions are plain objects describing what happened, while reducers specify how the application's state changes in response to those actions."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 5,
//                         QuestionText: "What is the difference between Redux Toolkit and traditional Redux setup?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Redux Toolkit simplifies Redux by reducing boilerplate code, offering built-in utilities like createSlice and createAsyncThunk for cleaner and more maintainable state logic."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 6,
//                         QuestionText: "What is .NET Core and how is it different from the traditional .NET Framework?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: ".NET Core is a cross-platform, open-source framework for building modern apps. Unlike the .NET Framework, it runs on Windows, macOS, and Linux."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 6,
//                         QuestionText: "Explain the concept of middleware in ASP.NET Core.",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "Middleware are components that process requests and responses in a pipeline. Each middleware can handle, modify, or pass the request to the next one."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 6,
//                         QuestionText: "How does dependency injection work in .NET Core?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Dependency Injection is built-in in .NET Core. It allows registering services in the `Startup.cs` file using the `IServiceCollection`, making dependencies easier to manage and test."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 7,
//                         QuestionText: "What is Entity Framework Core used for?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Entity Framework Core is an ORM (Object-Relational Mapper) that allows developers to interact with databases using C# objects instead of writing SQL queries."
//                     },
//                     new InterviewQuestion  
//                     {
//                         TechnologyId: 7,
//                         QuestionText: "What is the difference between Code First and Database First approaches in EF Core?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "Code First lets you create the database from your C# models, while Database First generates models from an existing database structure."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 7,
//                         QuestionText: "Explain the purpose of migrations in EF Core.",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Migrations Technology and apply schema changes to the database as your models evolve, ensuring database structure stays synchronized with your application code."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 8,
//                         QuestionText: "What is Node.js and what makes it different from traditional server-side technologies?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Node.js is a JavaScript runtime built on Chrome's V8 engine. It uses a non-blocking, event-driven model that makes it lightweight and efficient for I/O-heavy applications."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 8,
//                         QuestionText: "What is the event loop in Node.js?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "The event loop allows Node.js to perform non-blocking I/O operations by offloading tasks to the system and handling callbacks asynchronously."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 8,
//                         QuestionText: "How does Node.js handle asynchronous operations internally?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Node.js uses the event loop and a thread pool (via libuv) to execute asynchronous tasks like file I/O or network requests without blocking the main thread."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 9,
//                         QuestionText: "What is Express.js used for?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Express.js is a minimal web framework for Node.js that simplifies building APIs and handling HTTP requests and responses."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 9,
//                         QuestionText: "What are middleware functions in Express.js?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "Middleware functions are functions that have access to the request and response objects. They can modify them, end the request, or call the next middleware."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 9,
//                         QuestionText: "Explain how error handling works in Express.js.",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Error-handling middleware in Express has four parameters `(err, req, res, next)` and is used to catch and handle errors in the request-response cycle."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 10,
//                         QuestionText: "What does MERN stand for and what is it used for?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "MERN stands for MongoDB, Express.js, React, and Node.js. It’s used to build full-stack JavaScript web applications."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 10,
//                         QuestionText: "How do the frontend and backend communicate in a MERN application?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "The frontend (React) sends HTTP requests to the backend (Express/Node.js) using APIs, which interact with MongoDB to fetch or store data."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 10,
//                         QuestionText: "Explain how you would implement authentication in a MERN stack application.",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "You can implement authentication using JWT. The backend issues a signed token upon login, and the frontend stores it to include in API requests for verification."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 11,
//                         QuestionText: "What is Django used for in full-stack web development?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Django is a Python-based web framework used for backend development. It helps handle authentication, database models, and APIs efficiently."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 11,
//                         QuestionText: "How can Django serve data to a React frontend?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "Django REST Framework can be used to create RESTful APIs that React can call using fetch or Axios to retrieve and send data."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 11,
//                         QuestionText: "How would you deploy a Django + React full-stack application?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "You can deploy both with Nginx and Gunicorn: build the React app, serve it as static files via Django or a CDN, and host the backend API on the same server or separately."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 12,
//                         QuestionText: "What is the role of Angular in a .NET full-stack application?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Angular is used to build the frontend of the application, providing a dynamic and interactive user interface that communicates with the .NET backend."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 12,
//                         QuestionText: "How does data binding work between .NET APIs and Angular components?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "Angular uses services to make HTTP requests to the .NET API endpoints. The received data is then bound to components for display using Angular's data binding."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 12,
//                         QuestionText: "How would you handle authentication and authorization in a .NET + Angular application?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Implement JWT authentication in the .NET backend and store the token in the frontend (localStorage). Angular includes the token in API headers to verify user access."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 13,
//                         QuestionText: "What is the difference between 'val' and 'var' in Kotlin?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "val is used for immutable variables (cannot be reassigned) while var is used for mutable variables (can be changed)."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 13,
//                         QuestionText: "Explain what null safety means in Kotlin.",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "Null safety in Kotlin prevents null pointer exceptions by using nullable types (e.g., String?) and safe call operators (?.)."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 13,
//                         QuestionText: "How does Kotlin handle coroutines for asynchronous programming?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Kotlin uses coroutines to simplify asynchronous programming by allowing code to be suspended and resumed without blocking threads."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 14,
//                         QuestionText: "Which language is used to develop Flutter applications?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Flutter apps are developed using the Dart programming language."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 14,
//                         QuestionText: "What is the difference between StatelessWidget and StatefulWidget in Flutter?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "A StatelessWidget has immutable state that doesn’t change, while a StatefulWidget can rebuild when its internal state changes."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 14,
//                         QuestionText: "Explain how Flutter interacts with native code.",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Flutter uses platform channels to communicate between Dart and native code (Java/Kotlin for Android, Swift/Objective-C for iOS)."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 15,
//                         QuestionText: "Which programming language is mainly used in React Native?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "React Native uses JavaScript as its main programming language."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 15,
//                         QuestionText: "What is the purpose of the 'useState' hook in React Native?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "useState is a React Hook that allows functional components to manage and update state within the component."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 15,
//                         QuestionText: "How does React Native bridge work to interact with native modules?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "The React Native bridge allows communication between JavaScript and native code through asynchronous message passing."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 16,
//                         QuestionText: "What are optionals in Swift?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Optionals are variables that can hold either a value or nil, allowing safer handling of missing data in Swift."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 16,
//                         QuestionText: "Explain the difference between struct and class in Swift.",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "Structs are value types copied when assigned, while classes are reference types passed by reference."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 16,
//                         QuestionText: "How does Swift handle memory management?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Swift uses Automatic Reference Counting (ARC) to manage memory by automatically releasing unused objects."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 17,
//                         QuestionText: "What is SwiftUI used for?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "SwiftUI is a framework used to build user interfaces across Apple platforms using a declarative syntax."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 17,
//                         QuestionText: "How does the @State property wrapper work in SwiftUI?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "@State allows a view to store and update its local state, triggering UI updates when the state changes."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 17,
//                         QuestionText: "What is the difference between @ObservedObject and @EnvironmentObject in SwiftUI?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "@ObservedObject is used to observe specific data within a view, while @EnvironmentObject shares data globally across multiple views."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 18,
//                         QuestionText: "What is Core Data in iOS development?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Core Data is Apple’s framework for managing an app’s data model and persistent storage."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 18,
//                         QuestionText: "What is the role of NSManagedObject in Core Data?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "NSManagedObject represents a single record in the Core Data model and provides dynamic storage for its properties."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 18,
//                         QuestionText: "Explain how Core Data differs from SQLite.",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Core Data is an object graph management framework, not just a database. It abstracts database operations and manages object relationships, while SQLite is a low-level relational database."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 19,
//                         QuestionText: "What is the purpose of the Combine framework?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Combine is used to handle asynchronous data streams and events in a reactive programming style."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 19,
//                         QuestionText: "What are Publishers and Subscribers in Combine?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "Publishers emit data over time, while Subscribers receive and respond to that data, allowing event-driven workflows."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 19,
//                         QuestionText: "How can Combine be integrated with SwiftUI?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Combine works with SwiftUI by connecting @Published properties in ObservableObjects to SwiftUI views for automatic UI updates."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 20,
//                         QuestionText: "What is Flutter and who developed it?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Flutter is an open-source UI toolkit developed by Google for building natively compiled applications for mobile, web, and desktop from a single codebase."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 20,
//                         QuestionText: "What is the role of widgets in Flutter?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "In Flutter, everything is a widget. Widgets describe how the UI should look, and when the state changes, Flutter rebuilds the affected widgets."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 20,
//                         QuestionText: "Explain the difference between StatefulWidget and StatelessWidget.",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "A StatelessWidget does not change its state once built, while a StatefulWidget maintains mutable state that can be updated using setState()."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 21,
//                         QuestionText: "What is React Native used for?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "React Native is a framework that allows developers to build mobile applications for iOS and Android using JavaScript and React."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 21,
//                         QuestionText: "How does React Native differ from ReactJS?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "ReactJS is used for building web applications with HTML and CSS, while React Native uses native components to create mobile apps."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 21,
//                         QuestionText: "What is the purpose of the Bridge in React Native?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "The Bridge allows JavaScript code to communicate with native modules, enabling interaction between React components and platform-specific APIs."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 22,
//                         QuestionText: "What is Xamarin and what language does it use?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Xamarin is a Microsoft framework for building cross-platform mobile apps using the C# programming language."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 22,
//                         QuestionText: "What are the differences between Xamarin.Forms and Xamarin.Native?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "Xamarin.Forms allows developers to share UI code across platforms, while Xamarin.Native provides more control with separate UI designs for each platform."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 22,
//                         QuestionText: "How does Xamarin achieve native performance?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Xamarin compiles C# code into native code for Android and iOS, and provides direct access to native APIs for performance similar to fully native apps."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 23,
//                         QuestionText: "What is Ionic used for?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Ionic is a framework for building cross-platform mobile apps using HTML, CSS, and JavaScript."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 23,
//                         QuestionText: "What is the role of Capacitor in Ionic projects?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "Capacitor provides a modern runtime that bridges web code with native device features like the camera, file system, and notifications."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 23,
//                         QuestionText: "Explain how Ionic apps access native device functionalities.",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Ionic apps use Capacitor or Cordova plugins to access native APIs, allowing JavaScript code to interact with platform features securely."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 24,
//                         QuestionText: "What is Unity primarily used for?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Unity is a cross-platform game engine used to create 2D and 3D games and interactive experiences using C# scripting."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 24,
//                         QuestionText: "Explain the role of GameObjects and Components in Unity.",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "GameObjects are the basic entities in Unity scenes, while Components define their behavior, appearance, and functionality."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 24,
//                         QuestionText: "What is the difference between Update() and FixedUpdate() methods in Unity?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Update() runs once per frame and is used for regular logic, while FixedUpdate() runs at a fixed interval and is used for physics calculations."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 25,
//                         QuestionText: "What language does Unreal Engine primarily use?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Unreal Engine primarily uses C++ and its visual scripting system called Blueprints."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 25,
//                         QuestionText: "What is the difference between Blueprints and C++ scripting in Unreal?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "Blueprints allow developers to create gameplay logic visually without code, while C++ scripting offers more control and performance optimization."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 25,
//                         QuestionText: "Explain how the Unreal Engine rendering pipeline works.",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Unreal uses a deferred rendering pipeline, separating geometry and lighting passes for efficient high-quality graphics and real-time effects."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 26,
//                         QuestionText: "What programming languages can be used in Godot Engine?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Godot supports GDScript (its native scripting language), C#, and visual scripting."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 26,
//                         QuestionText: "What is the difference between Node and Scene in Godot?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "A Node is a single functional unit, while a Scene is a collection of Nodes that can be reused and instanced in other scenes."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 26,
//                         QuestionText: "How does Godot handle signals and events?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Godot uses a signal system that allows nodes to communicate with each other by emitting and connecting events without tight coupling."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 27,
//                         QuestionText: "What does 'game architecture' refer to in C# game development?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Game architecture refers to the structural design of the game’s codebase, including how systems, components, and logic are organized."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 27,
//                         QuestionText: "Explain the concept of the Entity-Component-System (ECS) pattern.",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "ECS separates data (components) from logic (systems), allowing for reusable, efficient, and flexible game design."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 27,
//                         QuestionText: "How can design patterns improve large game projects in C#?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Design patterns like Singleton, Observer, and Factory help manage complexity, reduce coupling, and improve maintainability in large-scale games."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 28,
//                         QuestionText: "Why is optimizing assets important when developing Unity games for mobile devices?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Optimizing assets reduces the game's size and memory usage, making it run smoothly on devices with limited resources."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 28,
//                         QuestionText: "How can you reduce draw calls to improve performance in Unity mobile games?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "You can combine meshes, use texture atlases, and enable GPU instancing to reduce draw calls and boost frame rates."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 28,
//                         QuestionText: "Explain how to use Unity Profiler and Addressables together for performance optimization on mobile.",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "The Unity Profiler helps detect performance bottlenecks, while Addressables manage dynamic asset loading efficiently, reducing memory pressure and improving runtime performance."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 29,
//                         QuestionText: "What programming languages are commonly used in Cocos2d-x game development?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Cocos2d-x primarily supports C++, Lua, and JavaScript for cross-platform 2D game development."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 29,
//                         QuestionText: "How does the Scene and Layer structure help organize a Cocos2d-x game?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "Scenes represent game stages, while Layers contain sprites, UI, or logic elements. This separation improves readability and modularity."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 29,
//                         QuestionText: "Describe how to implement sprite batching and memory pooling in Cocos2d-x for performance optimization.",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Sprite batching groups similar textures to minimize draw calls, while memory pooling reuses game objects to reduce allocation overhead and frame drops."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 30,
//                         QuestionText: "What are the most common monetization methods in mobile games?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "The main monetization methods include in-app purchases, ads, and subscription models."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 30,
//                         QuestionText: "How can player analytics help improve monetization strategies?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "By analyzing player behavior, developers can identify retention patterns and optimize ad placements or pricing to maximize revenue."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 30,
//                         QuestionText: "Explain how to integrate rewarded video ads and in-app purchases together without hurting user experience.",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Rewarded ads can offer small in-game benefits, while in-app purchases provide premium upgrades. Combining both allows monetization flexibility without frustrating players." 
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 31,
//                         QuestionText: "What is Phaser.js mainly used for?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Phaser.js is used to create browser-based 2D games using JavaScript and HTML5 canvas."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 31,
//                         QuestionText: "How does the game loop work in Phaser.js?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "The game loop continuously updates and renders the game scene using the `update()` and `render()` functions to keep animations and logic running smoothly."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 31,
//                         QuestionText: "Explain how to manage physics and collisions in Phaser.js.",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Phaser.js includes Arcade, Impact, and Matter.js physics engines. Developers define bodies, enable collisions, and handle overlap events for precise interaction between objects."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 32,
//                         QuestionText: "What is Three.js used for in web development?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Three.js is a JavaScript library for creating 3D graphics and games in the browser using WebGL."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 32,
//                         QuestionText: "How do you create a basic 3D scene in Three.js?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "You create a scene, add a camera and a renderer, then add objects like meshes and lights before rendering the scene in a loop."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 32,
//                         QuestionText: "Describe how lighting and materials affect rendering performance in Three.js.",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Complex materials and dynamic lights increase GPU load. Using baked lighting, fewer shadows, and optimized shaders improves rendering speed for 3D web games."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 33,
//                         QuestionText: "What type of games or experiences can be built using Babylon.js?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Babylon.js is used to create 3D web games, simulations, and immersive experiences directly in the browser."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 33,
//                         QuestionText: "What role do scenes and cameras play in Babylon.js?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "A scene contains all 3D elements like meshes and lights, while a camera defines the viewer's perspective and controls movement and rotation in the environment."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 33,
//                         QuestionText: "Explain how Babylon.js supports physics and post-processing effects.",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Babylon.js integrates physics engines like Cannon.js or Ammo.js for realistic interactions and supports post-processing pipelines for effects like bloom, motion blur, and depth of field."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 34,
//                         QuestionText: "What is Docker, and why is it used in modern development?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Docker is a platform that packages applications and their dependencies into containers, ensuring consistency across development and production environments."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 34,
//                         QuestionText: "Explain the difference between a Docker image and a container.",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "A Docker image is a read-only template containing the application and its environment. A container is a running instance of that image, isolated from the system."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 34,
//                         QuestionText: "How do you optimize Docker images for production environments?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Use multi-stage builds, minimal base images (like Alpine), and `.dockerignore` files to reduce size and improve security."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 35,
//                         QuestionText: "What problem does Kubernetes solve?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Kubernetes automates the deployment, scaling, and management of containerized applications."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 35,
//                         QuestionText: "What are Pods and Nodes in Kubernetes?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "A Pod is the smallest deployable unit that runs one or more containers. Nodes are worker machines where Pods run."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 35,
//                         QuestionText: "Explain how Kubernetes handles load balancing and service discovery.",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Kubernetes Services expose Pods internally or externally and automatically distribute traffic between them using label selectors and DNS-based discovery."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 36,
//                         QuestionText: "What does CI/CD stand for, and why is it important?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "CI/CD stands for Continuous Integration and Continuous Deployment. It automates building, testing, and delivering code, ensuring faster and more reliable releases."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 36,
//                         QuestionText: "Describe the main stages of a typical CI/CD pipeline.",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "Typical stages include source checkout, build, automated testing, deployment to staging, and production release."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 36,
//                         QuestionText: "How do you ensure security and rollback safety in CI/CD pipelines?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Use secret management, signed artifacts, automated testing, and maintain versioned rollback procedures to prevent and recover from faulty deployments."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 37,
//                         QuestionText: "What is GitHub Actions used for?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "GitHub Actions automates workflows such as testing, building, and deploying code directly from a GitHub repository."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 37,
//                         QuestionText: "What is a YAML workflow file in GitHub Actions?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "A YAML file defines a workflow's triggers, jobs, and steps. It tells GitHub Actions what tasks to perform and when to execute them."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 37,
//                         QuestionText: "How can you reuse or modularize workflows in GitHub Actions?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "You can use reusable workflows, composite actions, and local actions to modularize code and share workflows across repositories."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 38,
//                         QuestionText: "What is Jenkins, and why is it popular in CI/CD?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Jenkins is an open-source automation server that enables developers to build, test, and deploy code automatically, supporting plugins and integrations."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 38,
//                         QuestionText: "Explain the concept of a Jenkins pipeline.",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "A Jenkins pipeline is a scripted or declarative process that defines how software is built, tested, and deployed across stages."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 38,
//                         QuestionText: "How can Jenkins be integrated with containerized environments?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "You can run Jenkins in Docker containers, use Kubernetes for agent scaling, and define pipeline steps that build and deploy Docker images."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 39,
//                         QuestionText: "What is GitLab CI/CD, and how is it triggered?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "GitLab CI/CD automates building, testing, and deploying code. It is triggered by changes pushed to the repository, defined in a `.gitlab-ci.yml` file."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 39,
//                         QuestionText: "Explain the purpose of stages and jobs in GitLab CI/CD.",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "Stages define the order of execution (like build → test → deploy), while jobs contain the scripts and commands to run within each stage."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 39,
//                         QuestionText: "How do you secure secrets and environment variables in GitLab CI/CD?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Use GitLab’s protected variables feature or external secret managers to securely store and inject sensitive credentials during pipeline execution."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 40,
//                         QuestionText: "What is Docker and why is it used?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Docker packages applications into containers to ensure consistency across different environments."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 40,
//                         QuestionText: "What is the difference between a Docker image and container?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "An image is a template used to create containers. A container is a running instance of an image."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 40,
//                         QuestionText: "How can you reduce the size of Docker images?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Use lightweight base images like Alpine, combine layers, and remove cache files."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 41,
//                         QuestionText: "What is Kubernetes?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "A container orchestration platform that manages containerized apps automatically."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 41,
//                         QuestionText: "What is the difference between a Pod and a Deployment?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "A Pod runs containers; a Deployment manages and replicates Pods for high availability."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 41,
//                         QuestionText: "How do you secure sensitive data in Kubernetes?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Use Kubernetes Secrets and external tools like Vault for encryption and secure storage."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 42,
//                         QuestionText: "What is Terraform and what is it used for?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Terraform manages cloud infrastructure using code, making deployments consistent and automated."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 42,
//                         QuestionText: "What is the purpose of the terraform plan command?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "It previews changes to infrastructure before applying them."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 42,
//                         QuestionText: "How do you manage Terraform state in a team?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Use remote backends like S3 with state locking, or Terraform Cloud, to avoid conflicts."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 43,
//                         QuestionText: "What is the main purpose of a firewall?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "A firewall filters incoming and outgoing traffic to prevent unauthorized access to a network."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 43,
//                         QuestionText: "What is the difference between a VPN and a proxy?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "A VPN encrypts all network traffic, while a proxy only routes specific application traffic without full encryption."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 43,
//                         QuestionText: "How can intrusion detection systems (IDS) be integrated into a security architecture?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "IDS can be placed at network entry points to monitor traffic and send alerts for suspicious activity; combined with SIEM tools for deeper analysis."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 44,
//                         QuestionText: "What is a vulnerability assessment?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "It is the process of identifying and analyzing security weaknesses in systems or networks."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 44,
//                         QuestionText: "What is the difference between vulnerability scanning and penetration testing?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "Vulnerability scanning identifies potential flaws automatically, while penetration testing actively exploits them to confirm risks."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 44,
//                         QuestionText: "How do you prioritize vulnerabilities found in a scan?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "By assessing their CVSS score, exploitability, asset value, and business impact."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 45,
//                         QuestionText: "What is incident response in cybersecurity?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Incident response is the process of detecting, analyzing, and responding to security breaches or attacks."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 45,
//                         QuestionText: "What are the main phases of the incident response lifecycle?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "Preparation, Detection, Containment, Eradication, Recovery, and Lessons Learned."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 45,
//                         QuestionText: "How would you handle a ransomware attack as part of incident response?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Isolate infected systems, preserve evidence, remove the malware, restore from backups, and perform a post-incident review to prevent recurrence."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 46,
//                         QuestionText: "What is penetration testing?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "It’s an authorized simulated attack to identify security vulnerabilities before malicious hackers do."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 46,
//                         QuestionText: "What are the main phases of a penetration test?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "Planning, Scanning, Gaining Access, Maintaining Access, and Reporting."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 46,
//                         QuestionText: "How would you test an organization’s internal network security?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "By conducting internal network scans, privilege escalation attempts, and lateral movement analysis using tools like Nmap and BloodHound."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 47,
//                         QuestionText: "What is Metasploit used for?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Metasploit is used to develop and execute exploit code against remote targets."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 47,
//                         QuestionText: "How do payloads and exploits differ in Metasploit?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "An exploit delivers the attack, while a payload defines what action occurs after exploitation, like opening a reverse shell."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 47,
//                         QuestionText: "How would you use Metasploit to test post-exploitation persistence?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "By creating persistent payloads that re-establish access after reboot using Metasploit modules or scripts."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 48,
//                         QuestionText: "What is SQL Injection?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "It’s an attack that manipulates SQL queries by injecting malicious input to access or modify database data."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 48,
//                         QuestionText: "How do you prevent Cross-Site Scripting (XSS)?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "By validating and encoding user input and using Content Security Policy headers."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 48,
//                         QuestionText: "Describe how you would perform a web app penetration test.",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "By mapping the app, testing authentication, input validation, session management, and running OWASP ZAP or Burp Suite scans."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 49,
//                         QuestionText: "What is SIEM and why is it important?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "SIEM collects and analyzes security logs to detect and respond to potential threats."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 49,
//                         QuestionText: "What’s the difference between SIEM and SOAR?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "SIEM focuses on detection and correlation of events, while SOAR automates responses to those events."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 49,
//                         QuestionText: "How would you build effective SIEM rules?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "By defining correlation rules based on known attack patterns (MITRE ATT&CK), false-positive tuning, and regular rule updates."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 50,
//                         QuestionText: "What is threat hunting?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "It’s the proactive search for undetected cyber threats inside a network."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 50,
//                         QuestionText: "How do you start a hunting hypothesis?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "By analyzing threat intelligence, SIEM data, or anomalies to form a testable assumption of malicious activity."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 50,
//                         QuestionText: "Describe how you would use endpoint data in a threat hunt.",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "By analyzing EDR logs for process anomalies, command-line execution, and suspicious network activity to confirm or deny threats."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 51,
//                         QuestionText: "What is a Purple Team?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "It’s a collaboration between red (offensive) and blue (defensive) teams to enhance security defenses."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 51,
//                         QuestionText: "How does purple teaming differ from regular penetration testing?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "In purple teaming, both attack and defense teams work together and share findings in real-time for better improvement."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 51,
//                         QuestionText: "How would you measure the success of a purple team engagement?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "By Technologying detection rates, response time, and improved defense mechanisms after each collaborative exercise."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 52,
//                         QuestionText: "What is the purpose of the GROUP BY clause in SQL?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "It groups rows that have the same values in specified columns and allows aggregation like COUNT or SUM."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 52,
//                         QuestionText: "How do INNER JOIN and LEFT JOIN differ?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "INNER JOIN returns only matching rows, while LEFT JOIN returns all rows from the left table plus matches from the right."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 52,
//                         QuestionText: "How can you optimize slow SQL queries on large datasets?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "By adding indexes, avoiding SELECT *, analyzing query plans, and partitioning large tables."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 53,
//                         QuestionText: "What is a Pivot Table used for in Excel?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Pivot Tables summarize and analyze data by grouping and aggregating values dynamically."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 53,
//                         QuestionText: "How do you use VLOOKUP in Excel?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "VLOOKUP searches for a value in the first column of a table and returns a corresponding value from another column."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 53,
//                         QuestionText: "What’s the difference between Power Query and Power Pivot?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Power Query is used for data cleaning and importing, while Power Pivot is used for modeling and advanced calculations using DAX."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 54,
//                         QuestionText: "Why is data visualization important?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "It helps present data insights clearly and visually so decision-makers can quickly understand trends and patterns."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 54,
//                         QuestionText: "How do filters and slicers differ in Power BI?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "Filters limit data globally in reports, while slicers provide interactive visual control for users on dashboards."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 54,
//                         QuestionText: "How would you design an effective dashboard for executive decision-making?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "By focusing on key KPIs, using clear visuals, maintaining consistency, and ensuring interactivity for detailed exploration."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 55,
//                         QuestionText: "What is pandas used for in data science?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Pandas is used for data manipulation and analysis through powerful data structures like DataFrames."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 55,
//                         QuestionText: "How do NumPy arrays differ from Python lists?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "NumPy arrays are more memory-efficient and support vectorized operations for numerical computing."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 55,
//                         QuestionText: "How would you handle large datasets that don’t fit in memory using Python?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "By using chunking, Dask, or distributed processing frameworks to process data in parts."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 56,
//                         QuestionText: "What is supervised learning?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "It’s a machine learning method where models are trained on labeled data to make predictions."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 56,
//                         QuestionText: "What’s the difference between overfitting and underfitting?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "Overfitting happens when a model learns noise, underfitting happens when it fails to learn patterns."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 56,
//                         QuestionText: "How do you evaluate the performance of a classification model?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Using metrics like accuracy, precision, recall, F1-score, and ROC-AUC depending on the dataset."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 57,
//                         QuestionText: "What is data cleaning?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "It’s the process of detecting and correcting errors or inconsistencies in datasets."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 57,
//                         QuestionText: "How do you handle missing data?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "By imputation (mean, median, mode), forward fill, or removing rows/columns depending on context."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 57,
//                         QuestionText: "Describe a method for feature scaling.",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Use normalization (MinMaxScaler) or standardization (StandardScaler) to align feature ranges."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 58,
//                         QuestionText: "What is Apache Spark used for?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "It’s used for distributed data processing and analytics on large datasets."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 58,
//                         QuestionText: "Explain the difference between RDD and DataFrame in Spark.",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "RDDs are low-level distributed objects, while DataFrames provide schema and optimizations through Catalyst."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 58,
//                         QuestionText: "How does Spark handle fault tolerance?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Through lineage graphs that allow recomputation of lost data using resilient distributed datasets (RDDs)."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 59,
//                         QuestionText: "What does ETL stand for?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "ETL means Extract, Transform, and Load – a process for moving data from sources to storage."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 59,
//                         QuestionText: "How do you schedule ETL workflows?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "Using tools like Apache Airflow or cron jobs to automate task dependencies and execution timing."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 59,
//                         QuestionText: "How would you handle data consistency in ETL pipelines?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "By implementing idempotent operations, checkpoints, and schema validation before loading."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 60,
//                         QuestionText: "What is a data warehouse?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "It’s a centralized repository for structured data used in reporting and analysis."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 60,
//                         QuestionText: "What’s the difference between OLTP and OLAP systems?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "OLTP handles transactional data, while OLAP focuses on analytical queries and reporting."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 60,
//                         QuestionText: "How do you optimize queries in a data warehouse?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "By using partitioning, materialized views, caching, and columnar storage formats."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 61,
//                         QuestionText: "What is TensorFlow?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "It’s an open-source framework for building and training machine learning and deep learning models."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 61,
//                         QuestionText: "What’s the role of Keras in TensorFlow?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "Keras is a high-level API within TensorFlow used for easy model building and training."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 61,
//                         QuestionText: "How can TensorFlow models be optimized for production?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "By quantization, pruning, and using TensorFlow Lite or TensorFlow Serving for efficient deployment."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 62,
//                         QuestionText: "What is MLOps?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "MLOps applies DevOps principles to machine learning to streamline model lifecycle management."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 62,
//                         QuestionText: "What’s the difference between CI/CD and MLOps pipelines?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "MLOps pipelines include additional steps for data validation, model training, and retraining beyond traditional CI/CD."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 62,
//                         QuestionText: "How would you monitor a deployed ML model for drift?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "By tracking prediction distributions and comparing them with training data to detect data or concept drift."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 63,
//                         QuestionText: "What is model deployment?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "It’s the process of integrating a trained ML model into an application for real-world predictions."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 63,
//                         QuestionText: "What’s the difference between batch and real-time inference?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "Batch inference processes multiple records periodically, while real-time inference responds instantly to inputs."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 63,
//                         QuestionText: "How do you serve a model via an API?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "By using Flask, FastAPI, or TensorFlow Serving to create REST endpoints that handle model requests."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 64,
//                         QuestionText: "What is Adobe XD used for?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "It’s used for UI/UX design and prototyping interactive user interfaces."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 64,
//                         QuestionText: "How do you create interactive prototypes in Adobe XD?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "By linking artboards with transitions and triggers to simulate user flow."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 64,
//                         QuestionText: "How can you export assets for developers in XD?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "By marking assets for export and using design specs to generate code-friendly outputs."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 65,
//                         QuestionText: "What makes Figma different from other design tools?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Figma is browser-based and supports real-time collaboration between designers."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 65,
//                         QuestionText: "What are Figma components?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "Components are reusable UI elements that maintain consistency across designs."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 65,
//                         QuestionText: "How would you organize a large Figma project efficiently?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "By using pages, frames, styles, and consistent naming conventions with component libraries."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 66,
//                         QuestionText: "What is a design system?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "It’s a collection of reusable components and design rules to ensure consistency across products."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 66,
//                         QuestionText: "What’s the benefit of using a design system?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "It improves design efficiency, consistency, and collaboration between designers and developers."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 66,
//                         QuestionText: "How do you maintain scalability in a design system?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "By modularizing components, versioning updates, and maintaining documentation in tools like Storybook or Zeroheight."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 67,
//                         QuestionText: "What is the difference between qualitative and quantitative research methods?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Qualitative research explores user behaviors and motivations through interviews and observations, while quantitative research uses numerical data and statistics."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 67,
//                         QuestionText: "How do you define user personas, and why are they important?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "User personas represent typical users based on research data, helping designers make user-centered decisions throughout the design process."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 67,
//                         QuestionText: "Explain how to conduct a heuristic evaluation in UX research.",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "A heuristic evaluation involves reviewing a product against usability principles (heuristics) to identify usability issues without user involvement."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 68,
//                         QuestionText: "What tools are commonly used for wireframing and prototyping?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Tools like Figma, Adobe XD, and Sketch are commonly used for creating wireframes and interactive prototypes."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 68,
//                         QuestionText: "How does a wireframe differ from a prototype?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "A wireframe is a low-fidelity layout focusing on structure and content placement, while a prototype simulates user interactions and flow."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 68,
//                         QuestionText: "Describe how you test a prototype with users to gather feedback.",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "You create tasks for users to complete in the prototype, observe their actions, and collect qualitative feedback to identify usability issues."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 69,
//                         QuestionText: "What is usability testing in UX design?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Usability testing evaluates how easily users can use a design by observing them as they complete specific tasks."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 69,
//                         QuestionText: "How do you prepare a usability testing session?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "You define goals, recruit target users, prepare tasks, and record user behavior during the test."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 69,
//                         QuestionText: "How do you analyze and prioritize findings from usability tests?",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "You categorize issues by severity, frequency, and impact, then create actionable recommendations for the design team."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 70,
//                         QuestionText: "What is a design system, and why is it important?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "A design system is a collection of reusable UI components and guidelines that ensure consistency across products."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 70,
//                         QuestionText: "How do you maintain consistency in a design system across teams?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "By maintaining clear documentation, enforcing naming conventions, and using shared component libraries in tools like Figma."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 70,
//                         QuestionText: "Explain how tokens and variables help in scalable design systems.",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Design tokens define consistent values for color, spacing, and typography, making it easier to update themes globally."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 71,
//                         QuestionText: "What is Auto Layout in Figma used for?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "Auto Layout automatically adjusts the position and size of elements when content changes, keeping the design responsive."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 71,
//                         QuestionText: "How do variants improve component organization in Figma?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "Variants allow multiple component states (like hover, active) to exist in one organized set, simplifying design updates."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 71,
//                         QuestionText: "Explain the benefits of using Figma plugins in a product design workflow.",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "Plugins automate repetitive tasks, improve accessibility, and integrate external tools like content or icons into Figma projects."
//                     }, 
//                     new InterviewQuestion   
//                     {
//                         TechnologyId: 72,
//                         QuestionText: "What is a user journey map?",
//                         DifficultyLevel: "Beginner",
//                         QuestionType: "technical",
//                         SampleAnswer: "A user journey map is a visual representation of a user’s interaction with a product over time."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 72,
//                         QuestionText: "How does journey mapping differ from user flow diagrams?",
//                         DifficultyLevel: "Intermediate",
//                         QuestionType: "technical",
//                         SampleAnswer: "User flows focus on task steps, while journey maps include user emotions, touchpoints, and pain points throughout the experience."
//                     },
//                     new InterviewQuestion
//                     {
//                         TechnologyId: 72,
//                         QuestionText: "Describe how to use journey maps to identify design opportunities.",
//                         DifficultyLevel: "Advanced",
//                         QuestionType: "technical",
//                         SampleAnswer: "By analyzing pain points and emotional highs/lows in the journey, designers can spot where new features or UX improvements are needed."
//                     }                       
//                 };

//                 context.InterviewQuestions.AddRange(questions);
//                 context.SaveChanges();
//             }
//         }

//         public static void SeedRoadmaps(ApplicationDbContext context)
//         {
//             if (!context.Roadmaps.Any())
//             {
//                 var roadmaps = new[]
//                 {
//                     new Roadmap
//                     {
//                         TechnologyId = 1,
//                         Title = "HTML & CSS Roadmap",
//                         Description = "Start with HTML structure and tags, then learn CSS fundamentals (selectors, box model, flexbox, grid) and responsive design. Build landing pages and portfolios."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId = 2,
//                         Title = "JavaScript Roadmap",
//                         Description = "Master core JavaScript (ES6+), DOM manipulation, async patterns (promises/async-await), and work with APIs. Build interactive apps and small projects."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId = 3,
//                         Title = "React Roadmap",
//                         Description = "Learn components, props, state and hooks, routing, context, and state management. Practice building reusable components and SPA projects."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 4,
//                         Title: "Tailwind CSS Roadmap",
//                         Description: "Learn utility classes, responsive design, customization, and using Tailwind with component libraries to build fast UI prototypes."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 5,
//                         Title: "Redux Roadmap",
//                         Description: "Understand store, actions, reducers, middleware and integrate Redux (or Redux Toolkit) to manage complex app state and async flows."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 6,
//                         Title: ".NET Core Roadmap",
//                         Description: "Start with C# basics, then learn ASP.NET Core Web APIs, dependency injection, and Entity Framework for data access. Deploy APIs to production."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 7,
//                         Title: "Entity Framework Core Roadmap",
//                         Description: "Learn ORM concepts, modelling entities, relationships, migrations, and querying with LINQ. Build CRUD and data-driven features."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 8,
//                         Title: "Node.js Roadmap",
//                         Description: "Learn Node core, event loop, modules, and build servers. Use package management and integrate databases for backend services."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 9,
//                         Title: "Express.js Roadmap",
//                         Description: "Master routing, middleware, RESTful API design, error handling, and authentication. Connect Express to databases and production practices."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 10,
//                         Title: "MERN Stack Roadmap",
//                         Description: "Combine MongoDB, Express, React, and Node to build full-stack apps with authentication, CRUD, and deployment pipelines."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 11,
//                         Title: "Django + React Roadmap",
//                         Description: "Learn Django fundamentals, Django REST Framework, serializers, and connect with React for full-stack applications."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 12,
//                         Title: ".NET + Angular Roadmap",
//                         Description: "Learn TypeScript, Angular components, services, routing, and RxJS for building large-scale SPAs."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 13,
//                         Title: "Kotlin Roadmap",
//                         Description: "Learn Kotlin basics, Android Studio, layouts, lifecycle, and MVVM architecture for building native Android apps."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 14,
//                         Title: "Flutter App Development Bootcamp Roadmap",
//                         Description: "Learn Dart, Flutter widgets, state management, navigation, and Firebase integration. Build and test cross-platform apps."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 15,
//                         Title: "React Native for Android Developers Roadmap",
//                         Description: "Learn core components, navigation, native modules, and performance optimizations to build cross-platform mobile apps."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 16,
//                         Title: "Swift Roadmap",
//                         Description: "Learn Swift syntax, Xcode setup, and UIKit. Move to SwiftUI, Combine, and Core Data to build modern iOS apps."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 17,
//                         Title: "SwiftUI Essentials Roadmap",
//                         Description: "Build modern, responsive UIs using SwiftUI, understand views, state, bindings, and layout system; create prototype apps."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 18,
//                         Title: "Core Data & Persistence Roadmap",
//                         Description: "Learn how to model local data, use Core Data for persistence, perform migrations, and fetch efficiently in iOS apps."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 19,
//                         Title: "Combine Framework Roadmap",
//                         Description: "Understand reactive programming with Combine: publishers, subscribers, operators, and integrating Combine with SwiftUI."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 20,
//                         Title: "Flutter Roadmap",
//                         Description: "Master Dart language and Flutter framework, widgets, state management, testing and deployment for cross-platform apps."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 21,
//                         Title: "React Native Roadmap",
//                         Description: "Learn React Native core concepts, setup environment, and work with APIs and navigation. Build apps with offline support."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 22,
//                         Title: "Xamarin Roadmap",
//                         Description: "Use C# and .NET to build cross-platform mobile apps, understand Xamarin.Forms, native bindings and app lifecycle."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 23,
//                         Title: "Capacitor + Ionic Roadmap",
//                         Description: "Build hybrid apps using web technologies, handle native plugins, and package apps for stores."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 24,
//                         Title: "Unity Roadmap",
//                         Description: "Learn engine basics, scripting, scene management and build small game projects while focusing on optimization and asset workflow."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 25,
//                         Title: "Unreal Engine Roadmap",
//                         Description: "Learn the Unreal editor, Blueprints, and C++ scripting. Create realistic 3D environments and gameplay mechanics."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 26,
//                         Title: "Godot Engine Roadmap",
//                         Description: "Learn Godot interface and GDScript (or C#), scene system, and build 2D/3D projects with export to desktop and mobile."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 27,
//                         Title: "C# Game Architecture Roadmap",
//                         Description: "Understand design patterns, modular architecture, and performance practices for large-scale game systems."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 28,
//                         Title: "Unity for Mobile Roadmap",
//                         Description: "Optimize Unity games for mobile: asset management, performance tuning, memory and battery considerations."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 29,
//                         Title: "Cocos2d-x Roadmap",
//                         Description: "Learn Cocos2d-x basics, C++/Lua scripting, scene and resource management for lightweight 2D mobile games."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 30,
//                         Title: "Mobile Game Monetization Roadmap",
//                         Description: "Learn monetization strategies, ads, IAP, analytics, and optimization for mobile game distribution."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 31,
//                         Title: "Phaser.js Roadmap",
//                         Description: "Create browser-based 2D games with Phaser: game loop, input handling, sprites, physics and simple deployment."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 32,
//                         Title: "Three.js Roadmap",
//                         Description: "Learn WebGL basics via Three.js: scene, camera, lighting, meshes, and building interactive 3D web experiences."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 33,
//                         Title: "Babylon.js Roadmap",
//                         Description: "Build immersive 3D web apps using Babylon.js, learn scene optimization, physics, and asset pipelines."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 34,
//                         Title: "Docker & Containerization Roadmap",
//                         Description: "Learn Docker images, containers, networking, volumes, and Docker Compose; package apps consistently across environments."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 35,
//                         Title: "Kubernetes Roadmap",
//                         Description: "Understand pods, deployments, services, scaling, configmaps, secrets and apply Kubernetes to run containerized apps at scale."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 36,
//                         Title: "CI/CD Pipelines Roadmap",
//                         Description: "Learn CI/CD principles, write pipelines or workflows to run tests, builds, and automated deploys in a reliable pipeline."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 37,
//                         Title: "GitHub Actions Roadmap",
//                         Description: "Automate builds and deployments. Write YAML workflows and integrate tests, builds, and cloud deploys."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 38,
//                         Title: "Jenkins Roadmap",
//                         Description: "Learn Jenkins concepts: jobs, pipelines, agents and how to integrate builds, tests and deploys with plugins."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 39,
//                         Title: "GitLab CI/CD Roadmap",
//                         Description: "Use GitLab CI: write .gitlab-ci.yml pipelines, stages, artifacts, and integrate with runners for automation."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 40,
//                         Title: "Docker Roadmap",
//                         Description: "Learn Docker images, containers, orchestration basics and how to containerize microservices for consistent deployment."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 41,
//                         Title: "Kubernetes Roadmap",
//                         Description: "Understand pods, deployments, services, scaling, configmaps, secrets and apply Kubernetes to run containerized apps at scale."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 42,
//                         Title: "Terraform Roadmap",
//                         Description: "Learn Infrastructure as Code basics, resource definitions, state management and provision cloud infrastructure safely."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 43,
//                         Title: "Wireshark Roadmap",
//                         Description: "Learn networking basics (OSI/TCP-IP, IP/MAC/ports), install Wireshark, practice capturing traffic, master display & capture filters, analyze common protocols (HTTP, DNS, TCP), detect suspicious patterns (ARP spoofing, packet sniffing), and practice with PCAP challenges and real-world case studies."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 44,
//                         Title: "Metasploit Roadmap",
//                         Description: "Understand penetration testing fundamentals and Linux basics, install Metasploit (use Kali/VM), learn msfconsole commands, perform reconnaissance (Nmap), practice exploiting vulnerable VMs (Metasploitable), study payloads & post-exploitation, then advanced topics: custom modules, automation, and CTF practice."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 45,
//                         Title: "Snort Roadmap",
//                         Description: "Learn IDS/IPS concepts, install Snort on Linux, configure snort.conf, run Snort in sniffer/IDS modes, write and test rules (alert/log/drop), analyze alerts/logs, integrate with tools like Barnyard2 or ELK, and refine rules for real network traffic and incident response workflows."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 46,
//                         Title: "Penetration Testing Roadmap",
//                         Description: "Study common vulnerabilities (OWASP), tools and ethical testing methodologies; practice in labs and CTFs."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 47,
//                         Title: "Exploitation Frameworks Roadmap",
//                         Description: "Learn Metasploit and other frameworks to automate exploitation and post-exploitation tasks in controlled environments."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 48,
//                         Title: "Web Application Security Roadmap",
//                         Description: "Understand OWASP Top10, secure coding practices, input validation, authentication and common mitigation techniques."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 49,
//                         Title: "Security Information and Event Management (SIEM) Roadmap",
//                         Description: "Learn log aggregation, correlation, alerting, and using SIEM tools to monitor and respond to security incidents."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 50,
//                         Title: "Threat Hunting Roadmap",
//                         Description: "Learn proactive threat detection, log analysis, indicators of compromise, and hunting methodologies."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 51,
//                         Title: "Purple Teaming Roadmap",
//                         Description: "Collaborate across red & blue teams to improve detection, response, and overall security posture through exercises."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 52,
//                         Title: "SQL for Data Analysis Roadmap",
//                         Description: "Master SQL querying, joins, aggregations and window functions to extract and analyze data efficiently."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 53,
//                         Title: "Excel for Data Analytics Roadmap",
//                         Description: "Learn advanced Excel functions, pivot tables, charts and data cleaning techniques for quick analytics and reporting."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 54,
//                         Title: "Data Visualization Tools Roadmap",
//                         Description: "Learn Power BI or Tableau fundamentals, data modelling, dashboards and storytelling with visualizations."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 55,
//                         Title: "Python for Data Science Roadmap",
//                         Description: "Build core skills: Python basics, NumPy, pandas, data cleaning, visualization and exploratory data analysis."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 56,
//                         Title: "Machine Learning Fundamentals Roadmap",
//                         Description: "Understand supervised and unsupervised learning, model evaluation, feature engineering and start with scikit-learn."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 57,
//                         Title: "Data Cleaning & Preprocessing Roadmap",
//                         Description: "Learn techniques for cleaning, transforming and preparing datasets for analysis and machine learning workflows."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 58,
//                         Title: "Apache Spark Roadmap",
//                         Description: "Learn distributed data processing with Spark: RDDs, DataFrames, Spark SQL and scaling data pipelines."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 59,
//                         Title: "ETL Pipelines Roadmap",
//                         Description: "Design robust ETL processes: extract from sources, transform/clean data, and load into warehouses or lakes."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 60,
//                         Title: "Data Warehousing Roadmap",
//                         Description: "Understand dimensional modelling, star schema, and tools like Redshift, BigQuery or Snowflake for analytics."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 61,
//                         Title: "TensorFlow Roadmap",
//                         Description: "Learn to build neural networks, train models, use Keras APIs, and deploy models for inference."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 62,
//                         Title: "MLOps Roadmap",
//                         Description: "Automate ML lifecycle: training pipelines, versioning, model serving, monitoring and reproducibility practices."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 63,
//                         Title: "Model Deployment Roadmap",
//                         Description: "Serve ML models via REST APIs or cloud services, manage scaling, latency and monitoring for production use."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 64,
//                         Title: "Adobe XD Roadmap",
//                         Description: "Learn prototyping, interactive components, and create high-fidelity UI mockups for user testing."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 65,
//                         Title: "Figma Roadmap",
//                         Description: "Learn Figma basics, auto layout, prototyping, components, and collaboration for design systems."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 66,
//                         Title: "Design Systems Roadmap",
//                         Description: "Learn how to create consistent and scalable UI systems with reusable components and guidelines."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 67,
//                         Title: "User Research Fundamentals Roadmap",
//                         Description: "Learn interview techniques, surveys, and usability tests to gather and analyze user insights."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 68,
//                         Title: "Wireframing & Prototyping Roadmap",
//                         Description: "Create wireframes and interactive prototypes to validate user flows and quickly iterate designs."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 69,
//                         Title: "Usability Testing Roadmap",
//                         Description: "Plan and run usability tests, collect feedback, analyze results and iterate on design improvements."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 70,
//                         Title: "Design Systems Roadmap",
//                         Description: "Start with UI/UX fundamentals and atomic design principles; learn how to create reusable components and document them. Study tools like Figma, Storybook, and Zeroheight for building and maintaining systems. Practice setting up a consistent design language (colors, typography, spacing). Then learn component libraries (React, Flutter, etc.), version control for design systems, and collaboration workflows between designers and developers."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 71,
//                         Title: "Figma Advanced Techniques Roadmap",
//                         Description: "Master components, auto layout patterns, variants, and build efficient reusable design systems in Figma."
//                     },
//                     new Roadmap
//                     {
//                         TechnologyId: 72,
//                         Title: "User Journey Mapping Roadmap",
//                         Description: "Visualize the entire user experience from start to finish to identify pain points and opportunities for improvement."
//                     }
//                 };
//                 context.Roadmaps.AddRange(roadmaps);
//                 context.SaveChanges();
//             }
//         }

//         public static void SeedRoadmapSteps(ApplicationDbContext context)
//         {
//             if (!context.RoadmapSteps.Any())
//             {
//                 var roadmapSteps = new[]
//                 {
//                     // Roadmap 1: HTML & CSS Roadmap
//                     new RoadmapStep { RoadmapId = 1, StepOrder = 1, StepTitle = "Learn HTML & CSS", StepDescription = "Start with the basics of web structure and styling." },
//                     new RoadmapStep { RoadmapId = 1, StepOrder = 2, StepTitle = "Master JavaScript", StepDescription = "Add interactivity and dynamic behavior to your websites." },
//                     new RoadmapStep { RoadmapId = 1, StepOrder = 3, StepTitle = "Responsive Design", StepDescription = "Make your websites look great on all devices using Flexbox and Grid." },
//                     new RoadmapStep { RoadmapId = 1, StepOrder = 4, StepTitle = "Learn React", StepDescription = "Build modern, component-based user interfaces with React." },
//                     new RoadmapStep { RoadmapId = 1, StepOrder = 5, StepTitle = "Build Projects", StepDescription = "Apply your skills by creating real-world projects like a portfolio or todo app." },

//                     // Roadmap 2: JavaScript Roadmap / .NET
//                     new RoadmapStep { RoadmapId = 2, StepOrder = 1, StepTitle = "Learn C#", StepDescription = "Master the fundamentals of C# programming language." },
//                     new RoadmapStep { RoadmapId = 2, StepOrder = 2, StepTitle = "Understand .NET Core", StepDescription = "Build your first web APIs and console applications." },
//                     new RoadmapStep { RoadmapId = 2, StepOrder = 3, StepTitle = "Work with Databases", StepDescription = "Use Entity Framework Core to connect and manage data." },
//                     new RoadmapStep { RoadmapId = 2, StepOrder = 4, StepTitle = "Authentication & Authorization", StepDescription = "Secure your APIs with JWT and user roles." },
//                     new RoadmapStep { RoadmapId = 2, StepOrder = 5, StepTitle = "Deploy to Cloud", StepDescription = "Publish your backend to Azure or other cloud platforms." },

//                     // Roadmap 3: React Roadmap
//                     new RoadmapStep { RoadmapId = 3, StepOrder = 1, StepTitle = "Frontend Basics", StepDescription = "HTML, CSS, JavaScript, and a framework like React." },
//                     new RoadmapStep { RoadmapId = 3, StepOrder = 2, StepTitle = "Backend with .NET", StepDescription = "Build RESTful APIs using C# and Entity Framework." },
//                     new RoadmapStep { RoadmapId = 3, StepOrder = 3, StepTitle = "Connect Frontend & Backend", StepDescription = "Use Axios or Fetch to communicate between client and server." },
//                     new RoadmapStep { RoadmapId = 3, StepOrder = 4, StepTitle = "Add Authentication", StepDescription = "Implement login and user sessions." },
//                     new RoadmapStep { RoadmapId = 3, StepOrder = 5, StepTitle = "Build a Full Project", StepDescription = "Create a complete app like a blog or task manager." },

//                     // Roadmap 4: Android / Kotlin
//                     new RoadmapStep { RoadmapId = 4, StepOrder = 1, StepTitle = "Learn Kotlin Basics", StepDescription = "Understand variables, functions, and control flow." },
//                     new RoadmapStep { RoadmapId = 4, StepOrder = 2, StepTitle = "Android Studio Setup", StepDescription = "Install and navigate the official Android IDE." },
//                     new RoadmapStep { RoadmapId = 4, StepOrder = 3, StepTitle = "Build UI with XML", StepDescription = "Design screens using layouts and views." },
//                     new RoadmapStep { RoadmapId = 4, StepOrder = 4, StepTitle = "Handle User Input", StepDescription = "Respond to clicks, gestures, and navigation." },
//                     new RoadmapStep { RoadmapId = 4, StepOrder = 5, StepTitle = "Publish to Play Store", StepDescription = "Prepare and release your first Android app." },

//                     // Roadmap 5: iOS / Swift
//                     new RoadmapStep { RoadmapId = 5, StepOrder = 1, StepTitle = "Learn Swift", StepDescription = "Start with Apple’s modern programming language." },
//                     new RoadmapStep { RoadmapId = 5, StepOrder = 2, StepTitle = "Xcode Basics", StepDescription = "Use Apple’s IDE to build and test apps." },
//                     new RoadmapStep { RoadmapId = 5, StepOrder = 3, StepTitle = "UIKit & SwiftUI", StepDescription = "Design interfaces with Apple’s frameworks." },
//                     new RoadmapStep { RoadmapId = 5, StepOrder = 4, StepTitle = "Test on Simulator", StepDescription = "Run and debug your app on virtual iOS devices." },
//                     new RoadmapStep { RoadmapId = 5, StepOrder = 5, StepTitle = "Submit to App Store", StepDescription = "Follow Apple’s guidelines to publish your app." },

//                     // Roadmap 6: Flutter / Dart
//                     new RoadmapStep { RoadmapId = 6, StepOrder = 1, StepTitle = "Dart Language", StepDescription = "Learn Dart basics — the language behind Flutter." },
//                     new RoadmapStep { RoadmapId = 6, StepOrder = 2, StepTitle = "Flutter Widgets", StepDescription = "Build UIs using Flutter’s rich widget library." },
//                     new RoadmapStep { RoadmapId = 6, StepOrder = 3, StepTitle = "Navigation & State", StepDescription = "Manage app flow and data changes." },
//                     new RoadmapStep { RoadmapId = 6, StepOrder = 4, StepTitle = "Connect to Backend", StepDescription = "Fetch data from APIs and display it." },
//                     new RoadmapStep { RoadmapId = 6, StepOrder = 5, StepTitle = "Deploy to Stores", StepDescription = "Publish your app to Google Play and App Store." },

//                     // Roadmap 7: Unity / Game Development
//                     new RoadmapStep { RoadmapId = 7, StepOrder = 1, StepTitle = "Install Unity", StepDescription = "Set up Unity Hub and your first project." },
//                     new RoadmapStep { RoadmapId = 7, StepOrder = 2, StepTitle = "Learn C# for Games", StepDescription = "Write scripts to control game objects." },
//                     new RoadmapStep { RoadmapId = 7, StepOrder = 3, StepTitle = "Physics & Collisions", StepDescription = "Make objects move, jump, and interact." },
//                     new RoadmapStep { RoadmapId = 7, StepOrder = 4, StepTitle = "UI & Menus", StepDescription = "Add start screens, scoreboards, and buttons." },
//                     new RoadmapStep { RoadmapId = 7, StepOrder = 5, StepTitle = "Build & Share", StepDescription = "Export your game for PC or mobile." },

//                     // Roadmap 8: Cybersecurity
//                     new RoadmapStep { RoadmapId = 8, StepOrder = 1, StepTitle = "Networking Basics", StepDescription = "Understand how data moves across networks." },
//                     new RoadmapStep { RoadmapId = 8, StepOrder = 2, StepTitle = "Linux Fundamentals", StepDescription = "Learn command line and system administration." },
//                     new RoadmapStep { RoadmapId = 8, StepOrder = 3, StepTitle = "Use Security Tools", StepDescription = "Practice with Wireshark, Nmap, and Metasploit." },
//                     new RoadmapStep { RoadmapId = 8, StepOrder = 4, StepTitle = "Ethical Hacking", StepDescription = "Learn penetration testing methodologies." },
//                     new RoadmapStep { RoadmapId = 8, StepOrder = 5, StepTitle = "Get Certified", StepDescription = "Prepare for certifications like CEH or CompTIA Security+." },

//                     // Roadmap 9: Data Analysis
//                     new RoadmapStep { RoadmapId = 9, StepOrder = 1, StepTitle = "Excel & Google Sheets", StepDescription = "Master formulas, pivot tables, and charts." },
//                     new RoadmapStep { RoadmapId = 9, StepOrder = 2, StepTitle = "Learn SQL", StepDescription = "Query databases to extract insights." },
//                     new RoadmapStep { RoadmapId = 9, StepOrder = 3, StepTitle = "Data Visualization", StepDescription = "Create dashboards with Power BI or Tableau." },
//                     new RoadmapStep { RoadmapId = 9, StepOrder = 4, StepTitle = "Basic Statistics", StepDescription = "Understand averages, distributions, and correlations." },
//                     new RoadmapStep { RoadmapId = 9, StepOrder = 5, StepTitle = "Tell Data Stories", StepDescription = "Present findings clearly to non-technical teams." },

//                     // Roadmap 10: Python / ML
//                     new RoadmapStep { RoadmapId = 10, StepOrder = 1, StepTitle = "Python Basics", StepDescription = "Learn syntax, loops, and functions." },
//                     new RoadmapStep { RoadmapId = 10, StepOrder = 2, StepTitle = "Pandas & NumPy", StepDescription = "Clean and manipulate data efficiently." },
//                     new RoadmapStep { RoadmapId = 10, StepOrder = 3, StepTitle = "Machine Learning", StepDescription = "Train models using Scikit-learn." },
//                     new RoadmapStep { RoadmapId = 10, StepOrder = 4, StepTitle = "Model Evaluation", StepDescription = "Measure accuracy, precision, and recall." },
//                     new RoadmapStep { RoadmapId = 10, StepOrder = 5, StepTitle = "Deploy a Model", StepDescription = "Use Flask or cloud APIs to share your model." },

//                     // Roadmap 11: UI/UX Design
//                     new RoadmapStep { RoadmapId = 11, StepOrder = 1, StepTitle = "Design Principles", StepDescription = "Learn contrast, alignment, spacing, and typography." },
//                     new RoadmapStep { RoadmapId = 11, StepOrder = 2, StepTitle = "Master Figma", StepDescription = "Create wireframes, mockups, and prototypes." },
//                     new RoadmapStep { RoadmapId = 11, StepOrder = 3, StepTitle = "UI Components", StepDescription = "Design buttons, forms, and navigation bars." },
//                     new RoadmapStep { RoadmapId = 11, StepOrder = 4, StepTitle = "Design Systems", StepDescription = "Build reusable libraries for consistency." },
//                     new RoadmapStep { RoadmapId = 11, StepOrder = 5, StepTitle = "Portfolio Project", StepDescription = "Redesign a popular app or create your own." },

//                     // Roadmap 12: UX Research
//                     new RoadmapStep { RoadmapId = 12, StepOrder = 1, StepTitle = "User Empathy", StepDescription = "Learn to see problems from the user’s perspective." },
//                     new RoadmapStep { RoadmapId = 12, StepOrder = 2, StepTitle = "Research Methods", StepDescription = "Conduct interviews, surveys, and usability tests." },
//                     new RoadmapStep { RoadmapId = 12, StepOrder = 3, StepTitle = "Personas & Journey Maps", StepDescription = "Visualize user needs and pain points." },
//                     new RoadmapStep { RoadmapId = 12, StepOrder = 4, StepTitle = "Wireframing", StepDescription = "Sketch low-fidelity solutions quickly." },
//                     new RoadmapStep { RoadmapId = 12, StepOrder = 5, StepTitle = "Test & Iterate", StepDescription = "Refine designs based on real user feedback." },
//                 };

//                 context.RoadmapSteps.AddRange(roadmapSteps);
//                 context.SaveChanges();
//             }
//         }

//         public static void SeedSubCategories(ApplicationDbContext context)
//         {
//             if (!context.SubCategories.Any())
//             {
//                 var subCategories = new[]
//                 {
//                     new SubCategory 
//                     { 
//                         CategoryId = 1, 
//                         SubCategoryName = "Web Development", 
//                         ImageBase64 = "", 
//                         Description = "Build websites and web applications using HTML, CSS, JavaScript, and frameworks like React or .NET.", 
//                         DifficultyLevel = "Beginner", 
//                         EstimatedDuration = 250 
//                     },
//                     new SubCategory 
//                     { 
//                         CategoryId = 1, 
//                         SubCategoryName = "Mobile Development", 
//                         ImageBase64 = "", 
//                         Description = "Create apps for iOS and Android using Flutter, React Native, or native tools like Swift and Kotlin.", 
//                         DifficultyLevel = "Beginner", 
//                         EstimatedDuration = 200 
//                     },
//                     new SubCategory 
//                     { 
//                         CategoryId = 1, 
//                         SubCategoryName = "Game Development", 
//                         ImageBase64 = "", 
//                         Description = "Design and code interactive games using Unity or Unreal Engine with C# or C++.", 
//                         DifficultyLevel = "Beginner", 
//                         EstimatedDuration = 220 
//                     },
//                     new SubCategory 
//                     { 
//                         CategoryId = 2, 
//                         SubCategoryName = "DevOps", 
//                         ImageBase64 = "", 
//                         Description = "Automate deployment, manage cloud infrastructure, and ensure smooth software delivery using Docker, Kubernetes, and CI/CD pipelines.", 
//                         DifficultyLevel = "Intermediate", 
//                         EstimatedDuration = 160 
//                     },
//                     new SubCategory 
//                     { 
//                         CategoryId = 2, 
//                         SubCategoryName = "Cyber Security", 
//                         ImageBase64 = "", 
//                         Description = "Learn to protect systems, networks, and data from digital attacks using ethical hacking and security best practices.", 
//                         DifficultyLevel = "Intermediate", 
//                         EstimatedDuration = 200 
//                     },
//                     new SubCategory 
//                     { 
//                         CategoryId = 3, 
//                         SubCategoryName = "Data Analysis", 
//                         ImageBase64 = "", 
//                         Description = "Turn raw data into insights using Excel, SQL, Python (Pandas), and visualization tools like Power BI.", 
//                         DifficultyLevel = "Beginner", 
//                         EstimatedDuration = 120 
//                     },
//                     new SubCategory 
//                     { 
//                         CategoryId = 3, 
//                         SubCategoryName = "Data Science", 
//                         ImageBase64 = "", 
//                         Description = "Apply statistics and machine learning to solve real-world problems using Python, Scikit-learn, and Jupyter Notebooks.", 
//                         DifficultyLevel = "Intermediate", 
//                         EstimatedDuration = 240 
//                     },
//                     new SubCategory 
//                     { 
//                         CategoryId = 3, 
//                         SubCategoryName = "Data Engineering", 
//                         ImageBase64 = "", 
//                         Description = "Build data pipelines and warehouses to collect, store, and process large-scale data using SQL, Spark, and cloud platforms.", 
//                         DifficultyLevel = "Advanced", 
//                         EstimatedDuration = 260 
//                     },
//                     new SubCategory 
//                     { 
//                         CategoryId = 3, 
//                         SubCategoryName = "ML Engineering", 
//                         ImageBase64 = "", 
//                         Description = "Deploy and scale machine learning models in production using MLOps practices, APIs, and cloud services.", 
//                         DifficultyLevel = "Advanced", 
//                         EstimatedDuration = 280 
//                     },
//                     new SubCategory 
//                     { 
//                         CategoryId = 4, 
//                         SubCategoryName = "UI/UX Design", 
//                         ImageBase64 = "", 
//                         Description = "Design user-friendly and visually appealing interfaces using Figma, user research, and design thinking principles.", 
//                         DifficultyLevel = "Beginner", 
//                         EstimatedDuration = 140 
//                     }
//                 };

//                 context.SubCategories.AddRange(subCategories);
//                 context.SaveChanges();
//             }
//         }

//         public static void SeedTechnology(ApplicationDbContext context)
//         {
//             if (!context.technology.Any())
//             {
//                 var Technology = new[]
//                 {
//                     // Technology 1
//                     new Technology { SubCategoryId = 1, TechnologyName = "HTML & CSS", Description = "The foundation of every website — structure with HTML and style with CSS.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 1, TechnologyName = "JavaScript", Description = "Add interactivity to websites with the most popular web programming language.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 1, TechnologyName = "React", Description = "Build dynamic user interfaces with this powerful JavaScript library by Facebook.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 1, TechnologyName = "Tailwind CSS", Description = "A utility-first CSS framework that allows developers to rapidly build modern, responsive, and customizable user interfaces.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 1, TechnologyName = "Redux", Description = "A state management library for JavaScript apps, commonly used with React to manage and share data across components efficiently.", VideoUrl = "", CreatedAt = DateTime.Now },

//                     // TechnologyId 2
//                     new Technology { SubCategoryId = 2, TechnologyName = ".NET Core", Description = "Microsoft's modern, cross-platform framework for building fast backend services.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 2, TechnologyName = "Entity Framework Core", Description = "An ORM that lets you work with databases using C# objects — no SQL needed!", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 2, TechnologyName = "Node.js", Description = "A JavaScript runtime built on Chrome's V8 engine that allows developers to build scalable and high-performance backend applications.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 2, TechnologyName = "Express.js", Description = "A minimal and flexible Node.js web application framework that provides robust features for building APIs and web servers.", VideoUrl = "", CreatedAt = DateTime.Now },

//                     // TechnologyId 3
//                     new Technology { SubCategoryId = 3, TechnologyName = "MERN Stack", Description = "A full-stack JavaScript framework combining MongoDB, Express, React, and Node.js for building complete web applications.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 3, TechnologyName = "Django + React", Description = "A powerful combination of Django for backend and React for frontend, used to build robust and interactive full-stack applications.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 3, TechnologyName = ".NET + Angular", Description = "An enterprise-level full-stack framework pairing .NET for backend APIs with Angular for building dynamic single-page applications.", VideoUrl = "", CreatedAt = DateTime.Now },

//                     // TechnologyId 4
//                     new Technology { SubCategoryId = 4, TechnologyName = "Kotlin", Description = "The modern programming language for Android app development.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 4, TechnologyName = "Flutter App Development Bootcamp", Description = "Develop Android and iOS apps from a single codebase using Flutter and Dart, including Firebase integration.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 4, TechnologyName = "React Native for Android Developers", Description = "Build cross-platform mobile apps for Android and iOS using JavaScript and React Native with hands-on projects.", VideoUrl = "", CreatedAt = DateTime.Now },

//                     // TechnologyId 5
//                     new Technology { SubCategoryId = 5, TechnologyName = "Swift", Description = "Apple's powerful and intuitive language for iOS and macOS apps.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 5, TechnologyName = "SwiftUI Essentials", Description = "Build modern and responsive UIs for iOS using Apple’s SwiftUI framework.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 5, TechnologyName = "Core Data & Persistence", Description = "Learn to store, manage, and fetch local data efficiently in iOS apps.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 5, TechnologyName = "Combine Framework", Description = "Handle asynchronous events and data streams with Apple’s Combine framework.", VideoUrl = "", CreatedAt = DateTime.Now },

//                     // TechnologyId 6
//                     new Technology { SubCategoryId = 6, TechnologyName = "Flutter", Description = "Build beautiful, natively compiled apps for mobile, web, and desktop from a single codebase.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 6, TechnologyName = "React Native", Description = "Develop mobile apps for both Android and iOS using React and JavaScript.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 6, TechnologyName = "Xamarin", Description = "Use C# and .NET to build cross-platform mobile apps with native performance.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 6, TechnologyName = "Capacitor + Ionic", Description = "Build hybrid mobile apps with modern web technologies and native integration.", VideoUrl = "", CreatedAt = DateTime.Now },

//                     // TechnologyId 7
//                     new Technology { SubCategoryId = 7, TechnologyName = "Unity", Description = "The leading platform for creating 2D and 3D games with C# scripting.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 7, TechnologyName = "Unreal Engine", Description = "Create high-end 3D desktop games with C++ and Blueprints.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 7, TechnologyName = "Godot Engine", Description = "An open-source engine for creating 2D and 3D games using GDScript or C#.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 7, TechnologyName = "C# Game Architecture", Description = "Learn to design reusable and scalable systems for large desktop games.", VideoUrl = "", CreatedAt = DateTime.Now },

//                     // TechnologyId 8
//                     new Technology { SubCategoryId = 8, TechnologyName = "Unity for Mobile", Description = "Optimize Unity games for mobile platforms with lightweight assets and performance tuning.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 8, TechnologyName = "Cocos2d-x", Description = "Build lightweight 2D mobile games using C++ and Lua.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 8, TechnologyName = "Mobile Game Monetization", Description = "Learn to integrate ads, in-app purchases, and analytics into your mobile games.", VideoUrl = "", CreatedAt = DateTime.Now },

//                     // TechnologyId 9
//                     new Technology { SubCategoryId = 9, TechnologyName = "Phaser.js", Description = "Create browser-based 2D games using the popular Phaser game framework.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 9, TechnologyName = "Three.js", Description = "Build 3D games and visualizations for the web using WebGL and Three.js.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 9, TechnologyName = "Babylon.js", Description = "A powerful framework for creating immersive 3D web experiences and games.", VideoUrl = "", CreatedAt = DateTime.Now },

//                     // TechnologyId 10
//                     new Technology { SubCategoryId = 10, TechnologyName = "Docker & Containerization", Description = "Learn how to package, deploy, and manage applications in lightweight containers using Docker.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 10, TechnologyName = "Kubernetes", Description = "Master container orchestration for deploying, scaling, and managing applications across clusters.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 10, TechnologyName = "CI/CD Pipelines", Description = "Automate build, test, and deployment workflows to improve software delivery and reliability.", VideoUrl = "", CreatedAt = DateTime.Now },

//                     // TechnologyId 11
//                     new Technology { SubCategoryId = 11, TechnologyName = "GitHub Actions", Description = "Automate workflows directly in GitHub for building, testing, and deploying applications.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 11, TechnologyName = "Jenkins", Description = "An open-source automation server that helps automate parts of software development like building and deployment.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 11, TechnologyName = "GitLab CI/CD", Description = "A built-in CI/CD tool in GitLab for automating builds, tests, and deployments efficiently.", VideoUrl = "", CreatedAt = DateTime.Now },

//                     // TechnologyId 12
//                     new Technology { SubCategoryId = 12, TechnologyName = "Docker", Description = "Containerization platform used to package and run applications consistently across environments.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 12, TechnologyName = "Kubernetes", Description = "A container orchestration platform that automates deployment, scaling, and management of containerized apps.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 12, TechnologyName = "Terraform", Description = "Infrastructure as Code (IaC) tool that provisions and manages cloud infrastructure using configuration files.", VideoUrl = "", CreatedAt = DateTime.Now },

//                     // TechnologyId 13
//                     new Technology { SubCategoryId = 13, TechnologyName = "Wireshark", Description = "A network protocol analyzer used to capture and analyze packets for troubleshooting and security testing.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 13, TechnologyName = "Metasploit", Description = "A penetration testing framework used to identify, exploit, and validate vulnerabilities in systems.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 13, TechnologyName = "Snort", Description = "An open-source intrusion detection and prevention system (IDS/IPS) that monitors network traffic for malicious activity.", VideoUrl = "", CreatedAt = DateTime.Now },

//                     // TechnologyId 14
//                     new Technology { SubCategoryId = 14, TechnologyName = "Penetration Testing", Description = "Perform controlled attacks to identify and exploit vulnerabilities ethically.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 14, TechnologyName = "Exploitation Frameworks", Description = "Use tools like Metasploit to automate exploitation and post-exploitation tasks.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 14, TechnologyName = "Web Application Security", Description = "Test and secure web applications against common vulnerabilities like SQL injection and XSS.", VideoUrl = "", CreatedAt = DateTime.Now },

//                     // TechnologyId 15
//                     new Technology { SubCategoryId = 15, TechnologyName = "Security Information and Event Management (SIEM)", Description = "Monitor and analyze security logs to detect threats using tools like Splunk or ELK Stack.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 15, TechnologyName = "Threat Hunting", Description = "Proactively search for hidden cyber threats in systems and networks.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 15, TechnologyName = "Purple Teaming", Description = "Collaborate between red and blue teams to improve overall security posture.", VideoUrl = "", CreatedAt = DateTime.Now },

//                     // TechnologyId 16
//                     new Technology { SubCategoryId = 16, TechnologyName = "SQL for Data Analysis", Description = "Use SQL queries to extract, filter, and aggregate data from databases for insights.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 16, TechnologyName = "Excel for Data Analytics", Description = "Analyze and visualize data using Excel functions, pivot tables, and charts.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 16, TechnologyName = "Data Visualization Tools", Description = "Create interactive dashboards using Power BI or Tableau to communicate insights effectively.", VideoUrl = "", CreatedAt = DateTime.Now },

//                     // TechnologyId 17
//                     new Technology { SubCategoryId = 17, TechnologyName = "Python for Data Science", Description = "Use Python libraries like NumPy, pandas, and Matplotlib for data analysis and visualization.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 17, TechnologyName = "Machine Learning Fundamentals", Description = "Understand core ML concepts like regression, classification, and model evaluation.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 17, TechnologyName = "Data Cleaning & Preprocessing", Description = "Prepare and transform raw data for analysis using tools like pandas and scikit-learn.", VideoUrl = "", CreatedAt = DateTime.Now },

//                     // TechnologyId 18
//                     new Technology { SubCategoryId = 18, TechnologyName = "Apache Spark", Description = "Process large-scale data using distributed computing with Spark’s RDD and DataFrame APIs.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 18, TechnologyName = "ETL Pipelines", Description = "Build Extract, Transform, Load pipelines for moving and cleaning data efficiently.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 18, TechnologyName = "Data Warehousing", Description = "Design and manage scalable data storage systems like Snowflake, Redshift, or BigQuery.", VideoUrl = "", CreatedAt = DateTime.Now },

//                     // TechnologyId 19
//                     new Technology { SubCategoryId = 19, TechnologyName = "TensorFlow", Description = "Build and deploy deep learning models with TensorFlow and Keras APIs.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 19, TechnologyName = "MLOps", Description = "Automate ML lifecycle including training, deployment, and monitoring in production.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 19, TechnologyName = "Model Deployment", Description = "Serve ML models via REST APIs or cloud services for real-time predictions.", VideoUrl = "", CreatedAt = DateTime.Now },

//                     // TechnologyId 20
//                     new Technology { SubCategoryId = 20, TechnologyName = "Adobe XD", Description = "Design and prototype user interfaces with Adobe XD’s interactive tools.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 20, TechnologyName = "Figma", Description = "Collaborate on UI designs in real-time with Figma’s cloud-based platform.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 20, TechnologyName = "Design Systems", Description = "Create consistent UI components and style guides for scalable design.", VideoUrl = "", CreatedAt = DateTime.Now },

//                     // TechnologyId 21
//                     new Technology { SubCategoryId = 21, TechnologyName = "User Research Fundamentals", Description = "Learn how to conduct interviews, surveys, and usability tests to understand user needs.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 21, TechnologyName = "Wireframing & Prototyping", Description = "Create wireframes and prototypes to visualize user flows and test interactions early.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 21, TechnologyName = "Usability Testing", Description = "Evaluate designs through user testing and analyze feedback to improve the UX.", VideoUrl = "", CreatedAt = DateTime.Now },

//                     // TechnologyId 22
//                     new Technology { SubCategoryId = 22, TechnologyName = "Design Systems", Description = "Build consistent and scalable UI systems with reusable components and guidelines.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 22, TechnologyName = "Figma Advanced Techniques", Description = "Master Figma components, auto layout, and prototyping for efficient design workflows.", VideoUrl = "", CreatedAt = DateTime.Now },
//                     new Technology { SubCategoryId = 22, TechnologyName = "User Journey Mapping", Description = "Visualize the entire user experience from start to finish to identify pain points and opportunities.", VideoUrl = "", CreatedAt = DateTime.Now }
//                 };

//                 context.Technologys.AddRange(Technologys);
//                 context.SaveChanges();
//             }
//         }

//         public static void SeedTracks(ApplicationDbContext context)
//         {
//             if (!context.Tracks.Any())
//             {
//                 var tracks = new[]
//                 {
//                     new Track { SubCategoryId = 1, TrackName = "Frontend Development", Description = "Learn to build user interfaces with HTML, CSS, JavaScript, and frameworks like React or Angular.", DifficultyLevel = "Beginner", EstimatedDuration = 100 },
//                     new Track { SubCategoryId = 1, TrackName = "Backend Development", Description = "Master server-side logic, databases, and APIs using .NET, Node.js, or Python.", DifficultyLevel = "Intermediate", EstimatedDuration = 150 },
//                     new Track { SubCategoryId = 1, TrackName = "Full Stack Development", Description = "Combine frontend and backend skills to build complete web applications from scratch.", DifficultyLevel = "Intermediate", EstimatedDuration = 250 },

//                     new Track { SubCategoryId = 2, TrackName = "Android Development", Description = "Build native Android apps using Kotlin or Java with Android Studio.", DifficultyLevel = "Beginner", EstimatedDuration = 120 },
//                     new Track { SubCategoryId = 2, TrackName = "iOS Development", Description = "Create iOS apps using Swift and Xcode for Apple devices.", DifficultyLevel = "Beginner", EstimatedDuration = 120 },
//                     new Track { SubCategoryId = 2, TrackName = "Cross-Platform Mobile", Description = "Develop apps for both Android and iOS using Flutter or React Native.", DifficultyLevel = "Beginner", EstimatedDuration = 140 },

//                     new Track { SubCategoryId = 3, TrackName = "Desktop Game Development", Description = "Build PC games using Unity or Unreal Engine with C# or C++.", DifficultyLevel = "Intermediate", EstimatedDuration = 180 },
//                     new Track { SubCategoryId = 3, TrackName = "Mobile Game Development", Description = "Create games for smartphones using Unity or Godot with touch controls and mobile optimization.", DifficultyLevel = "Intermediate", EstimatedDuration = 160 },
//                     new Track { SubCategoryId = 3, TrackName = "Web Game Development", Description = "Design browser-based games using HTML5, JavaScript, and WebGL.", DifficultyLevel = "Beginner", EstimatedDuration = 100 },

//                     new Track { SubCategoryId = 4, TrackName = "Platform Engineer", Description = "Design and maintain cloud platforms and infrastructure for development teams.", DifficultyLevel = "Advanced", EstimatedDuration = 200 },
//                     new Track { SubCategoryId = 4, TrackName = "CI/CD Automation", Description = "Automate testing and deployment pipelines using GitHub Actions, Jenkins, or GitLab CI.", DifficultyLevel = "Intermediate", EstimatedDuration = 140 },
//                     new Track { SubCategoryId = 4, TrackName = "DevOps Engineer", Description = "Bridge development and operations by managing infrastructure as code and monitoring systems.", DifficultyLevel = "Advanced", EstimatedDuration = 220 },

//                     new Track { SubCategoryId = 5, TrackName = "Defensive Security", Description = "Protect systems by identifying vulnerabilities and implementing security controls.", DifficultyLevel = "Intermediate", EstimatedDuration = 160 },
//                     new Track { SubCategoryId = 5, TrackName = "Offensive Security", Description = "Ethically hack systems to find weaknesses before attackers do.", DifficultyLevel = "Advanced", EstimatedDuration = 180 },
//                     new Track { SubCategoryId = 5, TrackName = "Full Spectrum Security Analyst", Description = "Combine defensive and offensive techniques to become a well-rounded cybersecurity professional.", DifficultyLevel = "Advanced", EstimatedDuration = 240 },

//                     new Track { SubCategoryId = 6, TrackName = "Data Analyst", Description = "Clean, analyze, and visualize data to support business decisions using SQL and Excel.", DifficultyLevel = "Beginner", EstimatedDuration = 120 },
//                     new Track { SubCategoryId = 7, TrackName = "Data Scientist", Description = "Apply machine learning and statistics to extract insights from complex datasets.", DifficultyLevel = "Intermediate", EstimatedDuration = 240 },
//                     new Track { SubCategoryId = 8, TrackName = "Data Engineer", Description = "Build scalable data pipelines and warehouses using SQL, Spark, and cloud tools.", DifficultyLevel = "Advanced", EstimatedDuration = 260 },
//                     new Track { SubCategoryId = 9, TrackName = "ML Engineer", Description = "Deploy and optimize machine learning models in production environments.", DifficultyLevel = "Advanced", EstimatedDuration = 280 },

//                     new Track { SubCategoryId = 10, TrackName = "UI Designer", Description = "Focus on visual design, layout, and branding to create beautiful interfaces.", DifficultyLevel = "Beginner", EstimatedDuration = 100 },
//                     new Track { SubCategoryId = 10, TrackName = "UX Designer", Description = "Research user needs and design intuitive experiences that solve real problems.", DifficultyLevel = "Beginner", EstimatedDuration = 120 },
//                     new Track { SubCategoryId = 10, TrackName = "Product Designer (Full UI/UX)", Description = "Combine UI and UX skills to lead the design of entire products from concept to launch.", DifficultyLevel = "Intermediate", EstimatedDuration = 200 }
//                 };

//                 context.Tracks.AddRange(tracks);
//                 context.SaveChanges();
//             }
//         }


//         public static void SeedUsers(ApplicationDbContext context)
//         {
//             if (!context.Users.Any())
//             {
//                 var users = new[]
//                 {
//                     new User { UserName = "Layla", Email = "layla@example.com", PasswordHash = "hashed_password_1" },
//                     new User { UserName = "Ahmed", Email = "ahmed@example.com", PasswordHash = "hashed_password_2" },
//                     new User { UserName = "Nora", Email = "nora@example.com", PasswordHash = "hashed_password_3" },
//                     new User { UserName = "Omar", Email = "omar@example.com", PasswordHash = "hashed_password_4" }
//                 };

//                 context.Users.AddRange(users);
//                 context.SaveChanges();
//             }
//         }

//         public static void SeedReviews(ApplicationDbContext context)
//         {
//             if (!context.Reviews.Any())
//             {
//                 var reviews = new[]
//                 {
//                     new Review 
//                     { 
//                         UserId = 1, 
//                         TechnologyId = 1, 
//                         Rating = 5, 
//                         ReviewText = "HTML & CSS were my first step into web development — clear, visual, and rewarding!" 
//                     },
//                     new Review 
//                     { 
//                         UserId = 1, 
//                         TechnologyId = 2, 
//                         Rating = 4, 
//                         ReviewText = "JavaScript opened the door to interactivity. Took time to grasp closures, but worth it!" 
//                     },
//                     new Review 
//                     { 
//                         UserId = 2, 
//                         TechnologyId = 4, 
//                         Rating = 5, 
//                         ReviewText = "I built my first API with .NET Core in just two weeks. Clean, fast, and well-documented!" 
//                     },
//                     new Review 
//                     { 
//                         UserId = 2, 
//                         TechnologyId = 5, 
//                         Rating = 4, 
//                         ReviewText = "Entity Framework Core saved me from writing raw SQL. Migrations are a game-changer!" 
//                     },
//                     new Review 
//                     { 
//                         UserId = 3, 
//                         TechnologyId = 3, 
//                         Rating = 5, 
//                         ReviewText = "React made building UIs fun! Components are intuitive, and the community is amazing." 
//                     },
//                     new Review 
//                     { 
//                         UserId = 3, 
//                         TechnologyId = 16, 
//                         Rating = 5, 
//                         ReviewText = "Figma is perfect for designers and developers alike. Real-time collaboration changed how I work!" 
//                     },
//                     new Review 
//                     { 
//                         UserId = 4, 
//                         TechnologyId = 12, 
//                         Rating = 4, 
//                         ReviewText = "SQL is essential. Once I got the hang of JOINs, everything clicked!" 
//                     },
//                     new Review 
//                     { 
//                         UserId = 4, 
//                         TechnologyId = 14, 
//                         Rating = 5, 
//                         ReviewText = "Pandas made data analysis feel like magic. Cleaning data has never been this easy!" 
//                     }
//                 };

//                 context.Reviews.AddRange(reviews);
//                 context.SaveChanges();
//             }
//         }
//     }
// }
