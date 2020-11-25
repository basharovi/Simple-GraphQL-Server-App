using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using simple_graphql_app.Models;

namespace simple_graphql_app.Data
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
                        FirstName = "Bashar",
                        LastName = "Ovi"
                    }
                });
                context.Enrollments.Add(new Enrollment
                {
                    Course = course,
                    Student = new Student
                    {
                        FirstName = "Sujit",
                        LastName = "Biswash"
                    }
                });
                context.Enrollments.Add(new Enrollment
                {
                    Course = course,
                    Student = new Student
                    {
                        FirstName = "Akash",
                        LastName = "Abir"
                    }
                });

                context.SaveChangesAsync();
            }
        }
    }
}
