using SimpleGraphQLApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleGraphQLApp.Data
{
    public static class InitializeDatabase
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (context.Database.EnsureCreated())
            {
                var course = new Course
                {
                    Credits = 4,
                    Title = "Object Oriented Programming"
                };

                context.Enrollments.Add(new Enrollment
                {
                    Course = course,
                    Student = new Student
                    {
                        FirstMidName = "Bashar",
                        LastName = "Ovi"
                    }
                });
                context.Enrollments.Add(new Enrollment
                {
                    Course = course,
                    Student = new Student 
                    { 
                        FirstMidName = "Sujit",
                        LastName = "Biswash"
                    }
                });
                context.Enrollments.Add(new Enrollment
                {
                    Course = course,
                    Student = new Student 
                    { 
                        FirstMidName = "Akash", 
                        LastName = "Abir"
                    }
                });

                context.SaveChangesAsync();
            }
        }
    }
}
